using System.Collections.Generic;
using AItemAPI.Models;

namespace AItemAPI.Services {
    public interface IAService {
        List<AItem> GetAItems();
        AItem GetAItemByID(int? id);
        void AddAItem(AItem aItem);
        void DeleteAItem(int? id);
    }
}
