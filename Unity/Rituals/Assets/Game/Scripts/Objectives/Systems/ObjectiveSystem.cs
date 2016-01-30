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
    using Rituals.Interaction.Events;
    using Rituals.Objectives.Data;
    using Rituals.Objectives.Events;

    using UnityEngine;

    public class ObjectiveSystem : RitualsBehaviour
    {
        #region Fields

        private readonly List<Objective> objectives = new List<Objective>();

        public GameObject[] Objectives;

        private Objective currentObjective;

        #endregion

        #region Methods

        protected override void AddListeners()
        {
            base.AddListeners();

            this.EventManager.InteractableUsed += this.OnInteractableUsed;
        }

        protected override void Init()
        {
            base.Init();

            foreach (var objective in this.Objectives)
            {
                this.objectives.Add(new Objective { GameObject = objective, State = ObjectiveState.Inactive });

                Debug.Log("Objective added: {0}.", objective);
            }

            this.currentObjective = this.objectives.FirstOrDefault();

            if (this.currentObjective != null)
            {
                this.SetObjectiveState(this.currentObjective, ObjectiveState.Active);
            }
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

            if (this.currentObjective.GameObject == args.GameObject)
            {
                // Finish objective.
                this.SetObjectiveState(this.currentObjective, ObjectiveState.Complete);

                // Select next objective.
                var nextObjective = this.objectives.FirstOrDefault(obj => obj.State != ObjectiveState.Complete);

                if (nextObjective != null)
                {
                    this.SetObjectiveState(nextObjective, ObjectiveState.Active);
                }
                else
                {
                    this.currentObjective = null;
                }
            }
        }

        private void SetObjectiveState(Objective objective, ObjectiveState state)
        {
            objective.State = state;

            if (objective.State == ObjectiveState.Active)
            {
                this.currentObjective = objective;
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