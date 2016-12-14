using System;

using Xamarin.Forms;

namespace CT
{
	public class OwnCases : ContentPage
	{
		Label lblTitle, lblMessage;
		ListView lstvCases;
		Button btnAdd, btnUpdate, btnDelete;

		public OwnCasesViewModel _vm
		{
			get { return this.BindingContext as OwnCasesViewModel; }
		}

		public OwnCases()
		{
			this.Title = "My cases";
			this.BindingContext = new OwnCasesViewModel();

			var activityIndicator = new ActivityIndicator
			{
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Color = Color.Black,
				IsVisible = false
			};
			activityIndicator.SetBinding(ActivityIndicator.IsRunningProperty, new Binding("IsBusy"));
			activityIndicator.SetBinding(ActivityIndicator.IsVisibleProperty, new Binding("IsBusy"));

			var iCTLogo = new Image
			{
				HeightRequest = 50,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				VerticalOptions = LayoutOptions.Fill,
				Source = "CT_logo_sm.png"
			};

			var iMenu = new Image
			{
				HeightRequest = 40,
				HorizontalOptions = LayoutOptions.EndAndExpand,
				VerticalOptions = LayoutOptions.Fill,
				Source = "menu_alt.png"
			};
			iMenu.GestureRecognizers.Add(new TapGestureRecognizer((obj) =>
			{
				_vm.IsMenuVisible = !_vm.IsMenuVisible;
			}));

			var stackHeader = new StackLayout
			{
				HorizontalOptions = LayoutOptions.Fill,
				VerticalOptions = LayoutOptions.Fill,
				IsClippedToBounds = true,
				Orientation = StackOrientation.Horizontal,
				Padding = new Thickness(0, 0, 0, 5),
				Children = { iCTLogo, iMenu }
			};


			var lblTitleGreetings = new Label
			{
				HorizontalOptions = LayoutOptions.Fill,
				HorizontalTextAlignment = TextAlignment.Center,
				FontSize = 16,
				Text = "Welcome Mr John Doe (Referrer, T1)"
			};

			CTIconHome icoHome = new CTIconHome();
			CTIconHelp icoHelp = new CTIconHelp();
			CTIconLogout icoLogout = new CTIconLogout();

			var bxvTop = new BoxView
			{
				HeightRequest = 2,
				HorizontalOptions = LayoutOptions.Fill,
				Color = Color.FromHex(Constants.HEX_LINE_MENU),
				Margin = new Thickness(0, 5, 0, 0)
			};

			var bxvBottom = new BoxView
			{
				HeightRequest = 2,
				HorizontalOptions = LayoutOptions.Fill,
				Color = Color.FromHex(Constants.HEX_LINE_MENU),
				Margin = new Thickness(0, 0, 0, 30)
			};

			var bxvLeftHome = new BoxView
			{
				WidthRequest = 2,
				VerticalOptions = LayoutOptions.Fill,
				Color = Color.FromHex(Constants.HEX_LINE_MENU)
			};

			var bxvLeftHelp = new BoxView
			{
				WidthRequest = 2,
				VerticalOptions = LayoutOptions.Fill,
				Color = Color.FromHex(Constants.HEX_LINE_MENU)
			};

			var bxvLeftLogout = new BoxView
			{
				WidthRequest = 2,
				VerticalOptions = LayoutOptions.Fill,
				Color = Color.FromHex(Constants.HEX_LINE_MENU)
			};

			var stackMenu = new StackLayout
			{
				HeightRequest = 40,
				HorizontalOptions = LayoutOptions.End,
				VerticalOptions = LayoutOptions.Fill,
				IsClippedToBounds = true,
				Orientation = StackOrientation.Horizontal,
				Children = {
					bxvLeftHome, icoHome.View,
					bxvLeftHelp, icoHelp.View,
					bxvLeftLogout, icoLogout.View
				}
			};
			stackMenu.SetBinding(IsVisibleProperty, new Binding("IsMenuVisible"));

			var lblTitleSection = new Label
			{
				HorizontalOptions = LayoutOptions.Fill,
				HorizontalTextAlignment = TextAlignment.Start,
				Margin = new Thickness(10, 0, 10, 20),
				FontSize = 20,
				FontAttributes = FontAttributes.Bold,
				Text = "Your cases"
			};

			var viewTemplateCaseItem = new DataTemplate(typeof(CaseItem));

			lstvCases = new ListView
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				HasUnevenRows = true,
				Margin = new Thickness(2),
				ItemTemplate = viewTemplateCaseItem
			};
			lstvCases.SetBinding(ItemsView<Cell>.ItemsSourceProperty, new Binding("Cases"));
			lstvCases.ItemTapped += (sender, e) =>
			{
				var case_item = (Case)e.Item;

				if (_vm.CaseSelected != null)
				{
					if (_vm.CaseSelected.id == case_item.id)
					{
						((ListView)sender).SelectedItem = null; // de-select the row

						_vm.IsCaseSelected = false;
						_vm.CaseSelected = null;

						return;
					}
					else
					{
						_vm.IsCaseSelected = true;
						_vm.CaseSelected = case_item;
					}
				}
				else
				{
					_vm.IsCaseSelected = true;
					_vm.CaseSelected = case_item;
				}
			};

			lblMessage = new Label
			{
				HorizontalOptions = LayoutOptions.StartAndExpand,
				HorizontalTextAlignment = TextAlignment.Start,
				FontAttributes = FontAttributes.Italic
			};
			lblMessage.SetBinding(Label.TextProperty, new Binding("Message"));

			btnAdd = new Button
			{
				HorizontalOptions = LayoutOptions.Fill,
				Text = "Add"
			};
			btnAdd.SetBinding(Button.CommandProperty, new Binding("AddCaseCommand"));

			btnUpdate = new Button
			{
				HorizontalOptions = LayoutOptions.Fill,
				Text = "Update"
			};
			btnUpdate.SetBinding(Button.CommandProperty, new Binding("UpdateCaseCommand"));
			btnUpdate.SetBinding(IsEnabledProperty, new Binding("IsCaseSelected"));

			btnDelete = new Button
			{
				HorizontalOptions = LayoutOptions.Fill,
				Text = "Delete"
			};
			btnDelete.SetBinding(Button.CommandProperty, new Binding("DeleteCaseCommand"));
			btnDelete.SetBinding(IsEnabledProperty, new Binding("IsCaseSelected"));

			StackLayout stackButtons = new StackLayout
			{
				HorizontalOptions = LayoutOptions.Fill,
				Orientation = StackOrientation.Horizontal,
				Children = {
					btnAdd, btnUpdate, btnDelete
				}
			};

			StackLayout stackMain = new StackLayout
			{
				HorizontalOptions = LayoutOptions.Fill,
				VerticalOptions = LayoutOptions.Fill,
				Spacing = 0,
				Margin = new Thickness(2),
				Children = {
					activityIndicator,
					stackHeader,
					//lblTitleGreetings,
					bxvTop,
					stackMenu,
					bxvBottom,
					lblTitleSection,
					lstvCases/*,
					lblMessage,
					stackButtons*/
				}
			};

			Content = stackMain;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			_vm.GetCasesList();
		}

		protected override bool OnBackButtonPressed()
		{//Si no se controla el evento, la aplicación se cierra y al reiniciar, saca error (?)
			return true;
		}
	}
}

