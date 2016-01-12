using System.Collections.Generic;
using System.Windows.Controls;
using Hearthstone_Deck_Tracker.Hearthstone;

namespace PluginExample
{
	/// <summary>
	/// Interaction logic for CurvyList.xaml
	/// </summary>
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
	}
}