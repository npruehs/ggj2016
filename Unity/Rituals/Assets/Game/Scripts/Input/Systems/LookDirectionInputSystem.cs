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
        #region Methods

        private void Update()
        {
            // Compute delta.
            var delta = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0.0f);

            // Notify listeners.
            this.EventManager.OnLookDirectionInput(this, new LookDirectionInputEventArgs { Delta = delta });
        }

        #endregion
    }
}