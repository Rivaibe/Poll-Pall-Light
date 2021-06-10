using Poll_Pall_Light.Models.QnA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poll_Pall_Light.Services
{
    public class QService
    {
        private List<QItem> qItems;
        private ICollection<int> DumyCollection;

        public List<QItem> GetQItems()
        {
            DumyCollection.Add(1);
            DumyCollection.Add(2);
            qItems = new List<QItem>
            {
                new QItem{ID = 1, aItemsID = DumyCollection, Title = "Qtesttitle"},
                new QItem{ID = 2, aItemsID = DumyCollection, Title = "QAndertesttitle"}
            };

            return qItems;
        }
        public void AddQItem(QItem qItem)
        {
            qItems.Add(qItem);
        }

        public void DeleteQItem(QItem qItem)
        {
            qItems.Remove(qItem);
        }
    }
}
