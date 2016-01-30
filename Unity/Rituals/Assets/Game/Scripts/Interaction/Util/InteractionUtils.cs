// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InteractionUtils.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Interaction.Util
{
    using Rituals.Physics.Components;

    using UnityEngine;

    public static class InteractionUtils
    {
        #region Public Methods and Operators

        public static bool IsInteractive(GameObject gameObject)
        {
            var colliderComponent = gameObject.GetComponentInChildren<ColliderComponent>();

            if (colliderComponent == null)
            {
                Debug.LogError(string.Format("{0} does not have an ColliderComponent attached.", gameObject.name));
                return false;
            }

            var objectiveCollider = colliderComponent.GetComponent<Collider>();

            if (objectiveCollider == null)
            {
                Debug.LogError(
                    string.Format(
                        "{0} does not have a Collider attached at the ColliderComponent object.",
                        gameObject.name));
                return false;
            }

            if (!objectiveCollider.isTrigger)
            {
                Debug.LogError(string.Format("{0} interaction collider is not set up as Trigger.", gameObject.name));
                return false;
            }

            return true;
        }

        #endregion
    }
}