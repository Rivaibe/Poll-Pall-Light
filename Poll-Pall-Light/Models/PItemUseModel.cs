using System.Collections.Generic;
using AItemAPI.Models;
using PollAPI.Models;
using QItemAPI.Models;

namespace Poll_Pall_Light.Models 
{
    public class PItemUseModel 
    {
        public List<QItem> QItems { get; set; }
        public List<AItem> AItems { get; set; }
        public Poll Poll { get; set; } 
        public bool isChecked { get; set; }
    }
}
