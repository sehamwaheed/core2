using Lab.Models;
using Lab.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Lab.Controllers
{
    public class StudentController : Controller
    {

        private IService<Student> _student;
        private IDepartmentService _department;
        private ITIModel _db;
        public StudentController(IService<Student> student, IDepartmentService department, ITIModel db)
        {
            _student = student;
            _department = department;
            _db = db;
          
        }
        public IActionResult Index()
        {
           
            return View(_student.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.ListofDepartment = _department.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student, IFormFile files)
        {
            if (ModelState.IsValid)
            {
                Student stu = _student.Add(student);
                _ = UploadFileAsync(stu, files);
                return RedirectToAction("Index");
            }
            return View(student);
        }



        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.ListofDepartment = _department.GetAll();
            return View(_student.Details(id));
        }


        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _student.Edit(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }



      
        public IActionResult Delete(int id)
        {
          _student.Delete(id);
          return RedirectToAction("Index");
           
        }

       [HttpGet]
        public IActionResult Details(int id)
        {
            var t = _student.Details(id);


            return View(t);

        }


        private async Task UploadFileAsync( Student student , IFormFile file)
        {
            var fileExtension = Path.GetExtension(Path.GetFileName(file.FileName));
            var newFileName = String.Concat(Convert.ToString(student.Id), fileExtension);
            string filePath = Path.Combine("wwwroot/images", newFileName);
            student.image = newFileName;
            _db.SaveChanges();

            using (Stream fileStream = new FileStream(filePath, FileMode.Create))
            {

                await file.CopyToAsync(fileStream);
            }

        }




    }
}
