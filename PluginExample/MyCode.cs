using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
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
			// Get the Game.Entities
			get { 
				return Helper.DeepClone<Dictionary<int, Entity>>(
					Hearthstone_Deck_Tracker.API.Core.Game.Entities).Values.ToArray<Entity>();
			}
		}

		private static Entity PlayerEntity
		{
			// Get the Entity representing the player, there is also the equivalent for the Opponent
			get { return Entities == null ? null : Entities.First(x => x.IsPlayer); }
		}		

		public static void Load() 
		{
			_player = null;

			// A border to put around the text block
			Border blockBorder = new Border();
			blockBorder.BorderBrush = Brushes.Black;
			blockBorder.BorderThickness = new Thickness(1.0);
			blockBorder.Padding = new Thickness(8.0);

			// A text block using the HS font
			_info = new HearthstoneTextBlock();
			_info.Text = "";
			_info.FontSize = 18;

			// Add the text block as a child of the border element
			blockBorder.Child = _info;

			// Create an image at the corner of the text bloxk
			Image image = new Image();
			// Create the image source
			BitmapImage bi = new BitmapImage(new Uri("pack://siteoforigin:,,,/Plugins/card.png"));
			// Set the image source
			image.Source = bi;

			// Get the HDT Overlay canvas object
			var canvas = Hearthstone_Deck_Tracker.API.Core.OverlayCanvas;
			// Get canvas centre
			var fromTop = canvas.Height / 2;
			var fromLeft = canvas.Width / 2;
			// Give the text block its position within the canvas, roughly in the center
			Canvas.SetTop(blockBorder, fromTop);
			Canvas.SetLeft(blockBorder, fromLeft);
			// Give the text block its position within the canvas
			Canvas.SetTop(image, fromTop - 12);
			Canvas.SetLeft(image, fromLeft - 12);
			// Add the text block and image to the canvas
			canvas.Children.Add(blockBorder);
			canvas.Children.Add(image);

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
