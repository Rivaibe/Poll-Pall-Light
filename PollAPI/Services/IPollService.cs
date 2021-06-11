using PollAPI.Models;
using System.Collections.Generic;

namespace PollAPI.Services
{
    public interface IPollService
    {
        void AddPoll(Poll poll);
        void DeletePoll(Poll poll);
        List<Poll> GetPolls();
    }
}