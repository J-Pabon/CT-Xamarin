using System;

using Xamarin.Forms;

namespace CT
{
	public class Login : ContentPage
	{
		Entry entUser, entPassword;
		Label lblMessage;

		public LoginViewModel _vm
		{
			get { return this.BindingContext as LoginViewModel; }
		}

		public Login()
		{
			this.Title = "CT Mobile";
			this.BindingContext = new LoginViewModel();

			var iCTLogo = new Image
			{
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Fill,
				Source = "CT_logo_sm.png"
			};

			entUser = new Entry
			{
				Keyboard = Keyboard.Plain
			};
			entUser.SetBinding(Entry.TextProperty, new Binding("UserName"));
			entUser.SetBinding(Entry.PlaceholderProperty, new Binding("UserNamePlaceholder"));

			entPassword = new Entry
			{
				Keyboard = Keyboard.Plain,
				IsPassword = true
			};
			entPassword.SetBinding(Entry.TextProperty, new Binding("Password"));
			entPassword.SetBinding(Entry.PlaceholderProperty, new Binding("PasswordPlaceholder"));

			Button btnLogin = new Button
			{
				HorizontalOptions = LayoutOptions.Center,
				BackgroundColor = Color.Transparent,
				Text = "Login",
				FontAttributes = FontAttributes.Bold
			};
			btnLogin.SetBinding(Button.CommandProperty, new Binding("LoginCommand"));

			lblMessage = new Label
			{
				HorizontalOptions = LayoutOptions.StartAndExpand,
				HorizontalTextAlignment = TextAlignment.Start,
				FontAttributes = FontAttributes.Italic
			};
			lblMessage.SetBinding(Label.TextProperty, new Binding("Message"));

			StackLayout stackLogin = new StackLayout
			{
				IsClippedToBounds = true,
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Fill,
				Margin = new Thickness(20,0,20,0),
				Spacing = 5,
				Children = {
					iCTLogo,
					entUser,
					entPassword,
					btnLogin,
					lblMessage
				}
			};


			Content = stackLogin;
		}
	}
}