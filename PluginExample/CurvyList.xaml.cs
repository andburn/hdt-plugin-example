using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Hearthstone_Deck_Tracker.Hearthstone;

namespace PluginExample
{
	public partial class CurvyList : UserControl
	{
		public CurvyList()
		{
			InitializeComponent();
			List<Card> cards = new List<Card>();
			cards.Add(new Card(HearthDb.Cards.GetFromName("Malygos", HearthDb.Enums.Language.enUS)));
			cards.Add(new Card(HearthDb.Cards.GetFromName("Dr. Boom", HearthDb.Enums.Language.enUS)));
			cards.Add(new Card(HearthDb.Cards.GetFromName("Knife Juggler", HearthDb.Enums.Language.enUS)));
			listView.ItemsSource = cards;
		}

		public void Update(List<Card> cards)
		{
			listView.ItemsSource = cards;
		}

		public void Show()
		{
			this.Visibility = Visibility.Visible;
		}

		public void Hide()
		{
			this.Visibility = Visibility.Collapsed;
		}
	}
}