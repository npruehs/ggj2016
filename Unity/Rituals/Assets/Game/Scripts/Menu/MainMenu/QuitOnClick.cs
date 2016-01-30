// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuitOnClick.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Menu.MainMenu
{
    using UnityEngine;
    using UnityEngine.UI;

    public class QuitOnClick : MonoBehaviour
    {
        #region Fields

        public Button Button;

        #endregion

        #region Methods

        private void OnButtonClicked()
        {
            Application.Quit();
        }

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