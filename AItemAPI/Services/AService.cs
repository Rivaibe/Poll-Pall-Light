using AItemAPI.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AItemAPI.Services
{
    public class AService : IAService {
        
        private readonly AItemContext _context;
        
        public AService(AItemContext context)
        {
            _context = context;
        }
        
        public List<AItem> GetAItems()
        {
            return _context.AItems.ToList();
        }
        
        public AItem GetAItemByID(int? id)
        {
            var a = _context.AItems.FirstOrDefault(i => i.ID == id);
            return a;
        }       
         
        public void AddAItem(AItem aItem)
        {
            if (aItem != null)
                _context.AItems.Add(aItem);
            _context.SaveChanges();
        }

        public void DeleteAItem(int? id)
        {
            var a = _context.AItems.FirstOrDefault(i => i.ID == id);
            if (a != null)
                _context.AItems.Remove(a);
            _context.SaveChanges();           
        }
    }
}
