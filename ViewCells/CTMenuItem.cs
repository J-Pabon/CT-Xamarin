using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace CT
{
	public class CTMenuItem : ViewCell
	{
		public CTMenuItem()
		{
			var lblItemPosition = new Label
			{
				HorizontalOptions = LayoutOptions.Fill,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalTextAlignment = TextAlignment.Center,
				FontAttributes = FontAttributes.Bold
			};
			lblItemPosition.SetBinding(Label.TextProperty, new Binding("position"));

			var lblItemText = new Label
			{
				HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalTextAlignment = TextAlignment.Start
			};
			lblItemText.SetBinding(Label.TextProperty, new Binding("text"));

			var stackItem = new StackLayout
			{
				Orientation = StackOrientation.Horizontal,
				HeightRequest = 50,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				IsClippedToBounds = true,
				Margin = new Thickness(2),
				Children = { lblItemPosition, lblItemText }
			};

			this.View = stackItem;
		}
	}
}