// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PressureBlendShapeComponent.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Pressure.Components
{
    using UnityEngine;

    public class PressureBlendShapeComponent : MonoBehaviour
    {
        #region Fields

        public int BlendShape;

        public SkinnedMeshRenderer SkinnedMeshRenderer;

        public float MaximumWeight = 100.0f;

        #endregion
    }
}