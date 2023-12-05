// --------------------------------------------------------------------------------------------------------------------
// <copyright file="<ainMenu.cs" company="HexDiff">
//   Copyright (c) HexDiff, All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using UnityEngine;

namespace com.HexDiff.UI
{
	public class MainMenu : SimpleMenu<MainMenu>
	{
		public void OnPlayPressed()
		{
			GameMenu.Show();
		}

		public void OnShipPressed()
		{
			ShipMenu.Show();
		}
		
		public void OnOptionsPressed()
		{
			OptionsMenu.Show();
		}
		
		public override void OnBackPressed()
		{
			Application.Quit();
		}
	}
}