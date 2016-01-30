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

    public class InteractionSystem : RitualsBehaviour
    {
        #region Fields

        private InteractableComponent selectedInteractable;

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

            // Notify listeners.
            this.EventManager.OnInteractableEnteredRange(
                this,
                new InteractableEnteredRangeEventArgs { GameObject = interactable.gameObject });

            // Set reference.
            this.SelectInteractable(interactable);
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

            // Notify listeners.
            this.EventManager.OnInteractableLeftRange(
                this,
                new InteractableLeftRangeEventArgs { GameObject = interactable.gameObject });

            if (this.selectedInteractable == interactable.gameObject)
            {
                // Reset reference.
                this.SelectInteractable(null);
            }
        }

        private void OnInteractionInput(object sender, InteractionInputEventArgs args)
        {
            this.UseInteractable();
        }

        private void SelectInteractable(InteractableComponent interactable)
        {
            this.selectedInteractable = interactable;

            // Notify listeners.
            this.EventManager.OnSelectedInteractableChanged(
                this,
                new SelectedInteractableChangedEventArgs { Interactable = this.selectedInteractable.gameObject });

            // Check if auto.
            if (this.selectedInteractable.Auto)
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

            this.EventManager.OnInteractableUsed(
                this,
                new InteractableUsedEventArgs { GameObject = this.selectedInteractable.gameObject });
        }

        #endregion
    }
}