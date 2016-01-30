// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PressureMusic.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Audio.Data
{
    using System;

    using UnityEngine;

    [Serializable]
    public class PressureMusic
    {
        #region Fields

        public AudioClip Clip;

        public float MinimumPressure;

        #endregion
    }
}