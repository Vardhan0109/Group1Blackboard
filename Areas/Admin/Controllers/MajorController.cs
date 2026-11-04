
using Microsoft.AspNetCore.Mvc;
using Group1Blackboard.Models;

namespace Group1Blackboard.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MajorController : Controller
    {
        private BlackboardContext context;

        public MajorController(BlackboardContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            var majors = context.Majors.ToList();
            return View(majors);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Major major)
        {
            if (ModelState.IsValid)
            {
                context.Majors.Add(major);
                context.SaveChanges();

                TempData["message"] = "Major added successfully.";
                return RedirectToAction("Index");
            }

            return View(major);
        }
        
[HttpGet]
public IActionResult Edit(int id)
{
    var major = context.Majors.Find(id);

    if (major == null)
    {
        return NotFound();
    }

    return View(major);
}

[HttpPost]
public IActionResult Edit(Major major)
{
    if (ModelState.IsValid)
    {
        context.Majors.Update(major);
        context.SaveChanges();

        TempData["message"] = "Major updated successfully.";
        return RedirectToAction("Index");
    }

    return View(major);
}

[HttpGet]
public IActionResult Delete(int id)
{
    var major = context.Majors.Find(id);

    if (major == null)
    {
        return NotFound();
    }

    return View(major);
}

[HttpPost]
public IActionResult DeleteConfirmed(int id)
{
    var major = context.Majors.Find(id);

    if (major != null)
    {
        context.Majors.Remove(major);
        context.SaveChanges();

        TempData["message"] = "Major deleted successfully.";
    }

    return RedirectToAction("Index");
}

    }
}
