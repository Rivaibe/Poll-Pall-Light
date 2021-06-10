using AItemAPI.Models;
using System.Collections.Generic;

namespace AItemAPI.Services
{
    public interface IAService
    {
        void AddAItem(AItem aItem);
        void DeleteAItem(AItem aItem);
        List<AItem> GetAItems();
    }
}