// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlayerLookDirectionSystem.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Physics.Systems
{
    using Rituals.Core;
    using Rituals.Input.Events;
    using Rituals.Settings.Storage;

    using UnityEngine;

    public class PlayerLookDirectionSystem : RitualsBehaviour
    {
        #region Fields

        public bool HideCursor;

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

        protected override void DeInit()
        {
            base.DeInit();

            if (this.HideCursor)
            {
                Cursor.visible = true;
            }
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();

            this.EventManager.LookDirectionInput -= this.OnLookDirectionInput;
        }

        private void OnLookDirectionInput(object sender, LookDirectionInputEventArgs args)
        {
            if (this.Player == null)
            {
                return;
            }

            var cameraEuler = this.Player.PlayerCamera.transform.localEulerAngles
                              + new Vector3(
                                  -args.Delta.y * this.Sensitivity * SettingsStorage.MouseSensitivity,
                                  0.0f,
                                  0.0f);
            this.Player.PlayerCamera.transform.localRotation = Quaternion.Euler(cameraEuler);

            var playerEuler = this.Player.transform.localEulerAngles
                              + new Vector3(
                                  0.0f,
                                  args.Delta.x * this.Sensitivity * SettingsStorage.MouseSensitivity,
                                  0.0f);
            this.Player.transform.localRotation = Quaternion.Euler(playerEuler);
        }

        #endregion
    }
}