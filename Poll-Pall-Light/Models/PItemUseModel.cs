using System.Collections.Generic;
using AItemAPI.Models;
using PollAPI.Models;
using QItemAPI.Models;

namespace Poll_Pall_Light.Models 
{
    public class PItemUseModel 
    {
        public string PollTitle { get; set; }
        public string PollDescription { get; set; }
        public string QTitle { get; set; }
        public List<QItem> QItems { get; set; }
        public List<AItem> AItems { get; set; }
        public Poll Poll { get; set; } 
    }
}
