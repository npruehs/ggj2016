﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuitOnClick.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Menu.MainMenu
{
    using UnityEngine;

    public class QuitOnClick : ButtonClickHandler
    {
        #region Methods

        protected override void OnButtonClicked()
        {
            Application.Quit();
        }

        #endregion
    }
}