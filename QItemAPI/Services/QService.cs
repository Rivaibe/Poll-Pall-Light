using QItemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace QItemAPI.Services
{
    public class QService : IQService 
    {
        private readonly QItemContext _context;
        
        public QService(QItemContext context)
        {
            _context = context;
        }
        
        public async Task<List<QItem>> GetAItems()
        {
            return await _context.Qitems.ToListAsync();
        }
        
        public async Task<QItem> GetAItemByID(int? id)
        {
            var a = new QItem();
            if (id != null)
            {
                a = await _context.Qitems.FirstOrDefaultAsync(i => i.ID == id);
            }
            return a;
        }       
         
        public async void AddAItem(QItem qItem)
        {
            if (qItem != null)
                _context.Qitems.Add(qItem);
            await _context.SaveChangesAsync();
        }

        public async void DeleteAItem(int? id)
        {
            var a = _context.Qitems.FirstOrDefault(i => i.ID == id);
            if (a != null)
                _context.Qitems.Remove(a);
            await _context.SaveChangesAsync();           
        }
    }
}