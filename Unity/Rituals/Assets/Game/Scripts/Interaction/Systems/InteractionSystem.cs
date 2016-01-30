// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InteractionSystem.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Interaction.Systems
{
    using Rituals.Core;
    using Rituals.Input.Events;
    using Rituals.Interaction.Components;
    using Rituals.Interaction.Events;
    using Rituals.Physics.Events;

    using UnityEngine;

    public class InteractionSystem : RitualsBehaviour
    {
        #region Fields

        public Collider PlayerInteractionCollider;

        private GameObject selectedInteractable;

        #endregion

        #region Methods

        protected override void AddListeners()
        {
            base.AddListeners();

            this.EventManager.InteractionInput += this.OnInteractionInput;
            this.EventManager.CollisionEntered += this.OnCollisionEntered;
            this.EventManager.CollisionExited += this.OnCollisionExited;
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();

            this.EventManager.InteractionInput -= this.OnInteractionInput;
            this.EventManager.CollisionEntered -= this.OnCollisionEntered;
            this.EventManager.CollisionExited -= this.OnCollisionExited;
        }

        private void OnCollisionEntered(object sender, CollisionEventArgs args)
        {
            if (args.First != this.PlayerInteractionCollider)
            {
                return;
            }

            var interactable = args.Second.GetComponentInParent<InteractableComponent>();

            if (interactable == null)
            {
                return;
            }

            // Notify listeners.
            this.EventManager.OnInteractableEnteredRange(
                this,
                new InteractableEnteredRangeEventArgs { GameObject = interactable.gameObject });

            // Set reference.
            this.selectedInteractable = interactable.gameObject;
        }

        private void OnCollisionExited(object sender, CollisionEventArgs args)
        {
            if (args.First != this.PlayerInteractionCollider)
            {
                return;
            }

            var interactable = args.Second.GetComponentInParent<InteractableComponent>();

            if (interactable == null)
            {
                return;
            }

            // Notify listeners.
            this.EventManager.OnInteractableLeftRange(
                this,
                new InteractableLeftRangeEventArgs { GameObject = interactable.gameObject });

            // Reset reference.
            this.selectedInteractable = null;
        }

        private void OnInteractionInput(object sender, InteractionInputEventArgs args)
        {
            if (this.selectedInteractable == null)
            {
                return;
            }

            this.EventManager.OnInteractableUsed(
                this,
                new InteractableUsedEventArgs { GameObject = this.selectedInteractable });
        }

        #endregion
    }
}