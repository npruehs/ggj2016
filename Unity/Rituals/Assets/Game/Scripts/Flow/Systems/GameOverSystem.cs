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
    using Rituals.Objectives.Events;
    using Rituals.Pressure.Events;
    using Rituals.Progression.Storage;

    using UnityEngine;

    public class GameOverSystem : RitualsBehaviour
    {
        #region Fields

        private int completedObjectives;

        private float startTime;

        private int totalObjectives;

        private float totalPressure;

        #endregion

        #region Methods

        protected override void AddListeners()
        {
            base.AddListeners();

            this.EventManager.Victory += this.OnVictory;
            this.EventManager.Defeat += this.OnDefeat;
            this.EventManager.ObjectiveStateChanged += this.OnObjectiveStateChanged;
            this.EventManager.PressureChanged += this.OnPressureChanged;
        }

        protected override void Init()
        {
            base.Init();

            this.startTime = Time.realtimeSinceStartup;
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();

            this.EventManager.Victory -= this.OnVictory;
            this.EventManager.Defeat -= this.OnDefeat;
            this.EventManager.ObjectiveStateChanged -= this.OnObjectiveStateChanged;
            this.EventManager.PressureChanged -= this.OnPressureChanged;
        }

        private void OnDefeat(object sender, EventArgs args)
        {
            this.StoreResults("Defeat");
            Application.LoadLevel("GameOver");
        }

        private void OnObjectiveStateChanged(object sender, ObjectiveStateChangedEventArgs args)
        {
            this.completedObjectives = args.CompletedObjectives;
            this.totalObjectives = args.TotalObjectives;
        }

        private void OnPressureChanged(object sender, PressureChangedEventArgs args)
        {
            if (args.Delta < 0)
            {
                return;
            }

            this.totalPressure += args.Delta;
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
            ResultsStorage.LastLevel = this.LevelSettings.LevelIndex;
            ResultsStorage.LastCompletedObjectives = this.completedObjectives;
            ResultsStorage.LastTotalObjectives = this.totalObjectives;
            ResultsStorage.LastTotalPressure = this.totalPressure * 100;
            ResultsStorage.LastTotalTime = Time.realtimeSinceStartup - this.startTime;
        }

        #endregion
    }
}