
using QItemAPI.Models;
using System.Collections.Generic;

namespace QItemAPI.Services
{
    public interface IQService
    {
        void AddQItem(QItem qItem);
        void DeleteQItem(QItem qItem);
        List<QItem> GetQItems();
    }
}