// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SliderChangeHandler.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Menu
{
    using UnityEngine;
    using UnityEngine.UI;

    public abstract class SliderChangeHandler : MonoBehaviour
    {
        #region Fields

        public Slider Slider;

        #endregion

        #region Methods

        protected abstract void OnChanged(float f);

        private void OnDisable()
        {
            if (this.Slider != null)
            {
                this.Slider.onValueChanged.RemoveListener(this.OnChanged);
            }
        }

        private void OnEnable()
        {
            if (this.Slider != null)
            {
                this.Slider.onValueChanged.AddListener(this.OnChanged);
            }
        }

        #endregion
    }
}