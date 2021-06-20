using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using AItemAPI.Models;
using QItemAPI.Models;
using SelectListItem=Microsoft.AspNetCore.Mvc.Rendering.SelectListItem;

namespace Poll_Pall_Light.Models 
{
    public class AItemViewModel 
    {
        public string Title { get; set; }
        public int PollId { get; set; }
        public bool rightAnswer { get; set; }
        public AItem AItem { get; set; }
        public List<AItem> AItems { get; set; }
        public string QId { get; set; }
        public List<QItem> QConnectedByPollId { get; set; }
    }
}
