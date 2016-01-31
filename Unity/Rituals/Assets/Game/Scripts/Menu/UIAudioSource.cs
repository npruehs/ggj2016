// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UIAudioSource.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Menu
{
    using UnityEngine;

    public class UIAudioSource : MonoBehaviour
    {
        #region Constants

        private static AudioSource instance;

        #endregion

        #region Fields

        public AudioClip Clip;

        #endregion

        #region Properties

        public static AudioSource Instance
        {
            get
            {
                if (instance == null)
                {
                    CreateInstance();
                }

                return instance;
            }
        }

        #endregion

        #region Public Methods and Operators

        public void Play()
        {
            Instance.PlayOneShot(this.Clip);
        }

        #endregion

        #region Methods

        private static void CreateInstance()
        {
            var go = new GameObject("UI Audio Source");
            instance = go.AddComponent<AudioSource>();
            DontDestroyOnLoad(go);
        }

        #endregion
    }
}