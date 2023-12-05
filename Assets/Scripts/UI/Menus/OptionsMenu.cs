// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OptionsMenu.cs" company="HexDiff">
//   Copyright (c) HexDiff, All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using UnityEngine.UI;

namespace com.HexDiff.UI
{
	public class OptionsMenu : SimpleMenu<OptionsMenu>
	{
		public Slider Slider;

		public void OnMagicButtonPressed()
		{
			AwesomeMenu.Show(Slider.value);
		}
	}
}