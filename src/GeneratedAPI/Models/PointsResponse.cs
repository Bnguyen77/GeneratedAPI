using System.Runtime.Serialization;

namespace GeneratedAPI.Models
{
	[DataContract]
	public class PointsResponse
	{
		/// <summary>
		/// total reward points type int
		/// </summary>
		/// <example>100</example>
		[DataMember(Name = "points")]
		public int Points { get; set; }
	}
}
