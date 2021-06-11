using QnAAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QnAAPI.Services
{
    public class QnAItemService : IQnAItemService
    {
        List<QnAItem> qnaItems;
        public List<QnAItem> GetQnAItems()
        {
            qnaItems = new List<QnAItem>
            {
                new QnAItem{QItemId = 1, AItemId = 1},
                new QnAItem{QItemId = 1, AItemId = 100},
                new QnAItem{QItemId = 2, AItemId = 1},
                new QnAItem{QItemId = 2, AItemId = 100},
            };
            return qnaItems;
        }
        public void AddQnaItem(QnAItem qnaItem)
        {
            qnaItems.Add(qnaItem);
        }
        public void DeleteQnaItem(QnAItem qnaItem)
        {
            qnaItems.Remove(qnaItem);
        }
    }
}
