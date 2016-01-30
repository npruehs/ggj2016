// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectiveUISystem.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Objectives.Systems
{
    using System.Collections.Generic;

    using Rituals.Core;
    using Rituals.Objectives.Data;
    using Rituals.Objectives.Events;

    using UnityEngine;
    using UnityEngine.UI;

    public class ObjectiveUISystem : RitualsBehaviour
    {
        #region Fields

        private readonly Dictionary<GameObject, Text> objectiveTexts = new Dictionary<GameObject, Text>();

        public GameObject ObjectiveTextPrefab;

        public RectTransform ObjectiveTextRoot;

        #endregion

        #region Methods

        protected override void AddListeners()
        {
            base.AddListeners();

            this.EventManager.ObjectiveAdded += this.OnObjectiveAdded;
            this.EventManager.ObjectiveStateChanged += this.OnObjectiveStateChanged;
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();

            this.EventManager.ObjectiveAdded -= this.OnObjectiveAdded;
            this.EventManager.ObjectiveStateChanged -= this.OnObjectiveStateChanged;
        }

        private void OnObjectiveAdded(object sender, ObjectiveAddedEventArgs args)
        {
            if (this.ObjectiveTextPrefab == null || this.ObjectiveTextRoot == null)
            {
                return;
            }

            var textObject = Instantiate(this.ObjectiveTextPrefab);
            textObject.transform.parent = this.ObjectiveTextRoot;
            textObject.transform.localScale = Vector3.one;

            var text = textObject.GetComponent<Text>();

            if (text != null)
            {
                text.text = string.Format("{0}. {1}", args.Index, args.Objective.name);

                this.objectiveTexts.Add(args.Objective, text);
            }
        }

        private void OnObjectiveStateChanged(object sender, ObjectiveStateChangedEventArgs args)
        {
            Text text;
            if (!this.objectiveTexts.TryGetValue(args.Objective, out text))
            {
                return;
            }

            switch (args.State)
            {
                case ObjectiveState.Inactive:
                    text.color = Color.white;
                    break;

                case ObjectiveState.Active:
                    text.color = Color.yellow;
                    break;

                case ObjectiveState.Complete:
                    text.color = Color.green;
                    break;
            }
        }

        #endregion
    }
}