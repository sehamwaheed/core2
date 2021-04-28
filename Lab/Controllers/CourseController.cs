using Lab.Models;
using Lab.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab.Controllers
{
    public class CourseController : Controller
    {
        private ICourseService _course;
        public CourseController(ICourseService course)
        {

            _course = course;
        }
        public IActionResult Index()
        {

            return View(_course.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Course crs)
        {
            if (ModelState.IsValid)
            {
                _course.Add(crs);
                return RedirectToAction("Index");
            }
            return View(crs);
        }



        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_course.Details(id));
        }


        [HttpPost]
        public IActionResult Edit(Course dept)
        {
            if (ModelState.IsValid)
            {
                _course.Edit(dept);
                return RedirectToAction("Index");
            }
            return View(dept);
        }




        public IActionResult Delete(int id)
        {
            _course.Delete(id);
            return RedirectToAction("Index");

        }


        public IActionResult Details(int id)
        {

            return View(_course.Details(id));

        }

        public IActionResult GetCoursesForDegree(int id)
        {
            var t = _course.GetDeptCourses(id);
            ViewBag.deptId = id;
             return PartialView("PartialCoursesForDegree", t);
        }

       
        public IActionResult GetStudentCourseForDegree(int id,int deptId)
        {
            var t = _course.getStudentsInCourse(id,deptId);
            return PartialView("PartialStudentCourseForDegree", t);
        }

        [HttpPost]
        public IActionResult AddDegree(int StudentId, int CourseId,int degree)
        {
            
            _course.AddStudentDegree(new StudentCourse() {StudentId=StudentId,CourseId=CourseId,degree=degree});
            return RedirectToAction("GetDepts", "Department");
        }

    }
}
