// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FadeOutImage.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Menu
{
    using UnityEngine;
    using UnityEngine.UI;

    public class FadeOutImage : MonoBehaviour
    {
        #region Fields

        public float AlphaPerSecond;

        public Image Image;

        #endregion

        #region Methods

        private void Update()
        {
            this.Image.color = new Color(
                this.Image.color.r,
                this.Image.color.g,
                this.Image.color.b,
                this.Image.color.a - this.AlphaPerSecond * Time.deltaTime);
        }

        #endregion
    }
}