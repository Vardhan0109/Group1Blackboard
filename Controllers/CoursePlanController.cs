
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Group1Blackboard.Models;

namespace Group1Blackboard.Controllers
{
    public class CoursePlanController : Controller
    {
        private readonly BlackboardContext context;

        public CoursePlanController(BlackboardContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            
var studentID = HttpContext.Session.GetInt32("CurrentStudentID");

if (studentID == null)
{
    var student = context.AppUsers
        .FirstOrDefault(u =>
            u.Name == "Alex Carter" &&
            u.Role == "Student");

    if (student != null)
    {
        HttpContext.Session.SetInt32(
            "CurrentStudentID",
            student.AppUserID);
    }
}

            var planSession = new CoursePlanSession(HttpContext);
            var plan = planSession.GetPlan();

            var courses = context.Courses
                .Include(c => c.Major)
                .Include(c => c.Instructor)
                .Where(c => plan.CourseIDs.Contains(c.CourseID))
                .ToList();

            return View(courses);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(int courseID)
        {
            var course = context.Courses
                .FirstOrDefault(c => c.CourseID == courseID);

            if (course == null)
            {
                return NotFound();
            }

            var planSession = new CoursePlanSession(HttpContext);
            var plan = planSession.GetPlan();

            if (!plan.CourseIDs.Contains(courseID))
            {
                plan.Add(courseID);
                planSession.SetPlan(plan);

                TempData["Message"] =
                    $"{course.CourseNumber} added to your course plan.";
            }
            else
            {
                TempData["Message"] =
                    $"{course.CourseNumber} is already in your plan.";
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remove(int courseID)
        {
            var planSession = new CoursePlanSession(HttpContext);
            var plan = planSession.GetPlan();

            plan.Remove(courseID);
            planSession.SetPlan(plan);

            TempData["Message"] =
                "Course removed from your plan.";

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Clear()
        {
            var planSession = new CoursePlanSession(HttpContext);

            planSession.ClearPlan();

            TempData["Message"] =
                "Your course plan has been cleared.";

            return RedirectToAction("Index");
        }
    }
}
