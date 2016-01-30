// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PressureItemSizeSystem.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Pressure.Systems
{
    using Rituals.Core;
    using Rituals.Objectives.Data;
    using Rituals.Objectives.Events;
    using Rituals.Pressure.Events;

    using UnityEngine;

    public class PressureItemSizeSystem : RitualsBehaviour
    {
        #region Fields

        private GameObject currentObjective;

        #endregion

        #region Methods

        protected override void AddListeners()
        {
            base.AddListeners();

            this.EventManager.PressureChanged += this.OnPressureChanged;
            this.EventManager.ObjectiveStateChanged += this.OnObjectiveStateChanged;
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();

            this.EventManager.PressureChanged -= this.OnPressureChanged;
            this.EventManager.ObjectiveStateChanged -= this.OnObjectiveStateChanged;
        }

        private void OnObjectiveStateChanged(object sender, ObjectiveStateChangedEventArgs args)
        {
            if (args.Objective == this.currentObjective && args.State == ObjectiveState.Complete)
            {
                this.currentObjective = null;
            }

            if (args.State == ObjectiveState.Active)
            {
                this.currentObjective = args.Objective;
            }
        }

        private void OnPressureChanged(object sender, PressureChangedEventArgs args)
        {
            if (this.currentObjective != null)
            {
                this.currentObjective.transform.localScale = Vector3.one * (1 + args.Pressure);
            }
        }

        #endregion
    }
}