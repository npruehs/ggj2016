// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DestructionSystem.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Destruction.Systems
{
    using Rituals.Core;
    using Rituals.Destruction.Components;
    using Rituals.Interaction.Events;

    using UnityEngine;

    public class DestructionSystem : RitualsBehaviour
    {
        #region Methods

        protected override void AddListeners()
        {
            base.AddListeners();

            this.EventManager.InteractableUsed += this.OnInteractableUsed;
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();

            this.EventManager.InteractableUsed -= this.OnInteractableUsed;
        }

        private void OnInteractableUsed(object sender, InteractableUsedEventArgs args)
        {
            var destructibleComponent = args.GameObject.GetComponent<DestructibleComponent>();

            if (destructibleComponent == null)
            {
                return;
            }

            for (var i = 0; i < destructibleComponent.transform.childCount; ++i)
            {
                var child = destructibleComponent.transform.GetChild(i);
                var rigidBody = child.GetComponent<Rigidbody>();

                if (rigidBody == null)
                {
                    rigidBody = child.gameObject.AddComponent<Rigidbody>();
                    rigidBody.AddExplosionForce(
                        this.LevelSettings.DestructionForce,
                        this.transform.position,
                        this.LevelSettings.DestructionRadius);
                }
            }
        }

        #endregion
    }
}