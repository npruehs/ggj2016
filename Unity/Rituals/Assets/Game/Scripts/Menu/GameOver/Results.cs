// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Results.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Menu.GameOver
{
    using UnityEngine;
    using UnityEngine.UI;

    public class Results : MonoBehaviour
    {
        #region Fields

        public Image DefeatOverlay;

        public Text LevelText;

        public Text ObjectivesText;

        public Text OutcomeText;

        public Text TotalPressureText;

        public Text TotalTimeText;

        public Image VictoryOverlay;

        #endregion

        #region Methods

        private void Start()
        {
            this.OutcomeText.text = ResultsStorage.LastOutcome.ToUpper();
            this.LevelText.text = string.Format("Level {0}", ResultsStorage.LastLevel);
            this.ObjectivesText.text = string.Format(
                "{0} / {1}",
                ResultsStorage.LastCompletedObjectives,
                ResultsStorage.LastTotalObjectives);
            this.TotalPressureText.text = string.Format("{0:0.00}", ResultsStorage.LastTotalPressure);
            this.TotalTimeText.text = string.Format("{0:0.00}", ResultsStorage.LastTotalTime);

            if (ResultsStorage.LastOutcome == "Victory")
            {
                this.DefeatOverlay.gameObject.SetActive(false);
            }
            else
            {
                this.VictoryOverlay.gameObject.SetActive(false);
            }
        }

        #endregion
    }
}