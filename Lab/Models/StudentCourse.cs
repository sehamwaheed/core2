using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Lab.Models
{
    public class StudentCourse
    {
       
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        [Range(0, 100)]
        public float degree { get; set; }
        
        public virtual Student student { get; set; }
        
        public virtual Course course  { get; set; }
    }
}
