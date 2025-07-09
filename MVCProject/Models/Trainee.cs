using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace MVCProject.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Grade { get; set; }

        public string Address { get; set; }

        //each trainee has 1 department
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public List<CrsResult> CourseResults { get; set; }


    }
}
