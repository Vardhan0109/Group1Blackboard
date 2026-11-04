

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Group1Blackboard.Models;

namespace Group1Blackboard.Controllers
{
    public class ReservationController : Controller
    {
        private readonly BlackboardContext context;

        public ReservationController(BlackboardContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            var studentID = HttpContext.Session.GetInt32("CurrentStudentID");

            if (studentID == null)
            {
                TempData["Error"] = "Please open My Plan first.";
                return RedirectToAction("Index", "CoursePlan");
            }

            var reservations = context.Reservations
                .Include(r => r.Course)
                .Include(r => r.AppUser)
                .Where(r => r.AppUserID == studentID.Value)
                .ToList();

            return View(reservations);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Reserve(int courseID)
        {
            var studentID = HttpContext.Session.GetInt32("CurrentStudentID");

            if (studentID == null)
            {
                TempData["Error"] = "Student session not found.";
                return RedirectToAction("Index", "CoursePlan");
            }

            var student = context.AppUsers
                .FirstOrDefault(u =>
                    u.AppUserID == studentID.Value &&
                    u.Role == "Student");

            var course = context.Courses
                .FirstOrDefault(c => c.CourseID == courseID);

            if (student == null || course == null)
            {
                TempData["Error"] = "Invalid student or course.";
                return RedirectToAction("Index", "CoursePlan");
            }

            var planSession = new CoursePlanSession(HttpContext);
            var plan = planSession.GetPlan();

            if (!plan.CourseIDs.Contains(courseID))
            {
                TempData["Error"] = "Course is not in your plan.";
                return RedirectToAction("Index", "CoursePlan");
            }

            bool alreadyReserved = context.Reservations.Any(
                r => r.CourseID == courseID &&
                     r.AppUserID == studentID.Value);

            if (alreadyReserved)
            {
                TempData["Error"] = "Course is already reserved.";
                return RedirectToAction("Index");
            }

            var reservation = new Reservation
            {
                CourseID = courseID,
                AppUserID = studentID.Value,
                ReservationDate = DateTime.Now
            };

            context.Reservations.Add(reservation);
            context.SaveChanges();

            plan.Remove(courseID);
            planSession.SetPlan(plan);

            TempData["Message"] = "Course reserved successfully.";

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cancel(int reservationID)
        {
            var studentID = HttpContext.Session.GetInt32("CurrentStudentID");

            if (studentID == null)
            {
                TempData["Error"] = "Student session not found.";
                return RedirectToAction("Index", "CoursePlan");
            }

            var reservation = context.Reservations
                .FirstOrDefault(r =>
                    r.ReservationID == reservationID &&
                    r.AppUserID == studentID.Value);

            if (reservation == null)
            {
                TempData["Error"] = "Reservation not found.";
                return RedirectToAction("Index");
            }

            context.Reservations.Remove(reservation);
            context.SaveChanges();

            TempData["Message"] = "Reservation cancelled successfully.";

            return RedirectToAction("Index");
        }
    }
}
