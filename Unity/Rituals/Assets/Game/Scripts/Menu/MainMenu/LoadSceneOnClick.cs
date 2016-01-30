// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoadSceneOnClick.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Menu.MainMenu
{
    using UnityEngine;

    public class LoadSceneOnClick : ButtonClickHandler
    {
        #region Fields

        public string Scene;

        #endregion

        #region Methods

        protected override void OnButtonClicked()
        {
            Application.LoadLevel(this.Scene);
        }

        #endregion
    }
}