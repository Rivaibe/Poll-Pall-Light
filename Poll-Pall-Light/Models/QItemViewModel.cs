using System.Collections.Generic;
using AItemAPI.Models;
using PollAPI.Models;
using QItemAPI.Models;

namespace Poll_Pall_Light.Models 
{
    public class QItemViewModel 
    {
        public int PollID { get; set; }
        public string PollTitle { get; set; }
        public List<QItem> QItems { get; set; }
        public List<AItem> AItems { get; set; }
        public QCreateViewModel QCreateViewModel { get; set; }
    }
}
