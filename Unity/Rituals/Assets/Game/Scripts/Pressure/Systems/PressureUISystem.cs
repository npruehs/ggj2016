// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PressureUISystem.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Pressure.Systems
{
    using Rituals.Core;
    using Rituals.Pressure.Events;

    using UnityEngine;
    using UnityEngine.UI;

    public class PressureUISystem : RitualsBehaviour
    {
        #region Fields

        public Slider PressureSlider;

        public Image PressureSliderFill;

        #endregion

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
            if (this.PressureSlider != null)
            {
                this.PressureSlider.value = args.Pressure;
            }

            if (this.PressureSliderFill != null)
            {
                this.PressureSliderFill.color = Color.Lerp(Color.green, Color.red, args.Pressure);
            }
        }

        #endregion
    }
}