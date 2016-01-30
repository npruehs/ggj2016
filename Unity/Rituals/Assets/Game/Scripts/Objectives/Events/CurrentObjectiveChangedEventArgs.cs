// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CurrentObjectiveChangedEventArgs.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Objectives.Events
{
    using System;

    using UnityEngine;

    public class CurrentObjectiveChangedEventArgs : EventArgs
    {
        #region Fields

        public GameObject Objective;

        #endregion
    }
}