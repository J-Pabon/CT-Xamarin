using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Linq;

namespace CT
{
	public class MainMenu : ContentPage
	{
		public MainMenuViewModel vm
		{
			get { return this.BindingContext as MainMenuViewModel; }
		}

		AbsoluteLayout absoluteModalDetailItem;
		StackLayout stackContenidoModalCorreo;

		ListView lsvDetailItem;

		public MainMenu()
		{
			this.Title = "CT - Main Menu";
			this.BindingContext = new MainMenuViewModel();


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
			iMenu.GestureRecognizers.Add(new TapGestureRecognizer ((obj) => {
				vm.IsMenuVisible = !vm.IsMenuVisible;
			}));

			var stackHeader = new StackLayout
			{
				HorizontalOptions = LayoutOptions.Fill,
				VerticalOptions = LayoutOptions.Fill,
				IsClippedToBounds = true,
				Orientation = StackOrientation.Horizontal,
				Padding = new Thickness(0,0,0,5),
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
				Margin = new Thickness(0,5,0,0)
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
				Margin = new Thickness(10,0,10,20),
				FontSize = 20,
				FontAttributes = FontAttributes.Bold,
				Text = "Main menu (Referrer)"
			};

			var viewTemplate = new DataTemplate(typeof(CTMenuItem));

			var lvMenu = new ListView
			{
				HasUnevenRows = true,
				ItemTemplate = viewTemplate
			};
			lvMenu.SetBinding(ItemsView<Cell>.ItemsSourceProperty, new Binding("MenuItems"));
			lvMenu.ItemTapped += (sender, e) =>
			{
				if (e == null)
					return;
				((ListView)sender).SelectedItem = null;

				MainMenuItem mmi = e.Item as MainMenuItem;
				string[] items = mmi.text.Split("/".ToCharArray());

				bool activar = true;
				string[] source = lsvDetailItem.ItemsSource == null ? new string[0] : (string[])lsvDetailItem.ItemsSource;

				if (Enumerable.SequenceEqual(source, items))
				{ 
					activar = false;
					items = null;
				}

				ActivateModalDetailItem(activar, items);
			};

			var btnWebVersion = new Button
			{
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Fill,
				Text = "Go to web app..."
			};
			btnWebVersion.Command = new Command((obj) => {
				((NavigationPage)Application.Current.MainPage).PushAsync(new CTWebView());
			});

			StackLayout stackContentMainMenu = new StackLayout
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.Fill,
				BackgroundColor = Color.White,
				Padding = new Thickness(4),
				Spacing = 0,
				Children = {
					stackHeader,
					//lblTitleGreetings,
					bxvTop,
					stackMenu,
					bxvBottom,
					lblTitleSection,
					lvMenu,
					btnWebVersion
				}
			};

			AbsoluteLayout.SetLayoutFlags(stackContentMainMenu, AbsoluteLayoutFlags.All);
			AbsoluteLayout.SetLayoutBounds(stackContentMainMenu, new Rectangle(0, 0, 1, 1));

			ConfigModalDetailItem();

			ScrollView scrollModalDetailItem = new ScrollView
			{
				IsClippedToBounds = true,
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness(20),
				Content = stackContenidoModalCorreo
			};

			Image iBackgroundModal = new Image
			{
				Source = "Transparencia.png",
				Aspect = Aspect.AspectFill,
				InputTransparent = true
			};

			AbsoluteLayout.SetLayoutFlags(iBackgroundModal, AbsoluteLayoutFlags.All);
			AbsoluteLayout.SetLayoutBounds(iBackgroundModal, new Rectangle(0, 0, 1, 1));

			//AbsoluteLayout.SetLayoutFlags(scrollModalDetailItem, AbsoluteLayoutFlags.All);
			//AbsoluteLayout.SetLayoutBounds(scrollModalDetailItem, new Rectangle(0, 0, 1, 1));

			AbsoluteLayout.SetLayoutFlags(stackContenidoModalCorreo, AbsoluteLayoutFlags.All);
			AbsoluteLayout.SetLayoutBounds(stackContenidoModalCorreo, new Rectangle(0, 0, 1, 1));

			absoluteModalDetailItem = new AbsoluteLayout
			{
				Padding = new Thickness(0),
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				InputTransparent = false,
				IsVisible = false,
				Children = {
					iBackgroundModal,
					//scrollModalDetailItem
					stackContenidoModalCorreo
				}
			};

			AbsoluteLayout.SetLayoutFlags(absoluteModalDetailItem, AbsoluteLayoutFlags.All);
			AbsoluteLayout.SetLayoutBounds(absoluteModalDetailItem, new Rectangle(0, 0, 1, 1));

			StackLayout stackMainMenu = new StackLayout
			{
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Fill,
				Spacing = 0,
				Children = { 
					stackContentMainMenu,
					absoluteModalDetailItem
				}
			};

			Content = stackMainMenu;
		}

		void ConfigModalDetailItem()
		{
			stackContenidoModalCorreo = new StackLayout
			{
				IsClippedToBounds = true,
				Padding = new Thickness(20),
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};

			Label lblTitulo = new Label
			{
				HorizontalOptions = LayoutOptions.Center,
				FontSize = 18,
				Text = "Select one option"
			};
			lblTitulo.SetBinding(Button.TextColorProperty, new Binding("ColorTitulo"));

			BoxView bvSpace01 = new BoxView
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.Fill,
				HeightRequest = 10,
				BackgroundColor = Color.Transparent
			};


			//DataTemplate templateCorreos = new DataTemplate(typeof(ItemContactoEmail));

			lsvDetailItem = new ListView
			{
				VerticalOptions = LayoutOptions.Fill,
				HorizontalOptions = LayoutOptions.Fill,
				//ItemTemplate = templateCorreos
			};
			lsvDetailItem.ItemTapped += (sender, e) =>
			{
				if (e == null)
					return; // has been set to null, do not 'process' tapped event
				((ListView)sender).SelectedItem = null; // de-select the row

				string item = e.Item.ToString().TrimEnd();

				string type = vm.MenuItems.Where((it)  => it.text.Contains(item)).First().type;

				ActivateModalDetailItem(false, null);

				switch (type)
				{
					case "cases":
						((NavigationPage)Application.Current.MainPage).PushAsync(new OwnCases());
						break;
				}
			};


			stackContenidoModalCorreo.Children.Add(lblTitulo);
			stackContenidoModalCorreo.Children.Add(bvSpace01);
			stackContenidoModalCorreo.Children.Add(lsvDetailItem);
		}

		void ActivateModalDetailItem(bool activar, string[] items)
		{
			lsvDetailItem.ItemsSource = items;
			absoluteModalDetailItem.IsVisible = activar;
		}
	}
}

