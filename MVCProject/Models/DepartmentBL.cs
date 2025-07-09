using MVCProject.ViewModels;
namespace MVCProject.Models
{
    public class DepartmentBL
    {
		private ProjectContext context;

		public DepartmentBL()
		{
			context = new ProjectContext();
		}

		public List<Department> GetDepartments()
		{
			return context.Departments
				.ToList();
		}

		public List<InstructorForm.DepartmentItem> GetDepartmentItems()
		{
			return context.Departments
				.Select(d => new InstructorForm.DepartmentItem
				{
					Id = d.Id,
					Name = d.Name
				})
				.ToList();
		}

		public Department GetDepartmentById(int id)
		{
			return context.Departments
				.FirstOrDefault(d => d.Id == id);
		}

		public void Add(Department department)
		{
			context.Departments.Add(department);
			context.SaveChanges();
		}

		public void Update(Department updated)
		{
			var existing = context.Departments.Find(updated.Id);
			if (existing != null)
			{
				existing.Name = updated.Name;
				context.SaveChanges();
			}
		}

		public void Delete(int id)
		{
			var department = context.Departments.Find(id);
			if (department != null)
			{
				context.Departments.Remove(department);
				context.SaveChanges();
			}
		}
	}
}
