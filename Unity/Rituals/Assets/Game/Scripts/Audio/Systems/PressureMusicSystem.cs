// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PressureMusicSystem.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Audio.Systems
{
    using System.Linq;

    using Rituals.Audio.Data;
    using Rituals.Core;
    using Rituals.Pressure.Events;

    using UnityEngine;

    public class PressureMusicSystem : RitualsBehaviour
    {
        #region Fields

        public AudioSource AudioSource;

        public PressureClip[] Clips;

        #endregion

        #region Methods

        protected override void AddListeners()
        {
            base.AddListeners();

            this.EventManager.PressureChanged += this.OnPressureChanged;
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();

            this.EventManager.PressureChanged -= this.OnPressureChanged;
        }

        private void OnPressureChanged(object sender, PressureChangedEventArgs args)
        {
            if (!this.AudioSource.isPlaying)
            {
                // Select clip.
                var clip =
                    this.Clips.OrderByDescending(c => c.MinimumPressure)
                        .FirstOrDefault(c => c.MinimumPressure <= args.Pressure);

                if (clip == null)
                {
                    Debug.LogWarning(
                        string.Format("No feasible music clip found for pressure level: {0}", args.Pressure));
                    return;
                }

                this.AudioSource.PlayOneShot(clip.Clip);
            }
        }

        #endregion
    }
}