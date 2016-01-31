// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DistanceIndicatorUISystem.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Objectives.Systems
{
    using Rituals.Core;
    using Rituals.Interaction.Components;
    using Rituals.Objectives.Events;
    using Rituals.Physics.Components;

    using UnityEngine;
    using UnityEngine.UI;

    public class DistanceIndicatorUISystem : RitualsBehaviour
    {
        #region Fields

        public Image Image;

        public Text Text;

        private GameObject currentObjective;

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///   Returns the angle between the specified vectors in radians.
        /// </summary>
        /// <param name="v">First vector.</param>
        /// <param name="w">Second vector.</param>
        /// <returns>Angle between the specified vectors in radians.</returns>
        public static float AngleBetween(Vector2 v, Vector2 w)
        {
            // http://www.euclideanspace.com/maths/algebra/vectors/angleBetween/index.htm
            return Mathf.Atan2(w.y, w.x) - Mathf.Atan2(v.y, v.x);
        }

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
                this.Image.enabled = false;
                return;
            }

            var interactableComponent = this.currentObjective.GetComponentInChildren<InteractableComponent>();
            var colliderComponent = interactableComponent.GetComponentInChildren<ColliderComponent>();
            var interactionCollider = colliderComponent.GetComponent<Collider>();
            var objectivePosition = interactionCollider.bounds.center;

            // Get distance to objective.
            var distanceVector = objectivePosition - this.Player.transform.position;
            var distance = distanceVector.magnitude;

            // Get angle between direction to objective and look direction.
            var direction = new Vector2(distanceVector.x, distanceVector.z).normalized;
            var lookDirection = new Vector2(this.Player.transform.forward.x, this.Player.transform.forward.z).normalized;

            var angle = AngleBetween(lookDirection, direction) * Mathf.Rad2Deg;

            this.Text.text = string.Format("{0:0.00}m", distance);
            this.Image.transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);
        }

        #endregion
    }
}