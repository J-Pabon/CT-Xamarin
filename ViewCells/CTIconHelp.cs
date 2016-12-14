using System;
using Xamarin.Forms;

namespace CT
{
	public class CTIconHelp : ViewCell
	{
		public CTIconHelp()
		{
			var iHelpIcon = new Image
			{
				HeightRequest = 30,
				HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Source = "help.png"
			};

			var lblHelpText = new Label
			{
				HorizontalOptions = LayoutOptions.Fill,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalTextAlignment = TextAlignment.Start,
				Text = "Help"
			};

			var stackIconHelp = new StackLayout
			{
				Orientation = StackOrientation.Horizontal,
				HeightRequest = 32,
				HorizontalOptions = LayoutOptions.Fill,
				VerticalOptions = LayoutOptions.FillAndExpand,
				IsClippedToBounds = true,
				Margin = new Thickness(2),
				Spacing = 5,
				Children = { iHelpIcon, lblHelpText }
			};

			this.View = stackIconHelp;
		}
	}
}