using Poll_Pall_Light.Models;
using System.Collections.Generic;

namespace Poll_Pall_Light.Services
{
    public interface IPollService
    {
        void AddPoll(Poll poll);
        void DeletePoll(Poll poll);
        List<Poll> GetPolls();
    }
}