using System.Collections.Generic;
using PollAPI.Models;
using QItemAPI.Models;

namespace Poll_Pall_Light.Models 
{
    public class PItemViewModel 
    {
        public string PollTitle { get; set; }
        public string PollDescription { get; set; }
        public string QTitle { get; set; }
        public List<QItem> QItems { get; set; }
        public List<Poll> Polls { get; set; }
    }
}
