// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InteractionSystem.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Interaction.Systems
{
    using System;
    using System.Diagnostics;

    using Rituals.Core;
    using Rituals.Input.Events;

    public class InteractionSystem : RitualsBehaviour
    {
        #region Methods

        protected override void AddListeners()
        {
            base.AddListeners();

            this.EventManager.InteractionInput += this.OnInteractionInput;
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();

            this.EventManager.InteractionInput -= this.OnInteractionInput;
        }

        private void OnInteractionInput(object sender, InteractionInputEventArgs args)
        {
            UnityEngine.Debug.Log("E");
        }

        #endregion
    }
}