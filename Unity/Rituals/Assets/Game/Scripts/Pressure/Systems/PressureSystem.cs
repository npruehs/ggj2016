// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PressureSystem.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Pressure.Systems
{
    using Rituals.Core;
    using Rituals.Pressure.Events;

    using UnityEngine;

    public class PressureSystem : RitualsBehaviour
    {
        #region Fields

        public float PressurePerSecond;

        private float pressure;

        #endregion

        #region Methods

        private void Update()
        {
            this.pressure += this.PressurePerSecond * Time.deltaTime;

            this.EventManager.OnPressureChanged(this, new PressureChangedEventArgs { Pressure = this.pressure });
        }

        #endregion
    }
}