using System.ComponentModel.DataAnnotations;

namespace MVCProject.Models
{
	public class UniqueNameAttribute : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
			{
				return new ValidationResult("Name cannot be empty.");
			}

			var context = new ProjectContext();
			var normalizedName = value.ToString().Trim().ToLower();

			var existingEntity = context.Courses
				.FirstOrDefault(i => i.Name.Trim().ToLower() == normalizedName);

			if (existingEntity != null)
			{
				return new ValidationResult($"The name '{value}' is already in use. Please choose a different name.");
			}

			return ValidationResult.Success;
		}
	
	}
}
