using Lab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab.Services
{
    public class CourseService : ICourseService
    {
        private ITIModel _db;
        public CourseService(ITIModel db)
        {
            _db = db;
        }

        public List<Course> GetAll()
        {
            return _db.courses.ToList();
        }

        public Course Add(Course elment)
        {
            _db.courses.Add(elment);
            _db.SaveChanges();
            return elment;
        }

        public void Delete(int elment)
        {
            _db.courses.Remove(Details(elment));
            _db.SaveChanges();
        }

        public Course Details(int id)
        {
            return _db.courses.Where(r => r.Id == id).FirstOrDefault();
        }

        public void Edit(Course elment)
        {
            Course crs = Details(elment.Id);
            crs.CourseName = elment.CourseName;
            _db.SaveChanges();
        }

        public List<Course> GetAvaliableCourses(int DeptId)
        {
            var allCrs = _db.courses.ToList();
            var crsInDept = _db.departments.Where(e => e.Id == DeptId).FirstOrDefault().Courses;
            if (crsInDept == null)
            {
                return allCrs.ToList();
            }
            
            return allCrs.Except(crsInDept).ToList();
        }

        public void AddCourseToDepartment(int DeptId, Dictionary<string, bool> crs)
        {
            foreach (var item in crs)
            {

                if (item.Value)
                {
                    int x = int.Parse(item.Key);
                    _db.departments.Where(r => r.Id == DeptId).FirstOrDefault().Courses.Add(_db.courses.FirstOrDefault(e => e.Id == x));
                }
            }
            _db.SaveChanges();
        }

      
        public List<Course> GetDeptCourses(int DeptId)
        {
            return _db.departments.Where(r => r.Id == DeptId).FirstOrDefault().Courses;
        }

        public void RemoveCourseFromDepartment(int DeptId, Dictionary<string, bool> crs)
        {
            foreach (var item in crs)
            {

                if (item.Value)
                {
                    int x = int.Parse(item.Key);
                    _db.departments.Where(r => r.Id == DeptId).FirstOrDefault().Courses.Remove(_db.courses.FirstOrDefault(e => e.Id == x));
                }
            }
            _db.SaveChanges();
        }

        public List<StudentCourse> getStudentsInCourse(int crsid,int DeptId)
        {
            var r = _db.courses.Where(r => r.Id == crsid &&r.Departments.Select(t=>t.Id== DeptId).FirstOrDefault()).FirstOrDefault().StudentCourses.ToList();
            return r;
        }

        public void AddStudentDegree(StudentCourse studentCourses)
        {

            _db.studentCourses.Where(r => r.CourseId == studentCourses.CourseId && r.StudentId == studentCourses.StudentId).FirstOrDefault().degree = studentCourses.degree;
            _db.SaveChanges();
        }
    }
}
