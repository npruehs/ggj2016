// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObstaclesChangedEventArgs.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Obstacles.Events
{
    using System;

    using UnityEngine;

    public class ObstaclesChangedEventArgs : EventArgs
    {
        #region Fields

        public GameObject Objective;

        public int Obstacles;

        #endregion
    }
}