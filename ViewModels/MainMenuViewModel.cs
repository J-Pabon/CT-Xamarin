using System;
using System.Collections.ObjectModel;

namespace CT
{
	public class MainMenuViewModel : BaseViewModel
	{
		private ObservableCollection<MainMenuItem> menu_items;
		public ObservableCollection<MainMenuItem> MenuItems
		{
			get { return menu_items; }
			set
			{
				menu_items = value;
				OnPropertyChanged();
			}

		}

		private bool is_menu_visible;
		public bool IsMenuVisible
		{
			get { return is_menu_visible; }
			set
			{
				is_menu_visible = value;
				OnPropertyChanged();
			}
		}

		public MainMenuViewModel()
		{
			MenuItems = new ObservableCollection<MainMenuItem>
			{
				new MainMenuItem { id = 0, text = "List my cases / List cases from my hospital", type = "cases", position = 1 },
				new MainMenuItem { id = 1, text = "Create a new referral", type = "new_referral", position = 2 },
				new MainMenuItem { id = 2, text = "Network participation / Change my password / login name / email address / language / time zone / Test my email", type = "network", position = 3 },
				new MainMenuItem { id = 3, text = "Uselful links / About / Help", type = "links", position =  4 },
				new MainMenuItem { id = 4, text = "Logout", type = "lgout", position =  5 }
			};
		}
	}
}
