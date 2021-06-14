using Microsoft.AspNetCore.Mvc;

namespace Poll_Pall_Light.Controllers 
{
    public class UseController : Controller 
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}
