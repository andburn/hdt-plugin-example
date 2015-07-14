using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

using Hearthstone_Deck_Tracker;
using Hearthstone_Deck_Tracker.API;
using Hearthstone_Deck_Tracker.Enums;
using Hearthstone_Deck_Tracker.Hearthstone;
using Hearthstone_Deck_Tracker.Hearthstone.Entities;

namespace PluginExample
{
	public class MyCode
	{
		private static HearthstoneTextBlock _info;
		private static int? _player;

		private static Entity[] Entities
		{
			// Get the Game.Entities, you need to clone it to avoid errors
			get { return Helper.DeepClone<Dictionary<int, Entity>>(Game.Entities).Values.ToArray<Entity>(); }
		}

		private static Entity PlayerEntity
		{
			// Get the Entity representing the player, there is also the equivalent for the Opponent
			get { return Entities == null ? null : Entities.First(x => x.IsPlayer); }
		}		

		public static void Load() 
		{
			_player = null;

			// A text block using the HS font
			_info = new HearthstoneTextBlock();
			_info.Text = "";
			_info.FontSize = 18;

			// Get the HDT Overlay canvas object
			var canvas = Overlay.OverlayCanvas;
			// Give the text block its position within the canvas
			Canvas.SetTop(_info, canvas.Height / 2);
			Canvas.SetLeft(_info, canvas.Width / 2);
			// Add the text block to the canvas
			canvas.Children.Add(_info);		

			// Register methods to be called when GameEvents occur
			GameEvents.OnGameStart.Add(NewGame);
			GameEvents.OnPlayerDraw.Add(HandInfo);
		}

		// Set the player controller id, used to tell who controls a particular
		// entity (card, health etc.)
		private static void NewGame()
		{
			_player = null;
			if (PlayerEntity != null)
				_player = PlayerEntity.GetTag(GAME_TAG.CONTROLLER);		
		}

		// Find all cards in the players hand and write to the text block
		public static void HandInfo(Card c)
		{
			_info.Text = "";

			if (_player == null)
				NewGame();

			foreach (var e in Entities)
			{
				if (e.IsInHand && e.GetTag(GAME_TAG.CONTROLLER) == _player)
					_info.Text += e.Card + "\n";	
			}			
		}

	}
}
