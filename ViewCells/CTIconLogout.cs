using System;
using Xamarin.Forms;

namespace CT
{
	public class CTIconLogout : ViewCell
	{
		public CTIconLogout()
		{
			var iLogoutIcon = new Image
			{
				HeightRequest = 32,
				HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Source = "sign_out.png"
			};

			var lblLogoutText = new Label
			{
				HorizontalOptions = LayoutOptions.Fill,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalTextAlignment = TextAlignment.Start,
				Text = "Logout"
			};

			var stackIconLogout = new StackLayout
			{
				Orientation = StackOrientation.Horizontal,
				HeightRequest = 35,
				HorizontalOptions = LayoutOptions.Fill,
				VerticalOptions = LayoutOptions.FillAndExpand,
				IsClippedToBounds = true,
				Margin = new Thickness(2),
				Spacing = 5,
				Children = { iLogoutIcon, lblLogoutText }
			};

			this.View = stackIconLogout;
		}
	}
}