// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MovementInputEventArgs.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Physics.Events
{
    using System;

    using UnityEngine;

    public class MovementInputEventArgs : EventArgs
    {
        #region Fields

        public Vector3 Direction;

        #endregion
    }
}