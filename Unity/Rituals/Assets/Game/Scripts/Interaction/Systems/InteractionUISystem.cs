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

            this.EventManager.SelectedInteractableChanged += this.OnSelectedInteractableChanged;
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();

            this.EventManager.SelectedInteractableChanged -= this.OnSelectedInteractableChanged;
        }

        private void OnSelectedInteractableChanged(object sender, SelectedInteractableChangedEventArgs args)
        {
            this.InteractionText.text = args.Interactable != null
                ? string.Format("[E] Use {0}", args.Interactable.name)
                : string.Empty;
        }

        #endregion
    }
}