using MVCProject.Models;

namespace MVCProject.ViewModels
{
	public class InstructorForm
	{

		public Instructor Instructor { get; set; }

		public List<DepartmentItem> DepartmentsItems { get; set; }
		public List<CourseItem> CoursesItems { get; set; }

		public int SelectedDepartmentId { get; set; }
		public int SelectedCourseId { get; set; }
		public class DepartmentItem
		{
			public int Id { get; set; }
			public string Name { get; set; }
		}
		public class CourseItem
		{
			public int Id { get; set; }
			public string Name { get; set; }
		}
	}
}
