// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlayerComponent.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Player.Components
{
    using UnityEngine;

    using UnityStandardAssets.ImageEffects;

    public class PlayerComponent : MonoBehaviour
    {
        #region Fields

        public Camera PlayerCamera;

        public Collider PlayerInteractionCollider;

        public Twirl Twirl;

        public VignetteAndChromaticAberration VignetteAndChromaticAberration;

        #endregion
    }
}