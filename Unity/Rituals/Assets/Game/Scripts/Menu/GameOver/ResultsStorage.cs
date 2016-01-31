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

        private const string LastCompletedObjectivesKey = "LastCompletedObjectives";

        private const string LastLevelKey = "LastLevel";

        private const string LastOutcomeKey = "LastOutcome";

        private const string LastTotalObjectivesKey = "LastTotalObjectives";

        private const string LastTotalPressureKey = "LastTotalPressure";

        private const string LastTotalTimeKey = "LastTotalTime";

        #endregion

        #region Properties

        public static int LastCompletedObjectives
        {
            get
            {
                return PlayerPrefs.GetInt(LastCompletedObjectivesKey);
            }
            set
            {
                PlayerPrefs.SetInt(LastCompletedObjectivesKey, value);
            }
        }

        public static int LastLevel
        {
            get
            {
                return PlayerPrefs.GetInt(LastLevelKey);
            }
            set
            {
                PlayerPrefs.SetInt(LastLevelKey, value);
            }
        }

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

        public static int LastTotalObjectives
        {
            get
            {
                return PlayerPrefs.GetInt(LastTotalObjectivesKey);
            }
            set
            {
                PlayerPrefs.SetInt(LastTotalObjectivesKey, value);
            }
        }

        public static float LastTotalPressure
        {
            get
            {
                return PlayerPrefs.GetFloat(LastTotalPressureKey);
            }
            set
            {
                PlayerPrefs.SetFloat(LastTotalPressureKey, value);
            }
        }

        public static float LastTotalTime
        {
            get
            {
                return PlayerPrefs.GetFloat(LastTotalTimeKey);
            }
            set
            {
                PlayerPrefs.SetFloat(LastTotalTimeKey, value);
            }
        }

        #endregion
    }
}