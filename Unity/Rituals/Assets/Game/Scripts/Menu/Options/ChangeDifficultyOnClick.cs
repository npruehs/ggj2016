// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChangeDifficultyOnClick.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Menu.Options
{
    using System;

    using Rituals.Settings.Data;
    using Rituals.Settings.Storage;

    using UnityEngine.UI;

    public class ChangeDifficultyOnClick : ButtonClickHandler
    {
        #region Fields

        public Text Text;

        #endregion

        #region Methods

        protected override void OnButtonClicked()
        {
            // Update model.
            var currentDifficulty = SettingsStorage.Difficulty;
            var newDifficulty = ((int)currentDifficulty + 1) % Enum.GetValues(typeof(DifficultyLevel)).Length;
            SettingsStorage.Difficulty = (DifficultyLevel)newDifficulty;

            // Update view.
            this.UpdateText();
        }

        private void Start()
        {
            this.UpdateText();
        }

        private void UpdateText()
        {
            this.Text.text = SettingsStorage.Difficulty.ToString();
        }

        #endregion
    }
}