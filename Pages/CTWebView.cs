using System;

using Xamarin.Forms;

namespace CT
{
	public class CTWebView : ContentPage
	{
		public CTWebView()
		{
			this.Title = "CT - Homepage";

			var browser = new WebView();

			browser.Source = "http://ct-test.endzone.io/responsive/";

			Content = browser;
		}
	}
}

