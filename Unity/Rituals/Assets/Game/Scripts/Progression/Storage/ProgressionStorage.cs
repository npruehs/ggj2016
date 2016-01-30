// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProgressionStorage.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Progression.Storage
{
    using UnityEngine;

    public class ProgressionStorage
    {
        #region Constants

        private const string LevelCompleteKey = "IsLevelComplete";

        #endregion

        #region Public Methods and Operators

        public static bool IsLevelComplete(int level)
        {
            var key = GetLevelCompleteKey(level);
            return PlayerPrefs.GetInt(key, 0) > 0;
        }

        public static void SetLevelComplete(int level)
        {
            var key = GetLevelCompleteKey(level);
            PlayerPrefs.SetInt(key, 1);
        }

        #endregion

        #region Methods

        private static string GetLevelCompleteKey(int level)
        {
            return string.Format("{0}{1}", LevelCompleteKey, level);
        }

        #endregion
    }
}