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

        public delegate void MovePlayerDelegate(object sender, MovePlayerEventArgs args);

        #endregion

        #region Events

        public event MovePlayerDelegate MovePlayer;

        #endregion

        #region Public Methods and Operators

        public void OnApplyForce(object sender, MovePlayerEventArgs args)
        {
            var handler = this.MovePlayer;
            if (handler != null)
            {
                handler(sender, args);
            }
        }

        #endregion
    }
}