// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FlowInputSystem.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Input.Systems
{
    using System;

    using Rituals.Core;

    using UnityEngine;

    public class FlowInputSystem : RitualsBehaviour
    {
        #region Methods

        private void Update()
        {
            if (Input.GetButton("Cancel"))
            {
                this.EventManager.OnConcedeInput(this, EventArgs.Empty);
            }
        }

        #endregion
    }
}