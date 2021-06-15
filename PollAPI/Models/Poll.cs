using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollAPI.Models
{
    public class Poll
    {
        public int ID { get; set; }
        public int QRootID { get; set; }
        public string Title { get; set; }
        
        // TODO - Add poll description
    }
}
