using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollAPI.Models
{
    public class Poll
    {
        [Key]
        public int ID { get; set; }
        public string UserId { get; set; }
        public int QRootID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
