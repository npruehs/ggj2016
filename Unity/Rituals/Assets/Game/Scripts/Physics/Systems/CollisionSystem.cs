// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CollisionSystem.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Physics.Systems
{
    using Rituals.Core;
    using Rituals.Physics.Events;

    using UnityEngine;

    public class CollisionSystem : RitualsBehaviour
    {
        #region Public Methods and Operators

        public void OnTriggerEntered(Collider first, Collider second)
        {
            this.EventManager.OnCollisionEntered(this, new CollisionEventArgs { First = first, Second = second });
        }

        public void OnTriggerExited(Collider first, Collider second)
        {
            this.EventManager.OnCollisionExited(this, new CollisionEventArgs { First = first, Second = second });
        }

        #endregion
    }
}