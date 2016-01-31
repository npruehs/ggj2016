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

        public Text OutcomeText;

        #endregion

        #region Methods

        private void Start()
        {
            this.OutcomeText.text = ResultsStorage.LastOutcome;
        }

        #endregion
    }
}