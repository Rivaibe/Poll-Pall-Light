using System.Collections.Generic;
using AItemAPI.Models;
using PollAPI.Models;
using QItemAPI.Models;

namespace Poll_Pall_Light.Models 
{
    public class PollCreateViewModel 
    {
        public Poll Poll { get; set; }
        public QItem QItem { get; set; }
    }
}
