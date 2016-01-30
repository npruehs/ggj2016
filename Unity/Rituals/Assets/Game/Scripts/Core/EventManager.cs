// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventManager.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Core
{
    using System;

    using Rituals.Input.Events;
    using Rituals.Interaction.Events;
    using Rituals.Objectives.Events;
    using Rituals.Obstacles.Events;
    using Rituals.Physics.Events;
    using Rituals.Pressure.Events;

    using UnityEngine;

    public class EventManager : MonoBehaviour
    {
        #region Delegates

        public delegate void CollisionEnteredDelegate(object sender, CollisionEventArgs args);

        public delegate void CollisionExitedDelegate(object sender, CollisionEventArgs args);

        public delegate void ConcedeInputDelegate(object sender, EventArgs args);

        public delegate void CurrentObjectiveChangedDelegate(object sender, CurrentObjectiveChangedEventArgs args);

        public delegate void InteractableEnteredRangeDelegate(object sender, InteractableEnteredRangeEventArgs args);

        public delegate void InteractableLeftRangeDelegate(object sender, InteractableLeftRangeEventArgs args);

        public delegate void InteractableUsedDelegate(object sender, InteractableUsedEventArgs args);

        public delegate void InteractionInputDelegate(object sender, InteractionInputEventArgs args);

        public delegate void LookDirectionInputDelegate(object sender, LookDirectionInputEventArgs args);

        public delegate void MovementInputDelegate(object sender, MovementInputEventArgs args);

        public delegate void ObjectiveAddedDelegate(object sender, ObjectiveAddedEventArgs args);

        public delegate void ObjectiveStateChangedDelegate(object sender, ObjectiveStateChangedEventArgs args);

        public delegate void ObstaclesChangedDelegate(object sender, ObstaclesChangedEventArgs args);

        public delegate void PressureChangedDelegate(object sender, PressureChangedEventArgs args);

        public delegate void SelectedInteractableChangedDelegate(
            object sender,
            SelectedInteractableChangedEventArgs args);

        #endregion

        #region Events

        public event ObstaclesChangedDelegate ObstaclesChanged;

        public event CurrentObjectiveChangedDelegate CurrentObjectiveChanged;

        public event MovementInputDelegate MovementInput;

        public event LookDirectionInputDelegate LookDirectionInput;

        public event InteractionInputDelegate InteractionInput;

        public event CollisionEnteredDelegate CollisionEntered;

        public event CollisionExitedDelegate CollisionExited;

        public event InteractableEnteredRangeDelegate InteractableEnteredRange;

        public event InteractableLeftRangeDelegate InteractableLeftRange;

        public event InteractableUsedDelegate InteractableUsed;

        public event PressureChangedDelegate PressureChanged;

        public event ObjectiveStateChangedDelegate ObjectiveStateChanged;

        public event ObjectiveAddedDelegate ObjectiveAdded;

        public event ConcedeInputDelegate ConcedeInput;

        public event SelectedInteractableChangedDelegate SelectedInteractableChanged;

        #endregion

        #region Public Methods and Operators

        public void OnCollisionEntered(object sender, CollisionEventArgs args)
        {
            var handler = this.CollisionEntered;
            if (handler != null)
            {
                handler(sender, args);
            }
        }

        public void OnCollisionExited(object sender, CollisionEventArgs args)
        {
            var handler = this.CollisionExited;
            if (handler != null)
            {
                handler(sender, args);
            }
        }

        public void OnConcedeInput(object sender, EventArgs eventArgs)
        {
            var handler = this.ConcedeInput;
            if (handler != null)
            {
                handler(sender, eventArgs);
            }
        }

        public void OnCurrentObjectiveChanged(object sender, CurrentObjectiveChangedEventArgs args)
        {
            var handler = this.CurrentObjectiveChanged;
            if (handler != null)
            {
                handler(sender, args);
            }
        }

        public void OnInteractableEnteredRange(object sender, InteractableEnteredRangeEventArgs args)
        {
            var handler = this.InteractableEnteredRange;
            if (handler != null)
            {
                handler(sender, args);
            }
        }

        public void OnInteractableLeftRange(object sender, InteractableLeftRangeEventArgs args)
        {
            var handler = this.InteractableLeftRange;
            if (handler != null)
            {
                handler(sender, args);
            }
        }

        public void OnInteractableUsed(object sender, InteractableUsedEventArgs args)
        {
            var handler = this.InteractableUsed;
            if (handler != null)
            {
                handler(sender, args);
            }
        }

        public void OnInteractionInput(object sender, InteractionInputEventArgs args)
        {
            var handler = this.InteractionInput;
            if (handler != null)
            {
                handler(sender, args);
            }
        }

        public void OnLookDirectionInput(object sender, LookDirectionInputEventArgs args)
        {
            var handler = this.LookDirectionInput;
            if (handler != null)
            {
                handler(sender, args);
            }
        }

        public void OnMovementInput(object sender, MovementInputEventArgs args)
        {
            var handler = this.MovementInput;
            if (handler != null)
            {
                handler(sender, args);
            }
        }

        public void OnObjectiveAdded(object sender, ObjectiveAddedEventArgs args)
        {
            var handler = this.ObjectiveAdded;
            if (handler != null)
            {
                handler(sender, args);
            }
        }

        public void OnObjectiveStateChanged(object sender, ObjectiveStateChangedEventArgs args)
        {
            var handler = this.ObjectiveStateChanged;
            if (handler != null)
            {
                handler(sender, args);
            }
        }

        public void OnObstaclesChanged(object sender, ObstaclesChangedEventArgs args)
        {
            var handler = this.ObstaclesChanged;
            if (handler != null)
            {
                handler(sender, args);
            }
        }

        public void OnPressureChanged(object sender, PressureChangedEventArgs args)
        {
            var handler = this.PressureChanged;
            if (handler != null)
            {
                handler(sender, args);
            }
        }

        public void OnSelectedInteractableChanged(object sender, SelectedInteractableChangedEventArgs args)
        {
            var handler = this.SelectedInteractableChanged;
            if (handler != null)
            {
                handler(sender, args);
            }
        }

        #endregion
    }
}