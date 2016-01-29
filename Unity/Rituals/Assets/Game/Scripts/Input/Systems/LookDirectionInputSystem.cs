// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LookDirectionInputSystem.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Input.Systems
{
    using Rituals.Core;
    using Rituals.Physics.Events;

    using UnityEngine;

    public class LookDirectionInputSystem : RitualsBehaviour
    {
        #region Fields

        private Vector3 oldMousePosition;

        #endregion

        #region Methods

        private void Update()
        {
            // Compute delta.
            var newMousePosition = Input.mousePosition;
            var delta = newMousePosition - this.oldMousePosition;
            this.oldMousePosition = newMousePosition;

            // Notify listeners.
            this.EventManager.OnLookDirectionInput(this, new LookDirectionInputEventArgs { Delta = delta });
        }

        #endregion
    }
}