// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CollisionEventArgs.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Physics.Events
{
    using System;

    using UnityEngine;

    public class CollisionEventArgs : EventArgs
    {
        #region Fields

        public Collider First;

        public Collider Second;

        #endregion
    }
}