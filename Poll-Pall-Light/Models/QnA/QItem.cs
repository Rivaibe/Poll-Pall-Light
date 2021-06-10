using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poll_Pall_Light.Models.QnA
{
    public class QItem
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public ICollection<int> aItemsID { get; set; }
    }
}
