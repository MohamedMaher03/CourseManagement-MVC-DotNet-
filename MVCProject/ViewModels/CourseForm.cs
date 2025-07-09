using System.ComponentModel.DataAnnotations;

namespace MVCProject.ViewModels
{
	public class CourseForm
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Degree { get; set; }
		[Display(Name = "Minimum Degree For Success")]
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
