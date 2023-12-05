// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PauseMenu.cs" company="HexDiff">
//   Copyright (c) HexDiff, All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace com.HexDiff.UI
{
	public class PauseMenu : SimpleMenu<PauseMenu>
	{
		public void OnQuitPressed()
		{
			Hide();
			Destroy(this.gameObject); // This menu does not automatically destroy itself

			GameMenu.Hide();
		}
	}
}