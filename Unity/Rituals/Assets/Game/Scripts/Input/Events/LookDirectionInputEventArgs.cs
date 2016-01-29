// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LookDirectionInputEventArgs.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Input.Events
{
    using System;

    using UnityEngine;

    public class LookDirectionInputEventArgs : EventArgs
    {
        #region Fields

        public Vector3 Delta;

        #endregion
    }
}