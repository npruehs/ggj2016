// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventManager.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Core
{
    using Rituals.Input.Events;

    using UnityEngine;

    public class EventManager : MonoBehaviour
    {
        #region Delegates

        public delegate void InteractionInputDelegate(object sender, InteractionInputEventArgs args);

        public delegate void LookDirectionInputDelegate(object sender, LookDirectionInputEventArgs args);

        public delegate void MovementInputDelegate(object sender, MovementInputEventArgs args);

        #endregion

        #region Events

        public event MovementInputDelegate MovementInput;

        public event LookDirectionInputDelegate LookDirectionInput;

        public event InteractionInputDelegate InteractionInput;

        #endregion

        #region Public Methods and Operators

        public void OnInteractionInput(object sender, InteractionInputEventArgs args)
        {
            var handler = this.InteractionInput;
            if (handler != null)
            {
                handler(sender, args);
            }
        }

        public void OnLookDirectionInput(object sender, LookDirectionInputEventArgs args)
        {
            var handler = this.LookDirectionInput;
            if (handler != null)
            {
                handler(sender, args);
            }
        }

        public void OnMovementInput(object sender, MovementInputEventArgs args)
        {
            var handler = this.MovementInput;
            if (handler != null)
            {
                handler(sender, args);
            }
        }

        #endregion
    }
}