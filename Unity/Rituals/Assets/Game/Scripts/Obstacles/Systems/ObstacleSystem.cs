// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObstacleSystem.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Obstacles.Systems
{
    using System.Collections.Generic;
    using System.Linq;

    using Rituals.Core;
    using Rituals.Interaction.Components;
    using Rituals.Interaction.Events;
    using Rituals.Interaction.Util;
    using Rituals.Objectives.Events;
    using Rituals.Obstacles.Data;
    using Rituals.Obstacles.Events;

    using UnityEngine;

    public class ObstacleSystem : RitualsBehaviour
    {
        #region Fields

        private readonly List<Obstacle> obstacles = new List<Obstacle>();

        private GameObject currentObjective;

        #endregion

        #region Methods

        protected override void AddListeners()
        {
            base.AddListeners();

            this.EventManager.InteractableUsed += this.OnInteractableUsed;
            this.EventManager.CurrentObjectiveChanged += this.OnCurrentObjectiveChanged;
        }

        protected override void Init()
        {
            base.Init();

            foreach (var obstacle in this.LevelSettings.Obstacles)
            {
                // Verify objective.
                if (!this.VerifyObstacle(obstacle))
                {
                    continue;
                }

                this.obstacles.Add(new Obstacle { Data = obstacle, Removed = false });

                Debug.Log(string.Format("Obstacle added: {0}.", obstacle.Obstacle.name));
            }

            if (this.currentObjective != null)
            {
                this.CheckObstacles();
            }
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();

            this.EventManager.InteractableUsed -= this.OnInteractableUsed;
            this.EventManager.CurrentObjectiveChanged -= this.OnCurrentObjectiveChanged;
        }

        private void CheckObstacles()
        {
            // Count obstacles.
            var remainingObstacles = this.CountCurrentObstacles();
            if (remainingObstacles > 0)
            {
                this.EventManager.OnObstaclesChanged(
                    this,
                    new ObstaclesChangedEventArgs { Objective = this.currentObjective, Obstacles = remainingObstacles });
            }
        }

        private int CountCurrentObstacles()
        {
            return this.obstacles.Count(o => o.Data.BlockedObjective == this.currentObjective && !o.Removed);
        }

        private void OnCurrentObjectiveChanged(object sender, CurrentObjectiveChangedEventArgs args)
        {
            this.currentObjective = args.NewObjective;
            this.CheckObstacles();
        }

        private void OnInteractableUsed(object sender, InteractableUsedEventArgs args)
        {
            var obstacle = this.obstacles.FirstOrDefault(o => o.Data.Obstacle == args.GameObject);

            if (obstacle == null)
            {
                return;
            }

            // Remove obstacle.
            obstacle.Removed = true;

            Object.Destroy(obstacle.Data.Obstacle);

            Debug.Log(string.Format("Obstacle removed: {0}", obstacle.Data.Obstacle.name));

            // Notify listeners.
            this.EventManager.OnObstaclesChanged(
                this,
                new ObstaclesChangedEventArgs
                {
                    Objective = this.currentObjective,
                    Obstacles = this.CountCurrentObstacles()
                });
        }

        private bool VerifyObstacle(ObstacleData obstacle)
        {
            if (obstacle.Obstacle == null)
            {
                Debug.LogError("One of the obstacles is null.");
                return false;
            }

            if (obstacle.BlockedObjective == null)
            {
                Debug.LogError("One of the blocked objectives is null.");
                return false;
            }

            var interactableComponent = obstacle.Obstacle.GetComponent<InteractableComponent>();

            if (interactableComponent == null)
            {
                Debug.LogError(
                    string.Format(
                        "Obstacle {0} does not have an InteractableComponent attached.",
                        obstacle.Obstacle.name));
                return false;
            }

            return InteractionUtils.IsInteractive(obstacle.Obstacle);
        }

        #endregion

        private class Obstacle
        {
            #region Fields

            public ObstacleData Data;

            public bool Removed;

            #endregion

            #region Public Methods and Operators

            public override string ToString()
            {
                return this.Data.Obstacle.name;
            }

            #endregion
        }
    }
}