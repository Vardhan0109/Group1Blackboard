
using Microsoft.AspNetCore.Mvc;
using Group1Blackboard.Models;

namespace Group1Blackboard.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private BlackboardContext context;

        public UserController(BlackboardContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            var users = context.AppUsers.ToList();
            return View(users);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AppUser user)
        {
            if (ModelState.IsValid)
            {
                context.AppUsers.Add(user);
                context.SaveChanges();

                TempData["message"] = "User added successfully.";
                return RedirectToAction("Index");
            }

            return View(user);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var user = context.AppUsers.Find(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(AppUser user)
        {
            if (ModelState.IsValid)
            {
                context.AppUsers.Update(user);
                context.SaveChanges();

                TempData["message"] = "User updated successfully.";
                return RedirectToAction("Index");
            }

            return View(user);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var user = context.AppUsers.Find(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var user = context.AppUsers.Find(id);

            if (user != null)
            {
                context.AppUsers.Remove(user);
                context.SaveChanges();

                TempData["message"] = "User deleted successfully.";
            }

            return RedirectToAction("Index");
        }
    }
}
