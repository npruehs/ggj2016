// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlayerPhysicsSystem.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Physics.Systems
{
    using Rituals.Core;
    using Rituals.Physics.Events;

    using UnityEngine;

    public class PlayerPhysicsSystem : RitualsBehaviour
    {
        #region Fields

        public GameObject Player;

        public float Speed = 1;

        #endregion

        #region Methods

        protected override void AddListeners()
        {
            this.EventManager.MovePlayer += this.OnMovePlayer;
        }

        protected override void RemoveListeners()
        {
            this.EventManager.MovePlayer -= this.OnMovePlayer;
        }

        private void OnMovePlayer(object sender, MovePlayerEventArgs args)
        {
            this.Player.transform.position += args.Direction * Time.deltaTime * this.Speed;
        }

        #endregion
    }
}