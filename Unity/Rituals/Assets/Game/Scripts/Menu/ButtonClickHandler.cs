// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ButtonClickHandler.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Menu
{
    using UnityEngine;
    using UnityEngine.UI;

    public abstract class ButtonClickHandler : MonoBehaviour
    {
        #region Fields

        public Button Button;

        #endregion

        #region Methods

        protected abstract void OnButtonClicked();

        private void OnDisable()
        {
            if (this.Button != null)
            {
                this.Button.onClick.RemoveListener(this.OnButtonClicked);
            }
        }

        private void OnEnable()
        {
            if (this.Button != null)
            {
                this.Button.onClick.AddListener(this.OnButtonClicked);
            }
        }

        #endregion
    }
}