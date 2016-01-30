// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LevelSettings.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Settings.Data
{
    using UnityEngine;

    public class LevelSettings : MonoBehaviour
    {
        #region Fields

        public GameObject[] Objectives;

        public float PlayerSpeed = 1;

        public float PressureAppliedPerSecond = 0.1f;

        public float PressureReducedPerObjective = 0.33f;

        #endregion
    }
}