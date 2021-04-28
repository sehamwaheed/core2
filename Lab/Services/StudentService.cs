using Lab.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Lab.Services
{
    public class StudentService : IService<Student>
    {

        private ITIModel _db;
        public StudentService(ITIModel db)
        {
            _db = db;
        }

        public List<Student> GetAll()
        {
            return _db.students.ToList();
        }


       

        public void Delete(int elment)
        {
            _db.students.Remove(Details(elment));
            _db.SaveChanges();
        }

        public Student Details(int id)
        {
            return _db.students.Where(r => r.Id == id).FirstOrDefault();
        }

        public void Edit(Student elment)
        {
            Student stu = Details(elment.Id);
            stu.Name = elment.Name;
            stu.Age = elment.Age;
            _db.SaveChanges();
        }

        public Student Add(Student elment)
        {
            _db.students.Add(elment);
            _db.SaveChanges();
           
            AddCoursesToStudent(elment);
            return elment;
        }
         
        private void AddCoursesToStudent(Student student)
        {
            List<Course> crs = _db.departments.Where(r => r.Id == student.DeptId).FirstOrDefault().Courses.ToList();
            for (int i = 0; i < crs.Count; i++)
            {
                _db.studentCourses.Add(new StudentCourse() { StudentId = student.Id, CourseId = crs[i].Id });
            }
            _db.SaveChanges();
        }


        
        
    }
}
