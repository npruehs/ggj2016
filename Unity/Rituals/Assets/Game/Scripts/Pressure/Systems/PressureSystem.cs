// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PressureSystem.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Pressure.Systems
{
    using Rituals.Core;
    using Rituals.Objectives.Events;
    using Rituals.Pressure.Events;
    using Rituals.Settings.Storage;

    using UnityEngine;

    public class PressureSystem : RitualsBehaviour
    {
        #region Fields

        private float pressure;

        #endregion

        #region Methods

        protected override void AddListeners()
        {
            base.AddListeners();

            this.EventManager.ObjectiveStateChanged += this.OnObjectiveStateChanged;
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();

            this.EventManager.ObjectiveStateChanged -= this.OnObjectiveStateChanged;
        }

        private void OnObjectiveStateChanged(object sender, ObjectiveStateChangedEventArgs args)
        {
            this.SetPressure(this.pressure - this.LevelSettings.PressureReducedPerObjective);
        }

        private void SetPressure(float newPressure)
        {
            // Clamp.
            this.pressure = Mathf.Clamp01(newPressure);

            // Notify listeners.
            this.EventManager.OnPressureChanged(this, new PressureChangedEventArgs { Pressure = this.pressure });
        }

        private void Update()
        {
            this.SetPressure(
                this.pressure
                + this.LevelSettings.PressureAppliedPerSecond * Time.deltaTime * ((int)SettingsStorage.Difficulty + 1));
        }

        #endregion
    }
}