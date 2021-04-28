using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Lab.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20,MinimumLength =3)]
        public string Name { get; set; }
        [Required]
        [Range(10,30)]
        public int Age { get; set; }
        public string image { get; set; }

        [ForeignKey("Department")]
        public int DeptId { get; set; }

        public virtual Department Department { get; set; }
        public virtual List<StudentCourse> StudentCourses { get; set; }
    }
}
