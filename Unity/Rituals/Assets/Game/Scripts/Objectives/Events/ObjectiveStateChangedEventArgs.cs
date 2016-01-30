// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectiveStateChangedEventArgs.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Objectives.Events
{
    using Rituals.Objectives.Data;

    using UnityEngine;

    public class ObjectiveStateChangedEventArgs
    {
        #region Fields

        public int CompletedObjectives;

        public GameObject Objective;

        public ObjectiveState State;

        public int TotalObjectives;

        #endregion
    }
}