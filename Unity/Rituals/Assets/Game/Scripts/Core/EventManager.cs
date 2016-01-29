// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventManager.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Core
{
    using Rituals.Physics.Events;

    using UnityEngine;

    public class EventManager : MonoBehaviour
    {
        #region Delegates

        public delegate void LookDirectionInputDelegate(object sender, LookDirectionInputEventArgs args);

        public delegate void MovementInputDelegate(object sender, MovementInputEventArgs args);

        #endregion

        #region Events

        public event MovementInputDelegate MovementInput;

        public event LookDirectionInputDelegate LookDirectionInput;

        #endregion

        #region Public Methods and Operators

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