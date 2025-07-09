using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;
using MVCProject.ViewModels;

namespace MVCProject.Controllers
{
	public class CourseController : Controller
	{
		public IActionResult Index()
		{
			CourseBL courseBL = new CourseBL();
			List<Course> courses = courseBL.GetCourses();
			return View("Courses", courses);
		}
		[HttpGet]
		public IActionResult AddCourse()
		{
			DepartmentBL departmentBL = new DepartmentBL();
			List<Department> departments = departmentBL.GetDepartments();
			if (departments == null || departments.Count == 0)
			{
				ViewBag.ErrorMessage = "No departments available. Please add a department first.";
				return View("Error");
			}
			CourseForm courseForm = new CourseForm();
			courseForm.Departments = departments.Select(d => new CourseForm.DepartmentItem
			{
				Id = d.Id,
				Name = d.Name
			}).ToList();

			return View("AddCourse", courseForm);
		}

		[HttpPost]
		public IActionResult AddCourse(CourseForm viewModel)
		{
			ModelState.Remove("Departments");

			if (ModelState.IsValid==true)
			{
				CourseBL courseBL = new CourseBL();
				Course newCourse = new Course
				{
					Name = viewModel.Name,
					Degree = viewModel.Degree,
					MinDegree = viewModel.MinDegree,
					DepartmentId = viewModel.SelectedDepartmentId
				};
				courseBL.Add(newCourse);
				return RedirectToAction("Index");
			}

			DepartmentBL departmentBL = new DepartmentBL();
			List<Department> departments = departmentBL.GetDepartments();
			viewModel.Departments = departments.Select(d => new CourseForm.DepartmentItem
			{
				Id = d.Id,
				Name = d.Name
			}).ToList();

			return View("AddCourse", viewModel);
		}
		private bool IsValidCourse(CourseForm viewModel)
		{
			return viewModel?.Name != null &&
				   viewModel?.Degree != null &&
				   viewModel?.MinDegree != null;
		}
	}

}
