using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using AItemAPI.Models;
using Microsoft.AspNetCore.Http;
using PollAPI.Models;
using QItemAPI.Models;

namespace Poll_Pall_Light.Models 
{
    public class QItemEditViewModel 
    {
         public int? PollID { get; set; }
         public QItem QItem { get; set; }
         public string PollTitle { get; set; }
         [AllowNull]
         public List<QItem> QItems { get; set; }
         public List<PollVariables> VariablesList { get; set; }
         public List<AItem> AItems { get; set; }
         public QCreateViewModel QCreateViewModel { get; set; }
         public PollVariables PollVariables { get; set; }
         public PollVariables NewPollVariables { get; set; }
         public bool QText { get; set; }
         public bool QImage { get; set; }
         public bool QBool { get; set; }
         public bool QNumber { get; set; }
         public IFormFile Image { get; set; }
         public string ImagePath { get; set; }       
    }
}
