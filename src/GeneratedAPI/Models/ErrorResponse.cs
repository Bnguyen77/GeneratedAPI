using System.Runtime.Serialization;

namespace GeneratedAPI.Models
{
	[DataContract]
	public class ErrorResponse
	{
		/// <summary>
		/// Error responses for all request. 
		/// </summary>
		[DataMember(Name = "error")]
		public string Error { get; set; }
	}
}
