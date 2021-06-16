using System.Collections.Generic;
using System.Threading.Tasks;
using QItemAPI.Models;

namespace QItemAPI.Services {
    public interface IQService {
        Task<List<QItem>> GetQItems();
        Task<QItem> GetFirstQItemByPollId(int? id);
        Task<List<QItem>> GetQItemsByPollId(int? id);
        Task<QItem> GetQItemByID(int? id);
        void AddQItem(QItem qItem);
        void UpdateQItem(QItem qItem);
        void DeleteQItem(int? id);
    }
}
