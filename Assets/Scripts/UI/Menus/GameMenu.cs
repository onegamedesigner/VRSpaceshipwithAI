// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GameMenu.cs" company="HexDiff">
//   Copyright (c) HexDiff, All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace com.HexDiff.UI
{
	public class GameMenu : SimpleMenu<GameMenu>
	{
		public void OnShipPressed()
		{
			ShipMenu.Show();
		}
		public override void OnBackPressed()
		{
			PauseMenu.Show();
		}
	}
}