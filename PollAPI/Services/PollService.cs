using PollAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PollAPI.Services
{
    public class PollService : IPollService {
        private readonly PollContext _context;
        
        public PollService(PollContext context)
        {
            _context = context;
        }
        
        public async Task<List<Poll>> GetPolls()
        {
            return await _context.Polls.ToListAsync();
        }
        
        public async Task<Poll> GetPollById(int? id)
        {
            var a = new Poll();
            if (id != null)
            {
                a = await _context.Polls.FirstOrDefaultAsync(i => i.ID == id);
            }
            return a;
        }       
        
        public async Task<Poll> GetPollByQRootId(int? id)
        {
            var a = new Poll();
            if (id != null)
            {
                a = await _context.Polls.FirstOrDefaultAsync(i => i.QRootID == id);
            }
            return a;
        }   
        
        public void AddAItem(Poll poll)
        {
            if (poll != null)
                _context.Polls.Add(poll);
            _context.SaveChanges();
        }

        public void DeleteAItem(int? id)
        {
            var a = _context.Polls.FirstOrDefault(i => i.ID == id);
            if (a != null)
                _context.Polls.Remove(a);
            _context.SaveChangesAsync();           
        }
    }
}
