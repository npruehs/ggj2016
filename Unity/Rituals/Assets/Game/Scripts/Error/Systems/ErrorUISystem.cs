// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ErrorUISystem.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Error.Systems
{
    using Rituals.Core;
    using Rituals.Error.Events;

    using UnityEngine;
    using UnityEngine.UI;

    public class ErrorUISystem : RitualsBehaviour
    {
        #region Fields

        public float ErrorDuration = 1.0f;

        public Text Text;

        private float errorDurationRemaining;

        #endregion

        #region Methods

        protected override void AddListeners()
        {
            base.AddListeners();

            this.EventManager.Error += this.OnError;
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();

            this.EventManager.Error -= this.OnError;
        }

        private void OnError(object sender, ErrorEventArgs args)
        {
            this.Text.text = args.ErrorMessage;
            this.errorDurationRemaining = this.ErrorDuration;
        }

        private void Update()
        {
            this.errorDurationRemaining -= Time.deltaTime;

            var alpha = this.errorDurationRemaining / this.ErrorDuration;
            this.Text.color = new Color(this.Text.color.r, this.Text.color.g, this.Text.color.b, alpha);
        }

        #endregion
    }
}