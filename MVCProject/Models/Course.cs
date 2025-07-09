using Microsoft.AspNetCore.Cors.Infrastructure;

namespace MVCProject.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Degree { get; set; }
        public int MinDegree { get; set; }

        //each cousre has 1 department
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public List<Instructor> Instructors { get; set; }
        public List<CrsResult> CourseResults { get; set; }

    }
}
