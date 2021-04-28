using Lab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab.Services
{
    public interface ICourseService:IService<Course>
    {
        public List<Course> GetAvaliableCourses(int DeptId);
        public void AddCourseToDepartment(int DeptId , Dictionary<string,bool> dic);
        public void RemoveCourseFromDepartment(int DeptId , Dictionary<string,bool> dic);
        public List<Course> GetDeptCourses(int id);

        public List<StudentCourse> getStudentsInCourse(int crsid,int DeptId);
        public void AddStudentDegree(StudentCourse studentCourses);
    }
}
