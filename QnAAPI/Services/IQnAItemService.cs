using System.Collections.Generic;
using System.Threading.Tasks;
using QItemAPI.Models;
using QnAAPI.Models;

namespace QnAAPI.Services {
    public interface IQnAItemService {
        Task<List<QnAItem>> GetAItems();
        Task<QItem> GetAItemByID(int? id);
        void AddAItem(QItem qItem);
        void DeleteAItem(int? id);
    }
}
