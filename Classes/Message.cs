using System;
using Newtonsoft.Json;

namespace CT
{
	public class Message
	{
		[JsonProperty("id")]
		public int id { get; set; }
		[JsonProperty("caseNumber")]
		public int caseNumber { get; set; }
		[JsonProperty("networkId")]
		public int networkId { get; set; }
		[JsonProperty("sequenceNo")]
		public string sequenceNo { get; set; }
		[JsonProperty("sent")]
		public DateTime sent { get; set; }
		[JsonProperty("subject")]
		public string subject { get; set; }
		[JsonProperty("text")]
		public string text { get; set; }
		[JsonProperty("author")]
		public string author { get; set; }
	}
}
