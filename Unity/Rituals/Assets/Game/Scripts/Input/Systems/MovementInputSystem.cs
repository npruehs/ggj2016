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
            if (Input.GetKey(KeyCode.W))
            {
                this.EventManager.OnMovementInput(this, new MovementInputEventArgs { Direction = Vector3.forward });
            }
            if (Input.GetKey(KeyCode.S))
            {
                this.EventManager.OnMovementInput(this, new MovementInputEventArgs { Direction = Vector3.back });
            }
            if (Input.GetKey(KeyCode.A))
            {
                this.EventManager.OnMovementInput(this, new MovementInputEventArgs { Direction = Vector3.left });
            }
            if (Input.GetKey(KeyCode.D))
            {
                this.EventManager.OnMovementInput(this, new MovementInputEventArgs { Direction = Vector3.right });
            }
        }

        #endregion
    }
}