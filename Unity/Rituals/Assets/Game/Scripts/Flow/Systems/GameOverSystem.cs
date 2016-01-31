// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GameOverSystem.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Flow.Systems
{
    using System;

    using Rituals.Core;
    using Rituals.Menu.GameOver;
    using Rituals.Progression.Storage;

    using UnityEngine;

    public class GameOverSystem : RitualsBehaviour
    {
        #region Methods

        protected override void AddListeners()
        {
            base.AddListeners();

            this.EventManager.Victory += this.OnVictory;
            this.EventManager.Defeat += this.OnDefeat;
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();

            this.EventManager.Victory -= this.OnVictory;
            this.EventManager.Defeat -= this.OnDefeat;
        }

        private void OnDefeat(object sender, EventArgs args)
        {
            this.StoreResults("Defeat");
            Application.LoadLevel("GameOver");
        }

        private void OnVictory(object sender, EventArgs args)
        {
            this.StoreResults("Victory");
            ProgressionStorage.SetLevelComplete(this.LevelSettings.LevelIndex);
            Application.LoadLevel("GameOver");
        }

        private void StoreResults(string outcome)
        {
            ResultsStorage.LastOutcome = outcome;
        }

        #endregion
    }
}