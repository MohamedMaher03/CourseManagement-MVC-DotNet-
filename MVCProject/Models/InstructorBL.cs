using Microsoft.EntityFrameworkCore;

namespace MVCProject.Models
{
    public class InstructorBL
    {
        private ProjectContext context;

        public InstructorBL()
        {
            context = new ProjectContext();
        }


        public List<Instructor> GetInstructors()
        {
            return context.Instructors
                .Include(i => i.Department)
                .Include(i => i.Course)
                .ToList();
        }


        public Instructor GetInstructorById(int id)
        {
            return context.Instructors.Include(i => i.Department)
				.Include(i => i.Course)
				.FirstOrDefault(i => i.Id == id);
		}

		public void Add(Instructor instructor)
		{
			context.Instructors.Add(instructor);
			context.SaveChanges();
		}

		// ✅ Update
		public void Update(Instructor updated)
		{
			var existing = context.Instructors.Find(updated.Id);
			if (existing != null)
			{
				existing.Name = updated.Name;
				existing.Salary = updated.Salary;
				existing.Address = updated.Address;
				existing.DepartmentId = updated.DepartmentId;
				existing.CourseId = updated.CourseId;

				context.SaveChanges();
			}
		}

		// ✅ Delete
		public void Delete(int id)
		{
			var instructor = context.Instructors.Find(id);
			if (instructor != null)
			{
				context.Instructors.Remove(instructor);
				context.SaveChanges();
			}
		}

		// ✅ Example: Custom Business Rule
		public decimal CalculateBonus(int instructorId)
		{
			var instructor = context.Instructors.Find(instructorId);
			if (instructor == null)
				return 0;

			return instructor.Salary * 0.1m;  // bonus 10%
		}
	}
}
