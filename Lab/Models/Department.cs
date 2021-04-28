using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20,MinimumLength =3)]
        public string Name { get; set; }

        public virtual List<Student> Students { get; set; }
        public virtual List<Course> Courses { get; set; }

    }
}
