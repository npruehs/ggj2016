// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InteractionInputSystem.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Input.Systems
{
    using Rituals.Core;
    using Rituals.Input.Events;

    using UnityEngine;

    public class InteractionInputSystem : RitualsBehaviour
    {
        #region Methods

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                this.EventManager.OnInteractionInput(this, new InteractionInputEventArgs());
            }
        }

        #endregion
    }
}