using System.Collections.Generic;
using System.Linq;
using HearthDb.Enums;
using Hearthstone_Deck_Tracker;
using Hearthstone_Deck_Tracker.Enums;
using Hearthstone_Deck_Tracker.Hearthstone;
using Hearthstone_Deck_Tracker.Hearthstone.Entities;
using CoreAPI = Hearthstone_Deck_Tracker.API.Core;

namespace PluginExample
{
	internal class Curvy
	{
		private int _mana = 0;
		private CurvyList _list = null;

		public Curvy(CurvyList list)
		{
			_list = list;
			// Hide in menu, if necessary
			if (Config.Instance.HideInMenu && CoreAPI.Game.IsInMenu)
				_list.Hide();
		}

		internal List<Entity> Entities =>
			Helper.DeepClone<Dictionary<int, Entity>>(CoreAPI.Game.Entities).Values.ToList<Entity>();

		internal Entity Opponent => Entities?.FirstOrDefault(x => x.IsOpponent);

		// Reset on when a new game starts
		internal void GameStart()
		{
			_mana = 0;
			_list.Update(new List<Card>());
		}

		// Need to handle hiding the element when in the game menu
		internal void InMenu()
		{
			if (Config.Instance.HideInMenu)
			{
				_list.Hide();
			}
		}

		// Update the card list on player's turn
		internal void TurnStart(ActivePlayer player)
		{
			if (player == ActivePlayer.Player && Opponent != null)
			{
				_list.Show();
				var mana = AvailableMana();
				var klass = KlassConverter(CoreAPI.Game.Opponent.Class);
				var cards = HearthDb.Cards.Collectible.Values
					.Where(c => c.Cost == mana && c.Class == klass)
					.Select(c => new Card(c))
					.OrderBy(c => c.Rarity)
					.ToList<Card>();
				_list.Update(cards);
			}
		}

		// Calculate the mana opponent will have on his next turn
		internal int AvailableMana()
		{
			var opp = Opponent;
			if (opp != null)
			{
				var mana = opp.GetTag(GameTag.RESOURCES);
				var overload = opp.GetTag(GameTag.OVERLOAD_OWED);
				// looking a turn ahead, so add one mana
				_mana = mana + 1 - overload;
			}
			return _mana;
		}

		// Convert hero class string to enum
		internal CardClass KlassConverter(string klass)
		{
			switch (klass.ToLowerInvariant())
			{
				case "druid":
					return CardClass.DRUID;

				case "hunter":
					return CardClass.HUNTER;

				case "mage":
					return CardClass.MAGE;

				case "paladin":
					return CardClass.PALADIN;

				case "priest":
					return CardClass.PRIEST;

				case "rogue":
					return CardClass.ROGUE;

				case "shaman":
					return CardClass.SHAMAN;

				case "warlock":
					return CardClass.WARLOCK;

				case "warrior":
					return CardClass.WARRIOR;

				default:
					return CardClass.NEUTRAL;
			}
		}
	}
}