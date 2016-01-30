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

        public Image Image;

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
            this.currentObjective = args.NewObjective;
        }

        private void Update()
        {
            if (this.currentObjective == null)
            {
                this.Text.text = string.Empty;
                return;
            }

            // Get distance to objective.
            var distanceVector = this.Player.transform.position - this.currentObjective.transform.position;
            var distance = distanceVector.magnitude;

            // Get angle between direction to objective and look direction.
            var direction = new Vector2(distanceVector.x, distanceVector.z);
            var lookDirection = new Vector2(this.Player.transform.forward.x, this.Player.transform.forward.z);

            var angle = Vector2.Angle(lookDirection, direction);

            this.Text.text = string.Format("Distance: {0:0.00}m", distance);
            this.Image.transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);
        }

        #endregion
    }
}