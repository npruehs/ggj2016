// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefeatSystem.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Flow.Systems
{
    using Rituals.Core;
    using Rituals.Pressure.Events;

    using UnityEngine;

    public class DefeatSystem : RitualsBehaviour
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
            if (args.Pressure >= 1)
            {
                // Defeat!
                Application.LoadLevel("MainMenu");
            }
        }

        #endregion
    }
}