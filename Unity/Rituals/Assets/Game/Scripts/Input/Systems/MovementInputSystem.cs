// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MovementInputSystem.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Input.Systems
{
    using Rituals.Core;
    using Rituals.Input.Events;

    using UnityEngine;

    public class MovementInputSystem : RitualsBehaviour
    {
        #region Methods

        private void Update()
        {
            this.EventManager.OnMovementInput(
                this,
                new MovementInputEventArgs
                {
                    Direction = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"))
                });
        }

        #endregion
    }
}