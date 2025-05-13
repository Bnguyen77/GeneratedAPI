using System.Runtime.Serialization;

namespace GeneratedAPI.Models
{
	[DataContract]
	public class ReceiptIdResponse
	{
		/// <summary>
		/// The ID returned after a receipt is processed.
		/// </summary>
		/// <example>adb6b560-0eef-42bc-9d16-df48f30e89b2</example>
		[DataMember(Name = "id")]
		public string Id { get; set; }
	}
}