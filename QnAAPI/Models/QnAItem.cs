using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QnAAPI.Models
{
    public class QnAItem
    {
        [Key]
        public int ID { get; set; }
        public int PollId { get; set; }
        public int QItemId { get; set; }
        public int AItemId { get; set; }
    }
}
