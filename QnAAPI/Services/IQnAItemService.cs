using System.Collections.Generic;
using System.Threading.Tasks;
using QItemAPI.Models;
using QnAAPI.Models;

namespace QnAAPI.Services {
    public interface IQnAItemService {
        Task<List<QnAItem>> GetAItems();
        Task<QnAItem> GetAItemByID(int? id);
        void AddAItem(QnAItem qnAItem);
        void DeleteAItem(int? id);
    }
}
