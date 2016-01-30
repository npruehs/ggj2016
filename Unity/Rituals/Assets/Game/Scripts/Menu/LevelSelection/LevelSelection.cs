// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LevelSelection.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Menu.LevelSelection
{
    using Rituals.Menu.MainMenu;
    using Rituals.Progression.Storage;

    using UnityEngine;
    using UnityEngine.UI;

    public class LevelSelection : MonoBehaviour
    {
        #region Fields

        public GameObject LevelButtonPrefab;

        public int Levels;

        #endregion

        #region Methods

        private void Start()
        {
            for (int level = 1; level < this.Levels + 1; ++level)
            {
                var levelButton = Instantiate(this.LevelButtonPrefab);
                levelButton.transform.SetParent(this.transform);
                levelButton.transform.localScale = Vector3.one;

                var loadSceneOnClick = levelButton.GetComponent<LoadSceneOnClick>();
                if (loadSceneOnClick != null)
                {
                    loadSceneOnClick.Scene = string.Format("Level{0}", level);
                }

                var text = levelButton.GetComponentInChildren<Text>();
                if (text != null)
                {
                    text.text = string.Format("Level {0}", level);
                }

                var image = levelButton.GetComponentInChildren<Image>();
                if (image != null)
                {
                    image.enabled = ProgressionStorage.IsLevelComplete(level);
                }
            }
        }

        #endregion
    }
}