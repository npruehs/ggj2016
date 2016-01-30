// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChangeMouseSensitivyOnChange.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Menu.Options
{
    using Rituals.Settings.Storage;

    public class ChangeMouseSensitivyOnChange : SliderChangeHandler
    {
        #region Methods

        protected override void OnChanged(float f)
        {
            SettingsStorage.MouseSensitivity = f;
        }

        private void Start()
        {
            this.Slider.value = SettingsStorage.MouseSensitivity;
        }

        #endregion
    }
}