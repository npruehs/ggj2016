// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReturnToMainMenuSystem.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Flow.Systems
{
    using System;

    using Rituals.Core;

    using UnityEngine;

    public class ReturnToMainMenuSystem : RitualsBehaviour
    {
        #region Methods

        protected override void AddListeners()
        {
            base.AddListeners();

            this.EventManager.ConcedeInput += this.OnConcedeInput;
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();

            this.EventManager.ConcedeInput -= this.OnConcedeInput;
        }

        private void OnConcedeInput(object sender, EventArgs args)
        {
            Cursor.visible = true;
            Application.LoadLevel("MainMenu");
        }

        #endregion
    }
}