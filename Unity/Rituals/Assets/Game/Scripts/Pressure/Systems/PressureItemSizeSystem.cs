// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PressureItemSizeSystem.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Pressure.Systems
{
    using Rituals.Core;
    using Rituals.Objectives.Events;
    using Rituals.Pressure.Events;

    using UnityEngine;

    public class PressureItemSizeSystem : RitualsBehaviour
    {
        #region Fields

        private GameObject currentObjective;

        #endregion

        #region Methods

        protected override void AddListeners()
        {
            base.AddListeners();

            this.EventManager.PressureChanged += this.OnPressureChanged;
            this.EventManager.CurrentObjectiveChanged += this.OnCurrentObjectiveChanged;
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();

            this.EventManager.PressureChanged -= this.OnPressureChanged;
            this.EventManager.CurrentObjectiveChanged -= this.OnCurrentObjectiveChanged;
        }

        private void OnCurrentObjectiveChanged(object sender, CurrentObjectiveChangedEventArgs args)
        {
            this.currentObjective = args.NewObjective;
        }

        private void OnPressureChanged(object sender, PressureChangedEventArgs args)
        {
            if (this.currentObjective != null)
            {
                this.currentObjective.transform.localScale = Vector3.one * (1 + args.Pressure);
            }
        }

        #endregion
    }
}