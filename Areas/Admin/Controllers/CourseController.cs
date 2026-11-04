
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Group1Blackboard.Models;

namespace Group1Blackboard.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController : Controller
    {
        private BlackboardContext context;

        public CourseController(BlackboardContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            var courses = context.Courses
                .Include(c => c.Major)
                .Include(c => c.Instructor)
                .ToList();

            return View(courses);
        }

        [HttpGet]
        public IActionResult Add()
        {
            LoadDropDowns();
            return View();
        }

        [HttpPost]
        public IActionResult Add(Course course)
        {
            if (ModelState.IsValid)
            {
                context.Courses.Add(course);
                context.SaveChanges();

                TempData["message"] = "Course added successfully.";
                return RedirectToAction("Index");
            }

            LoadDropDowns();
            return View(course);
        }
        
        
[HttpGet]
public IActionResult Edit(int id)
{
    var course = context.Courses.Find(id);

    if (course == null)
    {
        return NotFound();
    }

    LoadDropDowns();
    return View(course);
}

[HttpPost]
public IActionResult Edit(Course course)
{
    if (ModelState.IsValid)
    {
        context.Courses.Update(course);
        context.SaveChanges();

        TempData["message"] = "Course updated successfully.";
        return RedirectToAction("Index");
    }

    LoadDropDowns();
    return View(course);
}

[HttpGet]
public IActionResult Delete(int id)
{
    var course = context.Courses
        .Include(c => c.Major)
        .FirstOrDefault(c => c.CourseID == id);

    if (course == null)
    {
        return NotFound();
    }

    return View(course);
}

[HttpPost]
public IActionResult DeleteConfirmed(int id)
{
    var course = context.Courses.Find(id);

    if (course != null)
    {
        context.Courses.Remove(course);
        context.SaveChanges();

        TempData["message"] = "Course deleted successfully.";
    }

    return RedirectToAction("Index");
}


        private void LoadDropDowns()
        {
            ViewBag.Majors = new SelectList(
                context.Majors.ToList(),
                "MajorID", "Name");

            ViewBag.Instructors = new SelectList(
                context.AppUsers
                    .Where(u => u.Role == "Instructor")
                    .ToList(),
                "AppUserID", "Name");
        }
    }
}

