// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VRMenu.cs" company="HexDiff">
//   Copyright (c) HexDiff, All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using UltimateXR.Core;
using UltimateXR.Core.Components.Composite;
using UltimateXR.Devices;
using UltimateXR.Locomotion;
using UnityEngine;

namespace VRSpaceShip.Locomotion
{
    public class VRMenu 
    {
        #region Inspector Properties/Serialized Fields

        [SerializeField] private Transform _menu;
        
        #endregion
        
        #region Unity

        private void OnEnable()
        {
            UxrManager.AvatarsUpdated += UxrManager_AvatarsUpdated;
        }

        private void OnDestroy()
        {
            UxrManager.AvatarsUpdated -= UxrManager_AvatarsUpdated;
        }

        #endregion
        
        #region Event Handling Methods
        
        private void UxrManager_AvatarsUpdated()
        {
            throw new System.NotImplementedException();
        }
        
        #endregion
    }
}