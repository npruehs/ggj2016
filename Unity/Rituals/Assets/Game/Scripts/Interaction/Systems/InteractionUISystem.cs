// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InteractionUISystem.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Interaction.Systems
{
    using Rituals.Core;
    using Rituals.Interaction.Events;

    using UnityEngine.UI;

    public class InteractionUISystem : RitualsBehaviour
    {
        #region Fields

        public Text InteractionText;

        #endregion

        #region Methods

        protected override void AddListeners()
        {
            base.AddListeners();

            this.EventManager.InteractableEnteredRange += this.OnInteractableEnteredRange;
            this.EventManager.InteractableLeftRange += this.OnInteractableLeftRange;
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();

            this.EventManager.InteractableEnteredRange -= this.OnInteractableEnteredRange;
            this.EventManager.InteractableLeftRange -= this.OnInteractableLeftRange;
        }

        private void OnInteractableEnteredRange(object sender, InteractableEnteredRangeEventArgs args)
        {
            this.InteractionText.text = string.Format("Use {0}", args.GameObject.name);
        }

        private void OnInteractableLeftRange(object sender, InteractableLeftRangeEventArgs args)
        {
            this.InteractionText.text = string.Empty;
        }

        #endregion
    }
}