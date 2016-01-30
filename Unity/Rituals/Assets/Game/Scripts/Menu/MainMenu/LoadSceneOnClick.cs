// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoadSceneOnClick.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Menu.MainMenu
{
    using UnityEngine;
    using UnityEngine.UI;

    public class LoadSceneOnClick : MonoBehaviour
    {
        #region Fields

        public Button Button;

        public string Scene;

        #endregion

        #region Methods

        private void OnButtonClicked()
        {
            Application.LoadLevel(this.Scene);
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