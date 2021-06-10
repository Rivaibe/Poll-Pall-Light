using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AItemAPI.Models
{
    public class AItem
    {
        public int ID { get; set; }
        public int QItemID { get; set; }
        public string Title { get; set; }
        public bool isChecked { get; set; }
    }
}
