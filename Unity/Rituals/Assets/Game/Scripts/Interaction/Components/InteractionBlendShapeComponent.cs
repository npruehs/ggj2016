// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InteractionBlendShapeComponent.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Interaction.Components
{
    using UnityEngine;

    public class InteractionBlendShapeComponent : MonoBehaviour
    {
        #region Fields

        public int BlendShape;

        public SkinnedMeshRenderer SkinnedMeshRenderer;

        public float Speed;

        private bool playing;

        #endregion

        #region Public Methods and Operators

        public void Play()
        {
            this.playing = true;
        }

        #endregion

        #region Methods

        private void Update()
        {
            if (!this.playing)
            {
                return;
            }

            var currentWeight = this.SkinnedMeshRenderer.GetBlendShapeWeight(this.BlendShape);
            var newWeight = this.Speed * Time.deltaTime;
            this.SkinnedMeshRenderer.SetBlendShapeWeight(this.BlendShape, newWeight);
        }

        #endregion
    }
}