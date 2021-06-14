using Microsoft.AspNetCore.Mvc;

namespace Poll_Pall_Light.Controllers
{
	public class ProductController : Controller
	{
		// GET
		public IActionResult Index()
		{
			return View();
		}
	}
}