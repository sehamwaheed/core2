using Lab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab.Services
{
    public interface IDepartmentService: IService<Department>
    {
        public List<Course> DepartmentCourses(int detId);
    }
}
