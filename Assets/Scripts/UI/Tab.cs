// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Tab.cs" company="HexDiff">
//   Copyright (c) HexDiff, All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using UnityEngine;

namespace com.HexDiff.UI
{
    public abstract class Tab : MonoBehaviour
    {
        [SerializeField] protected Vector2 size = Vector2.zero;

        [SerializeField] private List<TabSecondary> TabList = new List<TabSecondary>();

        protected virtual void Open()
        {
            
        }
        
        protected virtual void Close()
        {
            
        }
    }
}