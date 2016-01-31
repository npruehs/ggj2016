// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ResultsStorage.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Menu.GameOver
{
    using UnityEngine;

    public class ResultsStorage
    {
        #region Constants

        private const string LastOutcomeKey = "LastOutcome";

        #endregion

        #region Properties

        public static string LastOutcome
        {
            get
            {
                return PlayerPrefs.GetString(LastOutcomeKey);
            }
            set
            {
                PlayerPrefs.SetString(LastOutcomeKey, value);
            }
        }

        #endregion
    }
}