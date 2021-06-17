using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using AItemAPI.Models;
using PollAPI.Models;
using QItemAPI.Models;
using QnAAPI.Services;

namespace Poll_Pall_Light.Models 
{
    public class QItemViewModel 
    {
        public int PollID { get; set; }
        public string PollTitle { get; set; }
        [AllowNull]
        public List<QItem> QItems { get; set; }
        public List<AItem> AItems { get; set; }
        public QCreateViewModel QCreateViewModel { get; set; }
    }
}
