using Microsoft.AspNetCore.Mvc;

namespace Poll_Pall_Light.Controllers 
{
    public class DeleteController : Controller 
    {
        public IActionResult DeleteQItem(int? id)
        {
            return View("/Views/Create/QView.cshtml");
        } 
    }
}
