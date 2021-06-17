using System.Collections.Generic;
using System.Threading.Tasks;
using PollAPI.Models;

namespace PollAPI.Services {
    public interface IPollService {
        Task<List<Poll>> GetPolls();
        Task<List<Poll>> GetPollsByUserId(string id);
        Task<List<Poll>> SortPollsByNameByPollId(string id);
        Task<List<Poll>> SortPollsByNameByPollIdDescending(string id);
        Task<Poll> GetPollById(int? id);
        Task<Poll> GetPollByQRootId(int? id);
        void AddPItem(Poll poll);
        void UpdatePItem(int? id);
        void DeletePItem(int? id);
    }
}
