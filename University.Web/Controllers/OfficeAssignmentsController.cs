using System.Linq;
using System.Web.Mvc;
using University.BL.Data;
using University.BL.DTOs;

namespace University.Web.Controllers
{
    public class OfficeAssignmentsController : Controller
    {
        private readonly UniversityContext context = new UniversityContext();

        // GET: OfficeAssignments
        public ActionResult Index()
        {
            var query = context.officeAssignments.Include("Instructor").ToList();
            var offices = query.Select(x => new OfficeAssignmentsDTO
            {
                InstructorID = x.InstructorID,
                Location = x.Location,
                Instructor = new InstructorDTO
                {
                    FirstMidName = x.Instructor.FirstMidName,
                    LastName = x.Instructor.LastName
                }
            });

            return View(offices);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var instructors = context.Instructors.Select(x => new InstructorDTO
            {
                ID = x.ID,
                FirstMidName = x.FirstMidName,
                LastName = x.LastName
            }).ToList();

            ViewData["Instructors"] = new SelectList(instructors, "ID", "FullName");

            return View();

        }
        [HttpPost]
        public ActionResult Create(OfficeAssignmentsDTO office)
        {
            LoadData();

            if (!ModelState.IsValid)
                return View(ModelState);

            context.officeAssignments.Add(new BL.Models.OfficeAssignment
            {
                InstructorID = office.InstructorID,
                Location = office.Location
            });
            context.SaveChanges();

            return RedirectToAction("Index");

        }

        private void LoadData()
        {
            var instructors = context.Instructors.Select(x => new InstructorDTO
            {
                ID = x.ID,
                FirstMidName = x.FirstMidName,
                LastName = x.LastName
            }).ToList();

            ViewData["Instructors"] = new SelectList(instructors, "ID", "FullName");

        }
    }
}
