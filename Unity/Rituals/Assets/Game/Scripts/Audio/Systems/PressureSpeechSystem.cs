// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PressureSpeechSystem.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Audio.Systems
{
    using System.Linq;

    using Rituals.Core;
    using Rituals.Objectives.Events;
    using Rituals.Pressure.Events;

    using UnityEngine;

    public class PressureSpeechSystem : RitualsBehaviour
    {
        #region Fields

        public AudioSource AudioSource;

        private GameObject currentObjective;

        private float currentPressure;

        private float timeSinceLastClip;

        #endregion

        #region Methods

        protected override void AddListeners()
        {
            base.AddListeners();

            this.EventManager.CurrentObjectiveChanged += this.OnCurrentObjectiveChanged;
            this.EventManager.PressureChanged += this.OnPressureChanged;
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();

            this.EventManager.CurrentObjectiveChanged -= this.OnCurrentObjectiveChanged;
            this.EventManager.PressureChanged -= this.OnPressureChanged;
        }

        private void OnCurrentObjectiveChanged(object sender, CurrentObjectiveChangedEventArgs args)
        {
            this.currentObjective = args.NewObjective;
        }

        private void OnPressureChanged(object sender, PressureChangedEventArgs args)
        {
            this.currentPressure = args.Pressure;
        }

        private void Update()
        {
            if (this.AudioSource.isPlaying)
            {
                return;
            }

            this.timeSinceLastClip += Time.deltaTime;

            if (this.timeSinceLastClip < this.LevelSettings.SpeechDelay)
            {
                return;
            }

            // Select next clip.
            var clips =
                this.LevelSettings.SpeechClips.Where(
                    clip =>
                        (clip.Objective == null || clip.Objective == this.currentObjective)
                        && clip.MinimumPressure <= this.currentPressure).ToList();

            if (clips.Count == 0)
            {
                return;
            }

            var random = Random.Range(0, clips.Count);
            var randomClip = clips[random];

            // Play clip.
            this.AudioSource.PlayOneShot(randomClip.Clip);

            // Reset timer.
            this.timeSinceLastClip = 0.0f;
        }

        #endregion
    }
}