using System.Collections.Generic;
using System.Threading.Tasks;
using QItemAPI.Models;

namespace QItemAPI.Services {
    public interface IQService {
        Task<List<QItem>> GetAItems();
        Task<QItem> GetAItemByID(int? id);
        void AddAItem(QItem qItem);
        void DeleteAItem(int? id);
    }
}
