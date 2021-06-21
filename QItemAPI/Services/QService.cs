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
        
        public async Task<List<QItem>> GetQItems()
        {
            return await _context.Qitems.ToListAsync();
        }
        
        public async Task<QItem> GetLastQItemByPollId(int? id)
        {
            var q = new QItem();
            if (id != null)
            {
                q = await _context.Qitems.OrderBy(x => x.ID).LastOrDefaultAsync(i => i.PollID == id);
            }
            return q; 
        }
        
        public async Task<List<QItem>> GetQItemsByPollId(int? id)
        {
            var qList = await _context.Qitems.Where(x => x.PollID == id).ToListAsync();

            return qList;
        }
        
        public List<QItem> GetQItemsByPollIdNa(int? id)
        {
            return _context.Qitems.Where(x => x.PollID == id).ToList();
        }       
        
        public async Task<QItem> GetQItemByID(int? id)
        {
            var a = new QItem();
            if (id != null)
            {
                a = await _context.Qitems.FirstOrDefaultAsync(i => i.ID == id);
            }
            return a;
        }       
         
        public void AddQItem(QItem qItem)
        {
            if (qItem != null)
                _context.Qitems.Add(qItem);
            _context.SaveChanges();
        }
        
        public void UpdateQItem(QItem qItem)
        {
            if (qItem != null)
                _context.Qitems.Update(qItem);
            _context.SaveChanges();
        }
        
        public void DeleteQItem(int? id)
        {
            var q = _context.Qitems.FirstOrDefault(i => i.ID == id);
            if (q != null)
                _context.Qitems.Remove(q);
            _context.SaveChanges();           
        }
        
        public void DeleteQItemsByPollId(int? id)
        {
            var a = _context.Qitems.Where(i => i.PollID == id);
            if (a.Any())
                _context.Qitems.RemoveRange(a);
            _context.SaveChanges();           
        } 
    }
}