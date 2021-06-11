using AItemAPI.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AItemAPI.Services
{
    public class AService : IAService
    {
        List<AItem> aItems;
        List<int> DummyCollection;

        public List<AItem> GetAItems()
        {
            DummyCollection = new();
            DummyCollection.Add(1);
            DummyCollection.Add(2);
            aItems = new List<AItem>
            {
                new AItem{ID = 1, QItemID = 1, Title = "JA", isChecked =false },
                new AItem{ID = 100, QItemID = 2, Title = "NEE", isChecked =false}
            };
            return aItems;
        }
        public void AddAItem(AItem aItem)
        {
            aItems.Add(aItem);
        }

        public void DeleteAItem(AItem aItem)
        {
            aItems.Remove(aItem);
        }
    }
}
