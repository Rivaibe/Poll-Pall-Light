using QItemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QItemAPI.Services
{
    public class QService : IQService
    {
        private List<QItem> qItems;

        public List<QItem> GetQItems()
        {
            qItems = new List<QItem>
            {
                new QItem{ID = 1, Title = "Qtesttitle"},
                new QItem{ID = 2,Title = "QAndertesttitle"}
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
