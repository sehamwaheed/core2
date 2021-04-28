using Lab.Models;
using Lab.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab.Controllers
{
    public class DepartmentController : Controller
    {
        private IDepartmentService _department;
        private ICourseService _course;
        public DepartmentController(IDepartmentService department, ICourseService course)
        {
     
            _department = department;
            _course = course;
        }
        public IActionResult Index()
        {

            return View(_department.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
       
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department dept)
        {
            if (ModelState.IsValid)
            {
                _department.Add(dept);
                return RedirectToAction("Index");
            }
            return View(dept);
        }



        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_department.Details(id));
        }


        [HttpPost]
        public IActionResult Edit(Department dept)
        {
            if (ModelState.IsValid)
            {
                _department.Edit(dept);
                return RedirectToAction("Index");
            }
            return View(dept);
        }



       
        public IActionResult Delete(int id)
        {
            _department.Delete(id);
            return RedirectToAction("Index");

        }


        public IActionResult Details(int id)
        {

            return View(_department.Details(id));

        }

        [HttpGet]
        public IActionResult AddCourses(int id)
        {
            return View(_course.GetAvaliableCourses(id)); 
        }

        [HttpPost]
        public ActionResult AddCourses(int id, Dictionary<string, bool> crs)
        {
            _course.AddCourseToDepartment(id, crs);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult RemoveCourses(int id)
        {
            return View(_course.GetDeptCourses(id));
        }

        [HttpPost]
        public ActionResult RemoveCourses(int id, Dictionary<string, bool> crs)
        {
            _course.RemoveCourseFromDepartment(id, crs);
            return RedirectToAction("Index");
        }


        /************************************ mange degree of student **************************************/


        [HttpGet]
        public ActionResult GetDepts()
        {
            return View(_department.GetAll());
        }


    }
}
