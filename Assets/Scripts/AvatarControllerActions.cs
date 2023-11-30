// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VRMenu.cs" company="HexDiff">
//   Copyright (c) HexDiff, All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using UltimateXR.Avatar;
using UltimateXR.Avatar.Controllers;
using UltimateXR.Core;
using UltimateXR.Core.Components.Composite;
using UltimateXR.Devices;
using UltimateXR.Locomotion;
using UnityEngine;

namespace VRSpaceShip.Locomotion
{
    public class AvatarControllerActions : MonoBehaviour
    {
        #region Inspector Properties/Serialized Fields
        
        [SerializeField] private List<ControllerEvent> _listControllerEvents = new List<ControllerEvent>();
        
        #endregion
        
        #region Public Types & Data
        
        public IReadOnlyList<ControllerEvent> ControllerEvents => _listControllerEvents;
        
        #endregion
        
        #region Unity

        private void OnEnable()
        {
            UxrControllerInput.GlobalButtonStateChanged += UxrControllerInputOnGlobalButtonStateChanged;
        }

        private void OnDestroy()
        {
            UxrControllerInput.GlobalButtonStateChanged -= UxrControllerInputOnGlobalButtonStateChanged;
        }

        #endregion
        
        #region Event Handling Methods
        
        /// <summary>
        ///     Called after the button have change state. Invokes invent from list <see cref="ControllerEvents"/>
        /// </summary>
        private void UxrControllerInputOnGlobalButtonStateChanged(object sender, UxrInputButtonEventArgs e)
        {
            foreach (var controllerEvent in _listControllerEvents)
            {
                if(e.Button == controllerEvent.Button && e.ButtonEventType == controllerEvent.ButtonEventType) controllerEvent.Invoke();
            }
        }
        
        #endregion
    }
}