using QnAAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QItemAPI.Models;

namespace QnAAPI.Services
{
    public class QnAItemService : IQnAItemService 
    {
        private readonly QnAItemContext _context;
        
        public QnAItemService(QnAItemContext context)
        {
            _context = context;
        }
        
        public async Task<List<QnAItem>> GetAItems()
        {
            return await _context.QnAItems.ToListAsync();
        }
        
        public async Task<QnAItem> GetAItemByID(int? id)
        {
            var a = new QnAItem();
            if (id != null)
                a = await _context.QnAItems.FirstOrDefaultAsync(i => i.ID == id);
            return a;
        }       
         
        public async void AddAItem(QnAItem qnAItem)
        {
            if (qnAItem != null)
                _context.QnAItems.Add(qnAItem);
            await _context.SaveChangesAsync();
        }

        public async void DeleteAItem(int? id)
        {
            var a = await _context.QnAItems.FirstOrDefaultAsync(i => i.ID == id);
            if (a != null)
                _context.QnAItems.Remove(a);
            await _context.SaveChangesAsync();           
        }
    }
}
