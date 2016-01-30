// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RitualsBehaviour.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Core
{
    using Rituals.Player.Components;

    using UnityEngine;

    public abstract class RitualsBehaviour : MonoBehaviour
    {
        #region Properties

        protected EventManager EventManager { get; private set; }

        protected PlayerComponent Player { get; private set; }

        #endregion

        #region Methods

        protected virtual void AddListeners()
        {
        }

        protected virtual void DeInit()
        {
        }

        protected virtual void Init()
        {
            this.Player = FindObjectOfType<PlayerComponent>();

            if (this.Player != null)
            {
                this.OnPlayerAdded(this.Player);
            }
            else
            {
                Debug.LogError("No player found!");
            }
        }

        protected virtual void OnPlayerAdded(PlayerComponent player)
        {
        }

        protected virtual void RemoveListeners()
        {
        }

        private void OnDisable()
        {
            if (this.EventManager != null)
            {
                this.RemoveListeners();
            }

            this.DeInit();
        }

        private void OnEnable()
        {
            this.EventManager = FindObjectOfType<EventManager>();

            if (this.EventManager != null)
            {
                this.AddListeners();
            }

            this.Init();
        }

        #endregion
    }
}