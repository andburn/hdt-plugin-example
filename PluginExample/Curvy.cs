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
		private int _opponentId = -1;
		private int _mana = 0;
		private CurvyList _list = null;

		public Curvy()
		{
			_list = new CurvyList();
		}

		public Curvy(CurvyList list)
		{
			_list = list;
		}

		internal List<Entity> Entities =>
			Helper.DeepClone<Dictionary<int, Entity>>(CoreAPI.Game.Entities).Values.ToList<Entity>();

		internal Entity Opponent => Entities?.FirstOrDefault(x => x.IsOpponent);

		internal void NewGame()
		{
			// TODO wait until found?
			Entity opp = null;
			while (opp == null)
			{
				opp = Opponent;
				_opponentId = opp.GetTag(GameTag.CONTROLLER);
			}
		}

		internal void InMenu()
		{
			if (Config.Instance.HideInMenu)
			{
				_list.Hide();
			}
		}

		internal void TurnStart(ActivePlayer player)
		{
			if (player == ActivePlayer.Player)
			{
				if (Opponent != null)
				{
					_list.Show();
					var mana = AvailableMana();
					var klass = KlassConverter(CoreAPI.Game.Opponent.Class);
					var cards = HearthDb.Cards.Collectible.Values
						.Where(c => c.Cost == mana && c.Class == klass)
						.Select(c => new Card(c)).ToList<Card>();
					_list.Update(cards);
				}
			}
		}

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

		internal int AvailableMana()
		{
			if (Opponent != null)
			{
				var mana = Opponent.GetTag(GameTag.RESOURCES);
				var overload = Opponent.GetTag(GameTag.OVERLOAD_OWED);
				_mana = mana + 1 - overload;
			}
			return _mana;
		}
	}
}