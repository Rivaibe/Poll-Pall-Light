using System.Collections.Generic;
using PollAPI.Models;
using QItemAPI.Models;

namespace Poll_Pall_Light.Models 
{
    public class PItemEditViewModel 
    {
        public string PollTitle { get; set; }
        public int TapId { get; set; }
        public Poll Tap { get; set; }
        public string PollDescription { get; set; }
        public string UserId { get; set; }
        public List<QItem> QItems { get; set; }
        public bool IsPrivate { get; set; }
        public List<Poll> Polls { get; set; }
        public bool AText { get; set; }
        public bool AImages { get; set; }
        public bool AImagesText { get; set; }
        public bool AResult { get; set; }
        public bool QText { get; set; }
        public bool QImages { get; set; }
        public bool QImagesText { get; set; }
        public bool QResult { get; set; }       
        public ResultViewModel ResultViewModel { get; set; }        
    }
}
