// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PressureEffectsSystem.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Pressure.Systems
{
    using Rituals.Core;
    using Rituals.Pressure.Events;

    using UnityEngine;

    public class PressureEffectsSystem : RitualsBehaviour
    {
        #region Methods

        protected override void AddListeners()
        {
            base.AddListeners();

            this.EventManager.PressureChanged += this.OnPressureChanged;
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();

            this.EventManager.PressureChanged -= this.OnPressureChanged;
        }

        private void OnPressureChanged(object sender, PressureChangedEventArgs args)
        {
            if (this.Player == null)
            {
                return;
            }

            if (this.Player.VignetteAndChromaticAberration != null)
            {
                this.Player.VignetteAndChromaticAberration.chromaticAberration =
                    this.LevelSettings.ChromaticAbberationStrength * args.Pressure
                    * Mathf.Sin(Time.realtimeSinceStartup);
            }

            if (this.Player.Twirl != null)
            {
                this.Player.Twirl.angle = this.LevelSettings.TwirlStrength * args.Pressure
                                          * Mathf.Sin(Time.realtimeSinceStartup * 2.0f);
            }
        }

        #endregion
    }
}