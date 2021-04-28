using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20,MinimumLength =3)]
        public string CourseName { get; set; }

        public virtual List<StudentCourse> StudentCourses { get; set; }
        public virtual List<Department> Departments { get; set; }

    }
}
