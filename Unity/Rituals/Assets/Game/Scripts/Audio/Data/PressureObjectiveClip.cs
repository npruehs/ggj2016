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

        #region Public Methods and Operators

        public override string ToString()
        {
            return string.Format(
                "Clip: {0}, MinimumPressure: {1}, Objective: {2}",
                this.Clip,
                this.MinimumPressure,
                this.Objective != null ? this.Objective.name : "none");
        }

        #endregion
    }
}