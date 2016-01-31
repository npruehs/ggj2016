﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectiveSystem.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Objectives.Systems
{
    using System.Collections.Generic;
    using System.Linq;

    using Rituals.Core;
    using Rituals.Error.Events;
    using Rituals.Interaction.Components;
    using Rituals.Interaction.Events;
    using Rituals.Interaction.Util;
    using Rituals.Objectives.Data;
    using Rituals.Objectives.Events;
    using Rituals.Obstacles.Events;

    using UnityEngine;

    public class ObjectiveSystem : RitualsBehaviour
    {
        #region Fields

        private readonly List<Objective> objectives = new List<Objective>();

        private Objective currentObjective;

        private int remainingObstacles;

        #endregion

        #region Methods

        protected override void AddListeners()
        {
            base.AddListeners();

            this.EventManager.InteractableUsed += this.OnInteractableUsed;
            this.EventManager.ObstaclesChanged += this.OnObstaclesChanged;
        }

        protected override void Init()
        {
            base.Init();

            foreach (var objective in this.LevelSettings.Objectives)
            {
                // Verify objective.
                if (!this.VerifyObjective(objective))
                {
                    continue;
                }

                this.objectives.Add(new Objective { GameObject = objective, State = ObjectiveState.Inactive });

                Debug.Log(string.Format("Objective added: {0}.", objective.name));

                // Notify listeners.
                this.EventManager.OnObjectiveAdded(
                    this,
                    new ObjectiveAddedEventArgs { Index = this.objectives.Count, Objective = objective });
            }

            this.SetObjectiveState(this.objectives.FirstOrDefault(), ObjectiveState.Active);
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();

            this.EventManager.InteractableUsed -= this.OnInteractableUsed;
        }

        private void OnInteractableUsed(object sender, InteractableUsedEventArgs args)
        {
            if (this.currentObjective == null)
            {
                return;
            }

            if (this.remainingObstacles > 0)
            {
                this.EventManager.OnError(this, new ErrorEventArgs { ErrorMessage = "You can't do this right now. " });
                Debug.Log(string.Format("Objective blocked by {0} obstacles.", this.remainingObstacles));
                return;
            }

            if (this.currentObjective.GameObject == args.GameObject)
            {
                // Finish objective.
                this.SetObjectiveState(this.currentObjective, ObjectiveState.Complete);

                // Prevent further interaction.
                var interactableComponent = this.currentObjective.GameObject.GetComponent<InteractableComponent>();
                interactableComponent.Enabled = false;

                // Select next objective.
                var nextObjective = this.objectives.FirstOrDefault(obj => obj.State != ObjectiveState.Complete);

                if (nextObjective != null)
                {
                    this.SetObjectiveState(nextObjective, ObjectiveState.Active);
                }
                else
                {
                    this.SetCurrentObjective(null);
                }
            }
            else
            {
                this.EventManager.OnError(this, new ErrorEventArgs { ErrorMessage = "You can't do this right now. " });
            }
        }

        private void OnObstaclesChanged(object sender, ObstaclesChangedEventArgs args)
        {
            this.remainingObstacles = args.Obstacles;
        }

        private void SetCurrentObjective(Objective objective)
        {
            var oldObjective = this.currentObjective;

            this.currentObjective = objective;

            // Notify listeners.
            this.EventManager.OnCurrentObjectiveChanged(
                this,
                new CurrentObjectiveChangedEventArgs
                {
                    NewObjective = objective != null ? objective.GameObject : null,
                    OldObjective = oldObjective != null ? oldObjective.GameObject : null
                });
        }

        private void SetObjectiveState(Objective objective, ObjectiveState state)
        {
            if (objective == null)
            {
                return;
            }

            objective.State = state;

            if (objective.State == ObjectiveState.Active)
            {
                this.SetCurrentObjective(objective);
            }

            // Notify listeners.
            this.EventManager.OnObjectiveStateChanged(
                this,
                new ObjectiveStateChangedEventArgs
                {
                    CompletedObjectives = this.objectives.Count(obj => obj.State == ObjectiveState.Complete),
                    Objective = objective.GameObject,
                    State = state,
                    TotalObjectives = this.objectives.Count
                });

            Debug.Log(string.Format("Objective {0} changed to {1}.", objective, state));
        }

        private bool VerifyObjective(GameObject objective)
        {
            if (objective == null)
            {
                Debug.LogError(string.Format("One of the objectives is null."));
                return false;
            }

            var interactableComponent = objective.GetComponent<InteractableComponent>();

            if (interactableComponent == null)
            {
                Debug.LogError(
                    string.Format("Objective {0} does not have an InteractableComponent attached.", objective.name));
                return false;
            }

            return InteractionUtils.IsInteractive(objective);
        }

        #endregion

        private class Objective
        {
            #region Fields

            public GameObject GameObject;

            public ObjectiveState State;

            #endregion

            #region Public Methods and Operators

            public override string ToString()
            {
                return this.GameObject.name;
            }

            #endregion
        }
    }
}