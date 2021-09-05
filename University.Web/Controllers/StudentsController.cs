using System;
using System.Collections.Generic;
using System.Web.Mvc;
using University.Web.Models;

namespace University.Web.Controllers
{
    public class StudentsController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {


            var students = new List<Student>();

            students.Add(new Student {ID = 1,FirstMidName = "David",LastName = "Santafe",EnrollmentDate = DateTime.Now});

            students.Add(new Student {ID = 2,FirstMidName = "Carson",LastName = "Alexander",EnrollmentDate =DateTime.Now});

            ViewBag.Data = "Data de prueba";
            ViewBag.Message = "Mensaje de prueba";

            return View(students);
        }

        [HttpGet]

        public ActionResult Create()
        {
           return View();
        }
        [HttpPost]
        public ActionResult Create(Student student)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(student);

                if (student.EnrollmentDate > DateTime.Now)
                    throw new Exception("La fecha de matricula no puede ser menor a la actual" );

                var id = student.ID;
                var firstMidName = student.FirstMidName;
                var lastName = student.LastName;
                var enrollmentDate = student.EnrollmentDate;
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View(student);
        }
    }
}