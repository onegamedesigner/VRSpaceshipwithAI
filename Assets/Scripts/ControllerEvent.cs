// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ControllerEvent.cs" company="HexDiff">
//   Copyright (c) HexDiff, All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using UltimateXR.Core;
using UltimateXR.Devices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace VRSpaceShip.Locomotion
{
    [Serializable]
    public class ControllerEvent
    {
        #region Inspector Properties/Serialized Fields

        [SerializeField] private UxrInputButtons button;
        [SerializeField] private UxrButtonEventType buttonEventType;
        
        [SerializeField] private UnityEvent @event;

        #endregion

        #region Public Types & Data

        /// <summary>
        ///     Gets or sets the button that trigger the event.
        /// </summary>
        public UxrInputButtons Button
        {
            get => button;
            set => button = value;
        }

        /// <summary>
        /// Gets or sets the button event type that trigger the event.
        /// </summary>
        public UxrButtonEventType ButtonEventType
        {
            get => buttonEventType;
            set => buttonEventType = value;
        }
        #endregion

        #region Public Overrides object

        /// <inheritdoc />
        public override string ToString()
        {
            return $"Event type: button(s): {button}";
        }

        #endregion

        public void Invoke()
        {
            @event?.Invoke();
        }
    }
}