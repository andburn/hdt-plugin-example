using System;
using System.Windows.Controls;
using Hearthstone_Deck_Tracker.API;
using Hearthstone_Deck_Tracker.Plugins;

namespace PluginExample
{
	public class CurvyPlugin : IPlugin
	{
		private CurvyList _list;

		public string Author
		{
			get { return "andburn"; }
		}

		public string ButtonText
		{
			get { return "Settings"; }
		}

		public string Description
		{
			get { return "A simple example plugin showing the oppoents class cards on curve."; }
		}

		public MenuItem MenuItem
		{
			get { return null; }
		}

		public string Name
		{
			get { return "Curvy"; }
		}

		public void OnButtonPress()
		{
		}

		public void OnLoad()
		{
			_list = new CurvyList();
			Core.OverlayCanvas.Children.Add(_list);
			Curvy curvy = new Curvy(_list);

			GameEvents.OnGameStart.Add(curvy.GameStart);
			GameEvents.OnInMenu.Add(curvy.InMenu);
			GameEvents.OnTurnStart.Add(curvy.TurnStart);
		}

		public void OnUnload()
		{
			Core.OverlayCanvas.Children.Remove(_list);
		}

		public void OnUpdate()
		{
		}

		public Version Version
		{
			get { return new Version(0, 1, 1); }
		}
	}
}