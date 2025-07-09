using Microsoft.EntityFrameworkCore;
using MVCProject.ViewModels;
namespace MVCProject.Models
{
    public class CourseBL
    {
		private ProjectContext context;

		public CourseBL()
		{
			context = new ProjectContext();
		}

		public List<Course> GetCourses()
		{
			return context.Courses
				.Include(i => i.Department)
				.ToList();
		}

		public List<InstructorForm.CourseItem> GetCourseItems()
		{
			return context.Courses
				.Select(c => new InstructorForm.CourseItem
				{
					Id = c.Id,
					Name = c.Name
				})
				.ToList();
		}


		public Course GetCourseById(int id)
		{
			return context.Courses
				.FirstOrDefault(c => c.Id == id);
		}

		public void Add(Course course)
		{
			context.Courses.Add(course);
			context.SaveChanges();
		}

		public void Update(Course updated)
		{
			var existing = context.Courses.Find(updated.Id);
			if (existing != null)
			{
				existing.Name = updated.Name;
				existing.DepartmentId = updated.DepartmentId;

				context.SaveChanges();
			}
		}

		public void Delete(int id)
		{
			var course = context.Courses.Find(id);
			if (course != null)
			{
				context.Courses.Remove(course);
				context.SaveChanges();
			}
		}
	}
}
