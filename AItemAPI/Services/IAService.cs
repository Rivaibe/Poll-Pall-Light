using System.Collections.Generic;
using System.Threading.Tasks;
using AItemAPI.Models;

namespace AItemAPI.Services {
    public interface IAService {
        Task <List<AItem>> GetAItems();
        Task <AItem> GetAItemByID(int? id);
        void AddAItem(AItem aItem);
        void DeleteAItem(int? id);
    }
}
