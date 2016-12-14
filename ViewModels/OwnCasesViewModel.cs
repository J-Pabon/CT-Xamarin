using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace CT
{
	public class OwnCasesViewModel : BaseViewModel
	{
		private ObservableCollection<Case> cases;
		public ObservableCollection<Case> Cases
		{
			get { return cases; }
			set
			{
				cases = value;
				OnPropertyChanged();
			}

		}

		private bool is_busy;
		public bool IsBusy
		{
			get { return is_busy; }
			set
			{
				is_busy = value;
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

		private bool iscaseselected;
		public bool IsCaseSelected
		{
			get { return iscaseselected; }
			set
			{
				iscaseselected = value;
				OnPropertyChanged();
			}
		}

		private Case caseselected;
		public Case CaseSelected
		{
			get { return caseselected; }
			set
			{
				caseselected = value;
				OnPropertyChanged();
			}
		}

		private string message;
		public string Message
		{
			get { return message; }
			set
			{
				message = value;
				OnPropertyChanged();
			}
		}

		public OwnCasesViewModel()
		{
			Cases = new ObservableCollection<Case>();
			IsCaseSelected = false;

			Message = "";
		}

		public async void GetCasesList()
		{
			Message = "";
			using (var client = new HttpClient())
			{
				//var url = "http://ct-test.azurewebsites.net/v1/cases";

				IsBusy = true;

				client.DefaultRequestHeaders.Add("Authorization", "Bearer " + App.Token);
				var response = await client.GetStringAsync(Constants.URI_CASES);

				Cases = JsonConvert.DeserializeObject<ObservableCollection<Case>>(response);

				IsBusy = false;
			}
		}

		private Command<object> addCaseCommand;
		public Command<object> AddCaseCommand
		{
			get
			{
				return addCaseCommand ?? (new Command<object>(ExecuteAddCaseCommand));
			}
		}

		public virtual async void ExecuteAddCaseCommand(object sender)
		{
			Message = "";
			IsCaseSelected = false;

			await ((NavigationPage)Application.Current.MainPage).PushAsync(new NewCase());
		}

		private Command<object> updateCaseCommand;
		public Command<object> UpdateCaseCommand
		{
			get
			{
				return updateCaseCommand ?? (new Command<object>(ExecuteUpdateCaseCommand));
			}
		}

		public virtual async void ExecuteUpdateCaseCommand(object sender)
		{ 
			Message = "";
			IsCaseSelected = false;

			await ((NavigationPage)Application.Current.MainPage).PushAsync(new UpdateCase(CaseSelected));
		}

		private Command<object> deleteCaseCommand;
		public Command<object> DeleteCaseCommand
		{
			get
			{
				return deleteCaseCommand ?? (new Command<object>(ExecuteDeleteCaseCommand));
			}
		}

		public virtual async void ExecuteDeleteCaseCommand(object sender)
		{ 
			Message = "";

			var httpClient = new HttpClient();
			httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + App.Token);

			string case_name = CaseSelected.patientName;

			HttpResponseMessage response = await httpClient.DeleteAsync(new Uri(Constants.URI_CASES + "/" + CaseSelected.id));

			if (response.IsSuccessStatusCode)
			{ 
				IsCaseSelected = false;
				GetCasesList();

				Message = string.Format("Case '{0}' deleted.", case_name);
			}
			else { Message = string.Format("Error ({0}): {1}", response.StatusCode, response.ReasonPhrase); }
		}
	}
}
