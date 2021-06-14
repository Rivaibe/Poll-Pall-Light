using System.Collections.Generic;
using System.Threading.Tasks;
using PollAPI.Models;

namespace PollAPI.Services {
    public interface IPollService {
        Task<List<Poll>> GetAItems();
        Task<Poll> GetAItemByID(int? id);
        void AddAItem(Poll poll);
        void DeleteAItem(int? id);
    }
}
