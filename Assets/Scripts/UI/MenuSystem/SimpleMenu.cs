// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SimpleMenu.cs" company="HexDiff">
//   Copyright (c) HexDiff, All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace com.HexDiff.UI
{
    public abstract class SimpleMenu<T> : Menu<T> where T : SimpleMenu<T>
    {
        public static void Show()
        {
            Open();
        }

        public static void Hide()
        {
            Close();
        }
    }
}