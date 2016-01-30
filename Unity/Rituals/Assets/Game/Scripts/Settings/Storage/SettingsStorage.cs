// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SettingsStorage.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Settings.Storage
{
    using Rituals.Settings.Data;

    using UnityEngine;

    public class SettingsStorage
    {
        #region Constants

        private const string DifficultyKey = "DifficultyLevel";

        private const string MouseSensitivityKey = "MouseSensitivity";

        #endregion

        #region Properties

        public static DifficultyLevel Difficulty
        {
            get
            {
                return (DifficultyLevel)PlayerPrefs.GetInt(DifficultyKey, 0);
            }
            set
            {
                PlayerPrefs.SetInt(DifficultyKey, (int)value);
            }
        }

        public static float MouseSensitivity
        {
            get
            {
                return PlayerPrefs.GetFloat(MouseSensitivityKey, 1.0f);
            }
            set
            {
                PlayerPrefs.SetFloat(MouseSensitivityKey, value);
            }
        }

        #endregion
    }
}