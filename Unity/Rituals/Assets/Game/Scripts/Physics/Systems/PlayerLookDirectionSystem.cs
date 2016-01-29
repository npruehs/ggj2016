// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlayerLookDirectionSystem.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Physics.Systems
{
    using Rituals.Core;
    using Rituals.Physics.Events;

    using UnityEngine;

    public class PlayerLookDirectionSystem : RitualsBehaviour
    {
        #region Fields

        public Camera Camera;

        #endregion

        #region Methods

        protected override void AddListeners()
        {
            base.AddListeners();

            this.EventManager.LookDirectionInput += this.OnLookDirectionInput;
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();

            this.EventManager.LookDirectionInput -= this.OnLookDirectionInput;
        }

        private void OnLookDirectionInput(object sender, LookDirectionInputEventArgs args)
        {
            this.Camera.transform.localRotation =
                Quaternion.Euler(this.Camera.transform.localEulerAngles + new Vector3(-args.Delta.y, args.Delta.x, 0.0f));
        }

        #endregion
    }
}