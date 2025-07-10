using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MVCProject.Models;

namespace MVCProject.ViewModels
{
	public class CourseForm
	{
		public int Id { get; set; }
		[Required]
		[UniqueName(ErrorMessage = "Course name must be unique.")]
		public string Name { get; set; }
		[Required, Range(50, 100, ErrorMessage = "Degree must be between 50 and 100")]
		public int Degree { get; set; }
		[Display(Name = "Minimum Degree For Success")]

		[Required, Range(20, 50, ErrorMessage = "Minimum degree must be between 20 and 50")]
		public int MinDegree { get; set; }

		public List<DepartmentItem> Departments { get; set; }
		[Display(Name = "Department Name")]
		public int SelectedDepartmentId { get; set; }


		public class DepartmentItem
		{
			public int Id { get; set; }
			public string Name { get; set; }
		}
	}
}
