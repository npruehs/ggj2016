// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PressureClip.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Audio.Data
{
    using System;

    using UnityEngine;

    [Serializable]
    public class PressureClip
    {
        #region Fields

        public AudioClip Clip;

        public float MinimumPressure;

        #endregion
    }
}