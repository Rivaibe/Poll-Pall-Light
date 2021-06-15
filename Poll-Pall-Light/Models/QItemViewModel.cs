using System.Collections.Generic;
using PollAPI.Models;
using QItemAPI.Models;

namespace Poll_Pall_Light.Models 
{
    public class QItemViewModel 
    {
        public int PollID { get; set; }
        public string PollTitle { get; set; }
        public List<QItem> QItems { get; set; }
        public QCreateViewModel QCreateViewModel { get; set; }
    }
}
