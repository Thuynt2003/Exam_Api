using Microsoft.AspNetCore.Mvc;

namespace DMAWS_T2204M_Thuy.Controllers
{
    public class ProjectsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
