// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EditorTools.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Editor
{
    using System.Collections.Generic;
    using System.Linq;

    using Rituals.Flow.Components;
    using Rituals.Interaction.Components;
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
                var newObjectives = new List<GameObject>(levelSettings.Objectives);
                newObjectives.Add(newObjective);
                newObjectives.RemoveAll(obj => obj == null);
                levelSettings.Objectives = newObjectives.ToArray();
            }

            // Add interactable component.
            if (newObjective.GetComponent<InteractableComponent>() == null)
            {
                newObjective.AddComponent<InteractableComponent>();
            }

            // Add interaction collider.
            MakeInteractable(newObjective);
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