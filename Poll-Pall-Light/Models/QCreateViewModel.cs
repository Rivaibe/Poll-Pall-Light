using System.ComponentModel.DataAnnotations;
using AItemAPI.Models;

namespace Poll_Pall_Light.Models 
{
    public class QCreateViewModel 
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        public AItem AItem { get; set; }
    }
}
