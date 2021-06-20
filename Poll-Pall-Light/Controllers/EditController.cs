using System;
using Microsoft.AspNetCore.Mvc;

namespace Poll_Pall_Light.Controllers 
{
    public class EditController : Controller 
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult EditP(int? id)
        {
            return View();
        }
        public IActionResult EditPItem()
        {
            return null;
        }
        public IActionResult EditQItem()
        {
            return null;
        }
        public IActionResult EditAItem()
        {
            return null;
        }
    }
}
