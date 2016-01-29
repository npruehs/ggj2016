// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InteractionSystem.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Interaction.Systems
{
    using Rituals.Core;
    using Rituals.Input.Events;
    using Rituals.Physics.Events;

    using UnityEngine;

    public class InteractionSystem : RitualsBehaviour
    {
        #region Fields

        public Collider PlayerInteractionCollider;

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
            if (args.First.gameObject.tag != "Player")
            {
                return;
            }

            Debug.Log("Enter " + args.Second);
        }

        private void OnCollisionExited(object sender, CollisionEventArgs args)
        {
            if (args.First.gameObject.tag != "Player")
            {
                return;
            }

            Debug.Log("Exit " + args.Second);
        }

        private void OnInteractionInput(object sender, InteractionInputEventArgs args)
        {
            Debug.Log("E");
        }

        #endregion
    }
}