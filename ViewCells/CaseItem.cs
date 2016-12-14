using System;
using Xamarin.Forms;

namespace CT
{//status,caseNumber,clinical,queriesCount,messagesCount,received,patientName,sex,age,submittedBy
	public class CaseItem : ViewCell
	{
		public CaseItem()
		{
			var gridCase = new Grid
			{
				IsClippedToBounds = true,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness(0),
				RowSpacing = 2,
				ColumnSpacing = 1,
				Margin = new Thickness(2,3,2,3)
			};

			gridCase.RowDefinitions.Add(new RowDefinition
			{
				Height = new GridLength(1, GridUnitType.Auto)
			});
			gridCase.RowDefinitions.Add(new RowDefinition
			{
				Height = new GridLength(1, GridUnitType.Auto)
			});
			gridCase.RowDefinitions.Add(new RowDefinition
			{
				Height = new GridLength(1, GridUnitType.Auto)
			});
			gridCase.RowDefinitions.Add(new RowDefinition
			{
				Height = new GridLength(1, GridUnitType.Auto)
			});
			gridCase.RowDefinitions.Add(new RowDefinition
			{
				Height = new GridLength(1, GridUnitType.Auto)
			});
			gridCase.RowDefinitions.Add(new RowDefinition
			{
				Height = new GridLength(1, GridUnitType.Auto)
			});
			gridCase.RowDefinitions.Add(new RowDefinition
			{
				Height = new GridLength(1, GridUnitType.Auto)
			});


			gridCase.ColumnDefinitions.Add(new ColumnDefinition
			{
				Width = new GridLength(1, GridUnitType.Star)
			});
			gridCase.ColumnDefinitions.Add(new ColumnDefinition
			{
				Width = new GridLength(1, GridUnitType.Star)
			});
			gridCase.ColumnDefinitions.Add(new ColumnDefinition
			{
				Width = new GridLength(1, GridUnitType.Star)
			});
			gridCase.ColumnDefinitions.Add(new ColumnDefinition
			{
				Width = new GridLength(1, GridUnitType.Star)
			});
			gridCase.ColumnDefinitions.Add(new ColumnDefinition
			{
				Width = new GridLength(1, GridUnitType.Star)
			});


			var lblrStatus = new Label
			{
				HorizontalTextAlignment = TextAlignment.Center,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.Fill,
				FontAttributes = FontAttributes.Bold,
				Text = "Status",
				Margin = new Thickness(2,0,2,0)
			};
			var bxvStatus = new BoxView
			{
				HeightRequest = 10,
				WidthRequest = 10,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center
			};
			bxvStatus.SetBinding(BoxView.ColorProperty, new Binding("status", BindingMode.Default, new StatusColorConverter()));


			var lblrCaseNumber = new Label
			{
				HorizontalTextAlignment = TextAlignment.Center,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.Fill,
				FontAttributes = FontAttributes.Bold,
				Text = "Case",
				Margin = new Thickness(2, 0, 2, 0)
			};
			var lblCaseNumber = new Label
			{
				HorizontalTextAlignment = TextAlignment.Center,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center
			};
			lblCaseNumber.SetBinding(Label.TextProperty, new Binding("caseNumber"));

			var lblrClinicalType = new Label
			{
				HorizontalTextAlignment = TextAlignment.Center,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.Fill,
				FontAttributes = FontAttributes.Bold,
				Text = "Type",
				Margin = new Thickness(2, 0, 2, 0)
			};
			var lblClinicalType = new Label
			{
				HorizontalTextAlignment = TextAlignment.Center,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center
			};
			lblClinicalType.SetBinding(Label.TextProperty, new Binding("clinical"));


			var lblrQueriesCount = new Label
			{
				HorizontalTextAlignment = TextAlignment.Center,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.Fill,
				FontAttributes = FontAttributes.Bold,
				Text = "Queries",
				Margin = new Thickness(2, 0, 2, 0)
			};
			var lblQueriesCount = new Label
			{
				HorizontalTextAlignment = TextAlignment.Center,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center
			};
			lblQueriesCount.SetBinding(Label.TextProperty, new Binding("queriesCount"));

			var lblrMessagesCount = new Label
			{
				HorizontalTextAlignment = TextAlignment.Center,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.Fill,
				FontAttributes = FontAttributes.Bold,
				Text = "Messages"
			};
			var lblMessagesCount = new Label
			{
				HorizontalTextAlignment = TextAlignment.Center,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center
			};
			lblMessagesCount.SetBinding(Label.TextProperty, new Binding("messagesCount"));


			var lblrReceived = new Label
			{
				HorizontalTextAlignment = TextAlignment.Start,
				HorizontalOptions = LayoutOptions.Fill,
				VerticalOptions = LayoutOptions.Fill,
				FontAttributes = FontAttributes.Bold,
				Text = "Case received"
			};
			var lblReceived = new Label
			{
				HorizontalTextAlignment = TextAlignment.Start,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.Center
			};
			lblReceived.SetBinding(Label.TextProperty, new Binding("received"));

			var lblrPatientName = new Label
			{
				HorizontalTextAlignment = TextAlignment.Start,
				HorizontalOptions = LayoutOptions.Fill,
				VerticalOptions = LayoutOptions.Fill,
				FontAttributes = FontAttributes.Bold,
				Text = "Patient"
			};
			var lblPatientName = new Label
			{
				HorizontalTextAlignment = TextAlignment.Start,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.Center
			};
			lblPatientName.SetBinding(Label.TextProperty, new Binding("patientName"));

			var lblrSex = new Label
			{
				HorizontalTextAlignment = TextAlignment.Center,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.Fill,
				FontAttributes = FontAttributes.Bold,
				Text = "Sex"
			};
			var lblSex = new Label
			{
				HorizontalTextAlignment = TextAlignment.Center,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center
			};
			lblSex.SetBinding(Label.TextProperty, new Binding("sex"));

			var lblrAge = new Label
			{
				HorizontalTextAlignment = TextAlignment.Center,
				HorizontalOptions = LayoutOptions.Fill,
				VerticalOptions = LayoutOptions.Fill,
				FontAttributes = FontAttributes.Bold,
				Text = "Age"
			};
			var lblAge = new Label
			{
				HorizontalTextAlignment = TextAlignment.Center,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center
			};
			lblAge.SetBinding(Label.TextProperty, new Binding("age"));

			var lblrSubmittedBy = new Label
			{
				HorizontalTextAlignment = TextAlignment.Start,
				HorizontalOptions = LayoutOptions.Fill,
				VerticalOptions = LayoutOptions.Fill,
				FontAttributes = FontAttributes.Bold,
				Text = "Referrer"
			};
			var lblSubmittedBy = new Label
			{
				HorizontalTextAlignment = TextAlignment.Start,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.Center
			};
			lblSubmittedBy.SetBinding(Label.TextProperty, new Binding("submittedBy"));



			gridCase.Children.Add(lblrStatus, 0,1,0,1);
			gridCase.Children.Add(bxvStatus, 0,1,1,2);
			gridCase.Children.Add(lblrCaseNumber, 1,2,0,1);
			gridCase.Children.Add(lblCaseNumber, 1,2,1,2);
			gridCase.Children.Add(lblrClinicalType, 2,3,0,1);
			gridCase.Children.Add(lblClinicalType, 2,3,1,2);
			gridCase.Children.Add(lblrQueriesCount, 3,4,0,1);
			gridCase.Children.Add(lblQueriesCount, 3,4,1,2);
			gridCase.Children.Add(lblrMessagesCount, 4,5,0,1);
			gridCase.Children.Add(lblMessagesCount, 4,5,1,2);
			gridCase.Children.Add(lblrReceived, 0,2,2,3);
			gridCase.Children.Add(lblReceived, 2,5,2,3);
			gridCase.Children.Add(lblrPatientName, 0,2,3,4);
			gridCase.Children.Add(lblPatientName, 0,3,4,5);
			gridCase.Children.Add(lblrSex, 3,4,3,4);
			gridCase.Children.Add(lblSex, 3,4,4,5);
			gridCase.Children.Add(lblrAge, 4,5,3,4);
			gridCase.Children.Add(lblAge, 4,5,4,5);
			gridCase.Children.Add(lblrSubmittedBy, 0,1,5,6);
			gridCase.Children.Add(lblSubmittedBy, 0,5,6,7);

			this.View = gridCase;
		}
	}
}