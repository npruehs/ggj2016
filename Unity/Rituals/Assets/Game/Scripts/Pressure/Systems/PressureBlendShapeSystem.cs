// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PressureBlendShapeSystem.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Pressure.Systems
{
    using Rituals.Core;
    using Rituals.Pressure.Components;
    using Rituals.Pressure.Events;

    public class PressureBlendShapeSystem : RitualsBehaviour
    {
        #region Fields

        private PressureBlendShapeComponent[] blendShapes;

        private float currentPressure;

        #endregion

        #region Methods

        protected override void AddListeners()
        {
            base.AddListeners();

            this.EventManager.PressureChanged += this.OnPressureChanged;
        }

        protected override void Init()
        {
            base.Init();

            this.blendShapes = FindObjectsOfType<PressureBlendShapeComponent>();
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();

            this.EventManager.PressureChanged -= this.OnPressureChanged;
        }

        private void OnPressureChanged(object sender, PressureChangedEventArgs args)
        {
            this.currentPressure = args.Pressure;
        }

        private void Update()
        {
            foreach (var blendShape in this.blendShapes)
            {
                blendShape.SkinnedMeshRenderer.SetBlendShapeWeight(
                    blendShape.BlendShape,
                    this.currentPressure * blendShape.MaximumWeight);
            }
        }

        #endregion
    }
}