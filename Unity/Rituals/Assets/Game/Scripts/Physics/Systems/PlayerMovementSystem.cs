// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlayerMovementSystem.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Physics.Systems
{
    using Rituals.Core;
    using Rituals.Input.Events;

    using UnityEngine;

    public class PlayerMovementSystem : RitualsBehaviour
    {
        #region Fields

        public GameObject Player;

        public float Speed = 1;

        #endregion

        #region Methods

        protected override void AddListeners()
        {
            base.AddListeners();

            this.EventManager.MovementInput += this.OnMovementInput;
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();

            this.EventManager.MovementInput -= this.OnMovementInput;
        }

        private void OnMovementInput(object sender, MovementInputEventArgs args)
        {
            this.Player.transform.position += this.Player.transform.TransformDirection(args.Direction) * Time.deltaTime
                                              * this.Speed;
        }

        #endregion
    }
}