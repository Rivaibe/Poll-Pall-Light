using System;

namespace PollAPI.Models 
{
    public class PollCurrentResult 
    {
        public int ID { get; set; }
        public int PollId { get; set; }
        public string UserId { get; set; }
        public int QId { get; set; }
        public int AId { get; set; } 
    }
}
