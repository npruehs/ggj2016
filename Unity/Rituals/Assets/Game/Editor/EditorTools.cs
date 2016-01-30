// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EditorTools.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Editor
{
    using System.Linq;

    using Rituals.Flow.Components;
    using Rituals.Interaction.Components;
    using Rituals.Obstacles.Data;
    using Rituals.Physics.Components;
    using Rituals.Settings.Data;

    using UnityEditor;

    using UnityEngine;

    public class EditorTools
    {
        #region Constants

        private const string InteractionColliderAssetName = "Interaction Collider";

        #endregion

        #region Public Methods and Operators

        [MenuItem("OCD/Make Exit")]
        public static void MakeExit()
        {
            var newExit = Selection.activeGameObject;

            if (newExit == null)
            {
                return;
            }

            // Add exit component.
            if (newExit.GetComponent<ExitComponent>() == null)
            {
                newExit.AddComponent<ExitComponent>();
            }

            // Add interaction collider.
            MakeInteractable(newExit);
        }

        [MenuItem("OCD/Make Objective")]
        public static void MakeObjective()
        {
            var newObjective = Selection.activeGameObject;

            if (newObjective == null)
            {
                return;
            }

            LevelSettings levelSettings = Object.FindObjectOfType<LevelSettings>();

            if (levelSettings == null)
            {
                EditorUtility.DisplayDialog("Error", "Level settings not found.", "Cancel");
                return;
            }

            if (!levelSettings.Objectives.Contains(newObjective))
            {
                levelSettings.Objectives.Add(newObjective);
                levelSettings.Objectives.RemoveAll(obj => obj == null);
            }

            // Add interactable component.
            if (newObjective.GetComponent<InteractableComponent>() == null)
            {
                newObjective.AddComponent<InteractableComponent>();
            }

            // Add interaction collider.
            MakeInteractable(newObjective);
        }

        [MenuItem("OCD/Make Obstacle")]
        public static void MakeObstacle()
        {
            var newObstacle = Selection.activeGameObject;

            if (newObstacle == null)
            {
                return;
            }

            LevelSettings levelSettings = Object.FindObjectOfType<LevelSettings>();

            if (levelSettings == null)
            {
                EditorUtility.DisplayDialog("Error", "Level settings not found.", "Cancel");
                return;
            }

            if (levelSettings.Obstacles.All(o => o.Obstacle != newObstacle))
            {
                levelSettings.Obstacles.Add(new ObstacleData { Obstacle = newObstacle });
            }

            // Add interactable component.
            if (newObstacle.GetComponent<InteractableComponent>() == null)
            {
                var interactableComponent = newObstacle.AddComponent<InteractableComponent>();
                interactableComponent.Interaction = newObstacle.name;
            }

            // Add interaction collider.
            MakeInteractable(newObstacle);
        }

        #endregion

        #region Methods

        private static void MakeInteractable(GameObject gameObject)
        {
            if (gameObject.GetComponentInChildren<ColliderComponent>() == null)
            {
                var allColliderAssets = Resources.FindObjectsOfTypeAll<ColliderComponent>();
                var interactionColliderPrefab =
                    allColliderAssets.FirstOrDefault(asset => asset.name == InteractionColliderAssetName);

                if (interactionColliderPrefab == null)
                {
                    EditorUtility.DisplayDialog(
                        "Error",
                        "Interaction collider prefab not found: " + InteractionColliderAssetName,
                        "Cancel");
                    return;
                }

                var interactionCollider = Object.Instantiate(interactionColliderPrefab);
                interactionCollider.transform.SetParent(gameObject.transform);
            }
        }

        #endregion
    }
}