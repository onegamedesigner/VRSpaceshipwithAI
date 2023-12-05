// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MenuManager.cs" company="HexDiff">
//   Copyright (c) HexDiff, All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace com.HexDiff.UI
{
	public class MenuManager : MonoBehaviour
	{
		public GameMenu GameMenuPrefab;
		public ShipMenu ShipMenuPrefab;
		public OptionsMenu OptionsMenuPrefab;

		private Stack<Menu> menuStack = new Stack<Menu>();

		private bool _isOpen = false;
		public static MenuManager Instance { get; set; }
		private void Awake()
		{
			Instance = this;
			//_isOpen = true;
			//GameMenu.Show();
		}

		private void OnDestroy()
		{
			Instance = null;
		}

		public void CreateInstance<T>() where T : Menu
		{
			var prefab = GetPrefab<T>();

			Instantiate(prefab, transform);
		}

		public void OpenMenu(Menu instance)
		{
			// De-activate top menu
			if (menuStack.Count > 0)
			{
				if (instance.DisableMenusUnderneath)
				{
					foreach (var menu in menuStack)
					{
						menu.gameObject.SetActive(false);

						if (menu.DisableMenusUnderneath)
							break;
					}
				}

				var topCanvas = instance.GetComponent<Canvas>();
				var previousCanvas = menuStack.Peek().GetComponent<Canvas>();
				topCanvas.sortingOrder = previousCanvas.sortingOrder + 1;
			}

			menuStack.Push(instance);
		}

		private T GetPrefab<T>() where T : Menu
		{
			// Get prefab dynamically, based on public fields set from Unity
			// You can use private fields with SerializeField attribute too
			var fields = this.GetType()
				.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
			foreach (var field in fields)
			{
				var prefab = field.GetValue(this) as T;
				if (prefab != null)
				{
					return prefab;
				}
			}

			throw new MissingReferenceException("Prefab not found for type " + typeof(T));
		}

		public void CloseMenu(Menu menu)
		{
			if (menuStack.Count == 0)
			{
				Debug.LogErrorFormat(menu, "{0} cannot be closed because menu stack is empty", menu.GetType());
				return;
			}

			if (menuStack.Peek() != menu)
			{
				Debug.LogErrorFormat(menu, "{0} cannot be closed because it is not on top of stack", menu.GetType());
			}

			CloseTopMenu();
		}

		private void CloseTopMenu()
		{
			var instance = menuStack.Pop();

			if (instance.DestroyWhenClosed)
				Destroy(instance.gameObject);
			else
				instance.gameObject.SetActive(false);

			// Re-activate top menu
			// If a re-activated menu is an overlay we need to activate the menu under it
			foreach (var menu in menuStack)
			{
				menu.gameObject.SetActive(true);

				if (menu.DisableMenusUnderneath)
					break;
			}
		}

		public void OpenClose()
		{
			if (_isOpen)
			{
				_isOpen = false;
				foreach (var instance in menuStack)
				{
					Destroy(instance.gameObject);
				}
				menuStack.Clear();
			}
			else
			{
				_isOpen = true;
				GameMenu.Show();
				/*foreach (var obj in menuStack)
				{
					var instance = menuStack.Pop();

					if (!instance.DestroyWhenClosed)
						instance.gameObject.SetActive(true);
					else
						Destroy(instance.gameObject);
				}*/
			}
		}
	}
}