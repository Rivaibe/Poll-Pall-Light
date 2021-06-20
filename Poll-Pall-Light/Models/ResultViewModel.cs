using System.Collections.Generic;
using PollAPI.Models;

namespace Poll_Pall_Light.Models 
{
    public class ResultViewModel 
    {
        public List<PollCurrentResult> CurrentResults { get; set; }
        public List<string> QTitle = new();
        public List<string> Result = new();
    }
}
