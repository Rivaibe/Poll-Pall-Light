using System.Collections.Generic;
using System.Threading.Tasks;
using PollAPI.Models;

namespace PollAPI.Services {
    public interface IPollService {
        /// <summary>
        /// Poll
        /// </summary>
        /// <returns></returns>
        Task<List<Poll>> GetPolls();
        Task<List<Poll>> GetPollsByUserId(string id);
        Task<List<Poll>> SortPollsByNameByPollId(string id);
        Task<List<Poll>> SortPollsByNameByPollIdDescending(string id);
        Task<Poll> GetPollById(int? id);
        Task<Poll> GetPollByQRootId(int? id);
        void AddPItem(Poll poll);
        void UpdatePItem(Poll poll);
        void DeletePItem(int? id);
        
        
        /// <summary>
        /// Poll Results
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<List<PollResult>> GetPollResultsByPollId(int? id);
        Task<List<PollCurrentResult>> GetCurrentPollResultsByUserId(string id);
        void AddResultItem(PollResult pollResult);
        
        /// <summary>
        /// Poll Variables
        /// </summary>
        /// <param name="pollVariables"></param>
        void AddPollVariableItem(PollVariables pollVariables);
        public Task<List<PollVariables>> GetPollVariablesByPollAndQId(int? pId, int? qId);
        public Task<List<PollVariables>> GetPollVariablesByPollAndAAndQId(int? pId, int? qId, int? aId);
        public List<PollVariables> GetPollVariablesByPollAndQIdNa(int? pId, int? qId);
        public List<PollVariables> GetPollVariablesByPollAndAAndQIdNa(int? pId, int? qId, int? aId);        
    }
}
