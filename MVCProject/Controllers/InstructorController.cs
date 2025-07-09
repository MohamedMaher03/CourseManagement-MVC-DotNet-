using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;
using MVCProject.ViewModels;

namespace MVCProject.Controllers
{
    public class InstructorController : Controller
    {
		public IActionResult Index(string searchName, int pageNumber = 1, int pageSize = 5)
		{
			InstructorBL instructorBL = new InstructorBL();
			var allInstructors = instructorBL.GetInstructors();

			if (!string.IsNullOrEmpty(searchName))
			{
				allInstructors = allInstructors
					.Where(i => i.Name.Contains(searchName, StringComparison.OrdinalIgnoreCase))
					.ToList();
			}

			int totalCount = allInstructors.Count;
			var instructors = allInstructors
				.Skip((pageNumber - 1) * pageSize)
				.Take(pageSize)
				.ToList();

			ViewBag.CurrentPage = pageNumber;
			ViewBag.TotalPages = (int)Math.Ceiling((double)totalCount / pageSize);
			ViewBag.SearchName = searchName;


			return View("instructors", instructors);
        }

		public IActionResult Details(int id)
		{
			// This action method will return the view for the Instructor details page.
			InstructorBL instructorBL = new InstructorBL();
			Instructor instructor = instructorBL.GetInstructorById(id);
			if (instructor == null)
			{
				return NotFound();
			}
			return View("details", instructor);
		}



		//begin		//public IActionResult AddInstructor(InstructorForm viewModel)
		//{
		//	if (viewModel?.Instructor?.Name == null || viewModel?.Instructor.Address == null || viewModel?.Instructor.Image == null || viewModel?.Instructor.Salary == null)
		//	{
		//		DepartmentBL departmentBL = new DepartmentBL();
		//		CourseBL courseBL = new CourseBL();

		//		viewModel.DepartmentsItems = departmentBL.GetDepartmentItems();
		//		viewModel.CoursesItems = courseBL.GetCourseItems();

		//		return View("AddInstructor", viewModel);
		//	}

		//	InstructorBL instructorBL = new InstructorBL();
		//	var newInstructor = viewModel.Instructor;

		//	newInstructor.DepartmentId = viewModel.SelectedDepartmentId;
		//	newInstructor.CourseId = viewModel.SelectedCourseId;

		//	instructorBL.Add(newInstructor);

		//	return RedirectToAction("Index");

		//}
		// GET: Create or Edit Instructor
		public IActionResult CreateOrEditInstructor(int? id = null)
		{
			var viewModel = new InstructorForm();

			if (id.HasValue) // Edit mode
			{
				InstructorBL instructorBL = new InstructorBL();
				var instructor = instructorBL.GetInstructorById(id.Value);
				if (instructor == null)
				{
					return NotFound();
				}

				viewModel.Instructor = instructor;
				viewModel.SelectedDepartmentId = instructor.DepartmentId;
				viewModel.SelectedCourseId = instructor.CourseId;
				ViewData["Title"] = "Edit Instructor";
				ViewData["Action"] = "Edit";
			}
			else // Create mode
			{
				viewModel.Instructor = new Instructor(); 
				ViewData["Title"] = "Add Instructor";
				ViewData["Action"] = "Add";
			}

			LoadDropdownData(viewModel);
			return View("CreateOrEditInstructor", viewModel);
		}

		// POST: Create or Edit Instructor
		[HttpPost]
		public IActionResult CreateOrEditInstructor(int? id, InstructorForm viewModel)
		{
			if (!IsValidInstructor(viewModel))
			{
				LoadDropdownData(viewModel);
				ViewData["Title"] = id.HasValue ? "Edit Instructor" : "Add Instructor";
				ViewData["Action"] = id.HasValue ? "Edit" : "Add";
				return View("CreateOrEditInstructor", viewModel);
			}

			InstructorBL instructorBL = new InstructorBL();
			viewModel.Instructor.DepartmentId = viewModel.SelectedDepartmentId;
			viewModel.Instructor.CourseId = viewModel.SelectedCourseId;

			if (id.HasValue) // Edit
			{
				viewModel.Instructor.Id = id.Value;
				instructorBL.Update(viewModel.Instructor);
			}
			else // Create
			{
				instructorBL.Add(viewModel.Instructor);
			}

			return RedirectToAction("Index");
		}

		private void LoadDropdownData(InstructorForm viewModel)
		{
			DepartmentBL departmentBL = new DepartmentBL();
			CourseBL courseBL = new CourseBL();
			viewModel.DepartmentsItems = departmentBL.GetDepartmentItems();
			viewModel.CoursesItems = courseBL.GetCourseItems();
		}

		private bool IsValidInstructor(InstructorForm viewModel)
		{
			return viewModel?.Instructor?.Name != null &&
				   viewModel?.Instructor.Address != null &&
				   viewModel?.Instructor.Image != null &&
				   viewModel?.Instructor.Salary != null;
		}

	}


}
