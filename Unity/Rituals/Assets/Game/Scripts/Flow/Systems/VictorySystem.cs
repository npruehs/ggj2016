// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VictorySystem.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Flow.Systems
{
    using Rituals.Core;
    using Rituals.Flow.Components;
    using Rituals.Objectives.Events;
    using Rituals.Physics.Events;

    using UnityEngine;

    public class VictorySystem : RitualsBehaviour
    {
        #region Fields

        public Collider PlayerInteractionCollider;

        private bool mayLeave;

        #endregion

        #region Methods

        protected override void AddListeners()
        {
            base.AddListeners();

            this.EventManager.CollisionEntered += this.OnCollisionEntered;
            this.EventManager.ObjectiveStateChanged += this.OnObjectiveStateChanged;
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();

            this.EventManager.CollisionEntered -= this.OnCollisionEntered;
            this.EventManager.ObjectiveStateChanged -= this.OnObjectiveStateChanged;
        }

        private void OnCollisionEntered(object sender, CollisionEventArgs args)
        {
            if (!this.mayLeave)
            {
                return;
            }

            if (args.First != this.PlayerInteractionCollider)
            {
                return;
            }

            var exit = args.Second.GetComponentInParent<ExitComponent>();

            if (exit == null)
            {
                return;
            }

            // Victory!
            Application.LoadLevel("MainMenu");
        }

        private void OnObjectiveStateChanged(object sender, ObjectiveStateChangedEventArgs args)
        {
            this.mayLeave = args.CompletedObjectives == args.TotalObjectives;
        }

        #endregion
    }
}