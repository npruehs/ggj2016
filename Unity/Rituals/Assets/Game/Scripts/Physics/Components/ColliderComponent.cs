// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColliderComponent.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Physics.Components
{
    using Rituals.Physics.Systems;

    using UnityEngine;

    public class ColliderComponent : MonoBehaviour
    {
        #region Fields

        private CollisionSystem collisionSystem;

        private Collider ownCollider;

        #endregion

        #region Methods

        private void Awake()
        {
            this.collisionSystem = FindObjectOfType<CollisionSystem>();
            this.ownCollider = this.GetComponent<Collider>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (this.collisionSystem == null || this.ownCollider == null)
            {
                return;
            }

            this.collisionSystem.OnTriggerEntered(this.ownCollider, other);
        }

        private void OnTriggerExit(Collider other)
        {
            if (this.collisionSystem == null || this.ownCollider == null)
            {
                return;
            }

            this.collisionSystem.OnTriggerExited(this.ownCollider, other);
        }

        #endregion
    }
}