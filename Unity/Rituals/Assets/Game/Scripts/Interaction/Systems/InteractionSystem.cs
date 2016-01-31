// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InteractionSystem.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Interaction.Systems
{
    using System.Collections.Generic;
    using System.Linq;

    using Rituals.Core;
    using Rituals.Input.Events;
    using Rituals.Interaction.Components;
    using Rituals.Interaction.Events;
    using Rituals.Objectives.Events;
    using Rituals.Obstacles.Events;
    using Rituals.Physics.Events;

    using UnityEngine;

    public class InteractionSystem : RitualsBehaviour
    {
        #region Fields

        private readonly List<InteractableComponent> interactablesInRange = new List<InteractableComponent>();

        private GameObject currentObjective;

        private InteractableComponent selectedInteractable;

        #endregion

        #region Methods

        protected override void AddListeners()
        {
            base.AddListeners();

            this.EventManager.InteractionInput += this.OnInteractionInput;
            this.EventManager.CollisionEntered += this.OnCollisionEntered;
            this.EventManager.CollisionExited += this.OnCollisionExited;
            this.EventManager.CurrentObjectiveChanged += this.OnCurrentObjectiveChanged;
            this.EventManager.ObstaclesChanged += this.OnObstaclesChanged;
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();

            this.EventManager.InteractionInput -= this.OnInteractionInput;
            this.EventManager.CollisionEntered -= this.OnCollisionEntered;
            this.EventManager.CollisionExited -= this.OnCollisionExited;
            this.EventManager.CurrentObjectiveChanged -= this.OnCurrentObjectiveChanged;
            this.EventManager.ObstaclesChanged -= this.OnObstaclesChanged;
        }

        private void OnCollisionEntered(object sender, CollisionEventArgs args)
        {
            if (this.Player == null)
            {
                return;
            }

            if (args.First != this.Player.PlayerInteractionCollider)
            {
                return;
            }

            var interactable = args.Second.GetComponentInParent<InteractableComponent>();

            if (interactable == null)
            {
                return;
            }

            this.interactablesInRange.Add(interactable);

            // Notify listeners.
            this.EventManager.OnInteractableEnteredRange(
                this,
                new InteractableEnteredRangeEventArgs { GameObject = interactable.gameObject });

            // Update selection.
            this.SelectInteractable();
        }

        private void OnCollisionExited(object sender, CollisionEventArgs args)
        {
            if (this.Player == null)
            {
                return;
            }

            if (args.First != this.Player.PlayerInteractionCollider)
            {
                return;
            }

            var interactable = args.Second.GetComponentInParent<InteractableComponent>();

            if (interactable == null)
            {
                return;
            }

            this.interactablesInRange.Remove(interactable);

            // Notify listeners.
            this.EventManager.OnInteractableLeftRange(
                this,
                new InteractableLeftRangeEventArgs { GameObject = interactable.gameObject });

            // Update selection.
            this.SelectInteractable();
        }

        private void OnCurrentObjectiveChanged(object sender, CurrentObjectiveChangedEventArgs args)
        {
            this.currentObjective = args.NewObjective;

            this.SelectInteractable();
        }

        private void OnInteractionInput(object sender, InteractionInputEventArgs args)
        {
            this.UseInteractable();
        }

        private void OnObstaclesChanged(object sender, ObstaclesChangedEventArgs args)
        {
            this.SelectInteractable();
        }

        private void SelectInteractable()
        {
            // Prefer obstacles.
            var interactable =
                this.interactablesInRange.FirstOrDefault(
                    i => i != null && i.Enabled && this.LevelSettings.Obstacles.Any(o => o.Obstacle == i.gameObject));

            // Then, prefer current objective.
            if (interactable == null)
            {
                interactable =
                    this.interactablesInRange.FirstOrDefault(
                        i => i != null && i.Enabled && i.gameObject == this.currentObjective);
            }

            // Then, pick any.
            if (interactable == null)
            {
                interactable = this.interactablesInRange.FirstOrDefault(i => i.Enabled);
            }

            this.selectedInteractable = interactable;

            // Notify listeners.
            this.EventManager.OnSelectedInteractableChanged(
                this,
                new SelectedInteractableChangedEventArgs { Interactable = this.selectedInteractable });

            // Check if auto.
            if (this.selectedInteractable != null && this.selectedInteractable.Auto)
            {
                this.UseInteractable();
            }
        }

        private void UseInteractable()
        {
            if (this.selectedInteractable == null)
            {
                return;
            }

            // Notify listeners.
            this.EventManager.OnInteractableUsed(
                this,
                new InteractableUsedEventArgs { GameObject = this.selectedInteractable.gameObject });
        }

        #endregion
    }
}