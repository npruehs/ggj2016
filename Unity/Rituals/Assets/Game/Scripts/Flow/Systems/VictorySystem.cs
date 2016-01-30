﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VictorySystem.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Flow.Systems
{
    using Rituals.Core;
    using Rituals.Flow.Components;
    using Rituals.Interaction.Util;
    using Rituals.Objectives.Events;
    using Rituals.Physics.Events;
    using Rituals.Progression.Storage;

    using UnityEngine;

    public class VictorySystem : RitualsBehaviour
    {
        #region Fields

        private bool mayLeave;

        #endregion

        #region Methods

        protected override void AddListeners()
        {
            base.AddListeners();

            this.EventManager.CollisionEntered += this.OnCollisionEntered;
            this.EventManager.ObjectiveStateChanged += this.OnObjectiveStateChanged;
        }

        protected override void Init()
        {
            base.Init();

            var exit = FindObjectOfType<ExitComponent>();

            if (exit == null)
            {
                Debug.LogError("No exit found!");
                return;
            }

            InteractionUtils.IsInteractive(exit.gameObject);
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();

            this.EventManager.CollisionEntered -= this.OnCollisionEntered;
            this.EventManager.ObjectiveStateChanged -= this.OnObjectiveStateChanged;
        }

        private void OnCollisionEntered(object sender, CollisionEventArgs args)
        {
            if (this.Player == null)
            {
                return;
            }

            if (!this.mayLeave)
            {
                return;
            }

            if (args.First != this.Player.PlayerInteractionCollider)
            {
                return;
            }

            var exit = args.Second.GetComponentInParent<ExitComponent>();

            if (exit == null)
            {
                return;
            }

            // Victory!
            ProgressionStorage.SetLevelComplete(this.LevelSettings.LevelIndex);
            Application.LoadLevel("LevelSelection");
        }

        private void OnObjectiveStateChanged(object sender, ObjectiveStateChangedEventArgs args)
        {
            this.mayLeave = args.CompletedObjectives == args.TotalObjectives;
        }

        #endregion
    }
}