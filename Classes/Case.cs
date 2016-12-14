using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace CT
{
	public class Case
	{
		/*[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("patientName")]
		public string patientName { get; set; }
		[JsonProperty("status")]
		public int status { get; set; }
		[JsonProperty("description")]
		public string description { get; set; }
		[JsonProperty("location")]
		public string location { get; set; }

		public static implicit operator Case(SelectedItemChangedEventArgs v)
		{
			throw new NotImplementedException();
		}*/

		[JsonProperty("id")]
		public int id { get; set; }
		[JsonProperty("patientName")]
		public string patientName { get; set; }
		[JsonProperty("status")]
		public int status { get; set; }
		[JsonProperty("caseNumber")]
		public int caseNumber { get; set; }
		[JsonProperty("clinical")]
		public string clinical { get; set; }
		[JsonProperty("received")]
		public DateTime received { get; set; }
		[JsonProperty("sex")]
		public string sex { get; set; }
		[JsonProperty("age")]
		public string age { get; set; } //change to TimeSpan (?)
		[JsonProperty("submittedBy")]
		public string submittedBy { get; set; }
		[JsonProperty("hospital")]
		public string hospital { get; set; }
		[JsonProperty("queriesCount")]
		public int queriesCount { get; set; }
		[JsonProperty("messagesCount")]
		public int messagesCount { get; set; }
		[JsonProperty("city")]
		public string city { get; set; }
		[JsonProperty("country")]
		public string country { get; set; }
		[JsonProperty("networkId")]
		public int networkId { get; set; }
		[JsonProperty("messages")]
		public List<Message> messages { get; set; }

		public static implicit operator Case(SelectedItemChangedEventArgs v)
		{
			throw new NotImplementedException();
		}
	}
}