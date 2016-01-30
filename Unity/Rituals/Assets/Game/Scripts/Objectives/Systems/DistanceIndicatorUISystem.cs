// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DistanceIndicatorUISystem.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Objectives.Systems
{
    using Rituals.Core;
    using Rituals.Objectives.Events;

    using UnityEngine;
    using UnityEngine.UI;

    public class DistanceIndicatorUISystem : RitualsBehaviour
    {
        #region Fields

        public Text Text;

        private GameObject currentObjective;

        #endregion

        #region Methods

        protected override void AddListeners()
        {
            base.AddListeners();

            this.EventManager.CurrentObjectiveChanged += this.OnCurrentObjectiveChanged;
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();

            this.EventManager.CurrentObjectiveChanged -= this.OnCurrentObjectiveChanged;
        }

        private void OnCurrentObjectiveChanged(object sender, CurrentObjectiveChangedEventArgs args)
        {
            this.currentObjective = args.Objective;
        }

        private void Update()
        {
            if (this.currentObjective == null)
            {
                this.Text.text = string.Empty;
                return;
            }

            var distanceVector = this.Player.transform.position - this.currentObjective.transform.position;
            var distance = distanceVector.magnitude;

            this.Text.text = string.Format("Distance: {0:0.00}m", distance);
        }

        #endregion
    }
}