// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VRMenu.cs" company="HexDiff">
//   Copyright (c) HexDiff, All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using UltimateXR.Avatar;
using UltimateXR.Devices;
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

        private void Update()
        {
            UxrAvatar          avatar          = UxrAvatar.LocalAvatar;
            UxrControllerInput controllerInput = avatar != null ? avatar.ControllerInput : null;

            if (avatar != _avatar || controllerInput != _avatarControllerInput)
            {
                // Unsubscribe from the current avatar controller events.

                if (_avatarControllerInput != null)
                {
                    _avatarControllerInput.ButtonStateChanged -= ControllerInput_ButtonStateChanged;
                }

                // Cache the new avatar and regenerate the panel.

                _avatar                = avatar;
                _avatarControllerInput = controllerInput;

                // Subscribe to the input events to update the input UI widgets.

                if (_avatarControllerInput != null)
                {
                    _avatarControllerInput.ButtonStateChanged += ControllerInput_ButtonStateChanged;
                }
            }
        }

        #endregion

        #region Event Handling Methods

        /// <summary>
        ///     Called after the button have change state. Invokes invent from list <see cref="ControllerEvents"/>
        /// </summary>
        private void ControllerInput_ButtonStateChanged(object sender, UxrInputButtonEventArgs e)
        {
            Debug.Log($"Event type: {e.ButtonEventType} button(s): {e.Button}");
            foreach (var controllerEvent in ControllerEvents)
            {
                if (e.Button == controllerEvent.Button && e.ButtonEventType == controllerEvent.ButtonEventType)
                    controllerEvent.Invoke();
            }
        }

        #endregion
        
        #region Private Types & Data

        private const string NoController = "None";

        private UxrAvatar          _avatar;
        private UxrControllerInput _avatarControllerInput;

        #endregion
    }
}