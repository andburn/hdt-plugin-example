using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Hearthstone_Deck_Tracker.API;
using Hearthstone_Deck_Tracker.Hearthstone;

namespace PluginExample
{
	public partial class CurvyList
	{
		public CurvyList()
		{
			InitializeComponent();
		}

		public void Update(List<Card> cards)
		{
			// hide if card list is empty
			this.Visibility = cards.Count <= 0 ? Visibility.Hidden : Visibility.Visible;
			this.ItemsSource = cards;
			UpdatePosition();
		}

		public void UpdatePosition()
		{
			Canvas.SetTop(this, Core.OverlayWindow.Height * 5 / 100);
			Canvas.SetRight(this, Core.OverlayWindow.Width * 20 / 100);
		}

		public void Show()
		{
			this.Visibility = Visibility.Visible;
		}

		public void Hide()
		{
			this.Visibility = Visibility.Hidden;
		}
	}
}