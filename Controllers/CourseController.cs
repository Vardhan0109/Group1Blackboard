
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Group1Blackboard.Models;

namespace Group1Blackboard.Controllers
{
    public class CourseController : Controller
    {
        private BlackboardContext context;

        public CourseController(BlackboardContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index(
            int? majorID,
            string semester = "All",
            string location = "All")
            
        {
            var courses = context.Courses
                .Include(c => c.Major)
                .Include(c => c.Instructor)
                .AsQueryable();

            if (majorID.HasValue)
            {
                courses = courses.Where(
                    c => c.MajorID == majorID.Value);
            }

            if (semester != "All")
            {
                courses = courses.Where(
                    c => c.OfferedSemester == semester);
            }

            if (location != "All")
            {
                courses = courses.Where(
                    c => c.Location == location);
            }

            var model = new CourseCatalogViewModel
            {
                Courses = courses.ToList(),
                Majors = context.Majors.ToList(),
                SelectedMajorID = majorID,
                SelectedSemester = semester,
                SelectedLocation = location
            };

            return View(model);
        }
        
public IActionResult Details(int id)
{
    var course = context.Courses
        .Include(c => c.Major)
        .Include(c => c.Instructor)
        .FirstOrDefault(c => c.CourseID == id);

    if (course == null)
    {
        return NotFound();
    }

    return View(course);
}

    }
}
