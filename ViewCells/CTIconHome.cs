using System;
using Xamarin.Forms;

namespace CT
{
	public class CTIconHome : ViewCell
	{
		public CTIconHome()
		{
			var iHomeIcon = new Image
			{
				HeightRequest = 38,
				HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Source = "home.png"
			};

			var lblHomeText = new Label
			{
				HorizontalOptions = LayoutOptions.Fill,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalTextAlignment = TextAlignment.Start,
				Text = "Main menu"
			};

			var stackIconHome = new StackLayout
			{
				Orientation = StackOrientation.Horizontal,
				HeightRequest = 40,
				HorizontalOptions = LayoutOptions.Fill,
				VerticalOptions = LayoutOptions.FillAndExpand,
				IsClippedToBounds = true,
				Margin = new Thickness(2),
				Spacing = 5,
				Children = { iHomeIcon, lblHomeText }
			};

			this.View = stackIconHome;
		}
	}
}