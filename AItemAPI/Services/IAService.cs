using System.Collections.Generic;
using System.Threading.Tasks;
using AItemAPI.Models;

namespace AItemAPI.Services {
    public interface IAService {
        Task <List<AItem>> GetAItems();
        List<AItem> GetAItemsByQIdNa(int? id);
        Task <List<AItem>> GetAItemsByQId(int? id);
        Task <AItem> GetAItemByID(int? id);
        Task <AItem> GetLastAItemByQID(int? id);
        void AddAItem(AItem aItem);
        void UpdateAItem(AItem aItem);
        void DeleteAItem(int? id);
        void DeleteAItemsByQId(int? id);
    }
}
