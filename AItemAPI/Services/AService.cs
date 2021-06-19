using AItemAPI.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AItemAPI.Services
{
    public class AService : IAService {
        
        private readonly AItemContext _context;
        
        public AService(AItemContext context)
        {
            _context = context;
        }
        
        public async Task<List<AItem>> GetAItems()
        {
            return await _context.AItems.ToListAsync();
        }
        
        public async Task<AItem> GetAItemByID(int? id)
        {
            if (id == null)
                return null;
            
            var a = await _context.AItems.FirstOrDefaultAsync(i => i.ID == id);
            return a;
        }       
        
        public async Task<List<AItem>> GetAItemsByQId(int? id)
        {
            var aList = await _context.AItems.Where(x => x.QItemID == id).ToListAsync();

            return aList;
        } 
        
        public void AddAItem(AItem aItem)
        {
            if (aItem != null)
                _context.AItems.Add(aItem);
            _context.SaveChanges();
        }
        
        public void UpdateAItem(AItem aItem)
        {
            if (aItem != null)
                _context.AItems.Update(aItem);
            _context.SaveChanges();
        }
        
        public void DeleteAItem(int? id)
        {
            var a = _context.AItems.FirstOrDefault(r => r.ID == id);
            if (a != null)
                _context.AItems.Remove(a);
            _context.SaveChanges();           
        }
        
        public void DeleteAItemsByQId(int? id)
        {
            var a = _context.AItems.Where(r => r.QItemID == id);
            if (a.Any())
                _context.AItems.RemoveRange(a);
            _context.SaveChanges();           
        }
    }
}
