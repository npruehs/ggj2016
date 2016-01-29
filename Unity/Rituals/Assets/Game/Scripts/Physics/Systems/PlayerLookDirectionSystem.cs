// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlayerLookDirectionSystem.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Physics.Systems
{
    using Rituals.Core;
    using Rituals.Input.Events;

    using UnityEngine;

    public class PlayerLookDirectionSystem : RitualsBehaviour
    {
        #region Fields

        public Camera Camera;

        public bool HideCursor;

        public GameObject Player;

        public float Sensitivity;

        #endregion

        #region Methods

        protected override void AddListeners()
        {
            base.AddListeners();

            this.EventManager.LookDirectionInput += this.OnLookDirectionInput;
        }

        protected override void Init()
        {
            base.Init();

            if (this.HideCursor)
            {
                Cursor.visible = false;
            }
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();

            this.EventManager.LookDirectionInput -= this.OnLookDirectionInput;
        }

        private void OnLookDirectionInput(object sender, LookDirectionInputEventArgs args)
        {
            var cameraEuler = this.Camera.transform.localEulerAngles
                              + new Vector3(-args.Delta.y * this.Sensitivity, 0.0f, 0.0f);
            this.Camera.transform.localRotation = Quaternion.Euler(cameraEuler);

            var playerEuler = this.Player.transform.localEulerAngles
                              + new Vector3(0.0f, args.Delta.x * this.Sensitivity, 0.0f);
            this.Player.transform.localRotation = Quaternion.Euler(playerEuler);
        }

        #endregion
    }
}