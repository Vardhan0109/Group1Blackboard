using Microsoft.AspNetCore.Mvc;

namespace Group1Blackboard.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return Content(
                "Area: Admin, Controller: Course, Action: Index"
            );
        }
    }
}