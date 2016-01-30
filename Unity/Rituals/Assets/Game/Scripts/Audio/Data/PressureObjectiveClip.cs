// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PressureObjectiveClip.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Audio.Data
{
    using System;

    using UnityEngine;

    [Serializable]
    public class PressureObjectiveClip
    {
        #region Fields

        public AudioClip Clip;

        public float MinimumPressure;

        public GameObject Objective;

        #endregion
    }
}