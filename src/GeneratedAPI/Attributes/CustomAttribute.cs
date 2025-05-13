using System;
using System.ComponentModel.DataAnnotations;

namespace GeneratedAPI.Attributes
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class CustomAttribute : ValidationAttribute
	{
		/// <summary>
		/// CUSTOM attribute for 24:00 time format. (00:00 -> 24:00) valid 
		/// C# doesn't have a built in attr to validate this format for some reasons.
		/// </summary>
		[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
		public class TimeFormat24hrsAttribute : ValidationAttribute
		{
			/// <inheritdoc/>
			protected override ValidationResult IsValid(object value, ValidationContext validationContext)
			{
				if (value is string timeStr &&
					TimeSpan.TryParse(timeStr, out var time))
				{
					// Valid if between 00:00 and before 24:00
					if (time >= TimeSpan.Zero && time < new TimeSpan(24, 0, 0))
					{
						return ValidationResult.Success;
					}

					return new ValidationResult("Time must be in valid 24-hour format (HH:mm).");
				}

				return new ValidationResult("Invalid time format.");
			}
		}
	}
}
