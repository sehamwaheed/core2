using Lab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab.Services
{
    public class DepartmentService : IDepartmentService
    {
        private ITIModel _db;
        public DepartmentService(ITIModel db)
        {
            _db = db;
        }

        public List<Department> GetAll()
        {
            return _db.departments.ToList();
        }

        public Department Add(Department elment)
        {
            _db.departments.Add(elment);
            _db.SaveChanges();
            return elment;
        }

        public void Delete(int elment)
        {
            _db.departments.Remove(Details(elment));
            _db.SaveChanges();
        }

        public Department Details(int id)
        {
            return _db.departments.Where(r => r.Id == id).FirstOrDefault();
        }

        public void Edit(Department elment)
        {
            Department dept = Details(elment.Id);
            dept.Name = elment.Name;
            _db.SaveChanges();
        }

        public List<Course> DepartmentCourses(int detId)
           
        {

            var u = _db.departments.Where(t => t.Id == detId).FirstOrDefault().Courses;
            return u;
              
        }
    }
}
