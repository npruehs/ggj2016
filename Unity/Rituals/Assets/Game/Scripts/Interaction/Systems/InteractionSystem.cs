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
    using Rituals.Physics.Events;

    using UnityEngine;

    public class InteractionSystem : RitualsBehaviour
    {
        #region Fields

        private readonly List<InteractableComponent> interactablesInRange = new List<InteractableComponent>();

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
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();

            this.EventManager.InteractionInput -= this.OnInteractionInput;
            this.EventManager.CollisionEntered -= this.OnCollisionEntered;
            this.EventManager.CollisionExited -= this.OnCollisionExited;
            this.EventManager.CurrentObjectiveChanged -= this.OnCurrentObjectiveChanged;
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
            this.SelectInteractable();
        }

        private void OnInteractionInput(object sender, InteractionInputEventArgs args)
        {
            this.UseInteractable();
        }

        private void SelectInteractable()
        {
            var interactable = this.interactablesInRange.FirstOrDefault(i => i.Enabled);

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

            // Play animation, if available.
            var interactionAnimationComponent = this.selectedInteractable.GetComponent<InteractionAnimationComponent>();
            if (interactionAnimationComponent != null && interactionAnimationComponent.Animiaton != null)
            {
                // Play.
                if (!string.IsNullOrEmpty(interactionAnimationComponent.AnimationName))
                {
                    interactionAnimationComponent.Animiaton.Play(interactionAnimationComponent.AnimationName);
                }
                else
                {
                    interactionAnimationComponent.Animiaton.Play();
                }

                // Set speed.
                if (!string.IsNullOrEmpty(interactionAnimationComponent.AnimationName))
                {
                    if (interactionAnimationComponent.Invert)
                    {
                        interactionAnimationComponent.Animiaton[interactionAnimationComponent.AnimationName].time =
                            interactionAnimationComponent.Animiaton[interactionAnimationComponent.AnimationName].length;
                        interactionAnimationComponent.Animiaton[interactionAnimationComponent.AnimationName].speed = -1;
                    }
                    else
                    {
                        interactionAnimationComponent.Animiaton[interactionAnimationComponent.AnimationName].time = 0;
                        interactionAnimationComponent.Animiaton[interactionAnimationComponent.AnimationName].speed = 1;
                    }
                }
            }

            // Blend shapes, if available.
            var interactionBlendShapeComponent =
                this.selectedInteractable.GetComponent<InteractionBlendShapeComponent>();
            if (interactionBlendShapeComponent != null)
            {
                interactionBlendShapeComponent.Play();
            }

            // Hide if necessary
            var interactionRendererComponent = this.selectedInteractable.GetComponent<InteractionRendererComponent>();
            if (interactionRendererComponent != null && interactionRendererComponent.Renderer != null
                && interactionRendererComponent.HideAfterInteraction)
            {
                foreach (var r in interactionRendererComponent.GetComponentsInChildren<Renderer>())
                {
                    r.enabled = false;
                }
            }

            // Notify listeners.
            this.EventManager.OnInteractableUsed(
                this,
                new InteractableUsedEventArgs { GameObject = this.selectedInteractable.gameObject });
        }

        #endregion
    }
}