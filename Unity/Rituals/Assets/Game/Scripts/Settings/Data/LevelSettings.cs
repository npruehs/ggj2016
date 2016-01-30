// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LevelSettings.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Settings.Data
{
    using System.Collections.Generic;

    using Rituals.Audio.Data;

    using UnityEngine;

    public class LevelSettings : MonoBehaviour
    {
        #region Fields

        public float ChromaticAbberationStrength = 30.0f;

        public float DestructionForce = 300.0f;

        public float DestructionRadius = 100.0f;

        public float ItemSizePressureFactor = 1.0f;

        public List<GameObject> Objectives = new List<GameObject>();

        public float PlayerSpeed = 1;

        public float PressureAppliedPerSecond = 0.1f;

        public float PressureReducedPerObjective = 0.33f;

        public List<PressureObjectiveClip> SpeechClips = new List<PressureObjectiveClip>();

        public float SpeechDelay = 5.0f;

        public float TwirlStrength = 10.0f;

        #endregion
    }
}