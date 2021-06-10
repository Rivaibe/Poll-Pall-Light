﻿using Poll_Pall_Light.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poll_Pall_Light.Services
{
    public class PollService : IPollService
    {
        List<Poll> polls;
        public List<Poll> GetPolls()
        {
            polls = new List<Poll>
            {
                new Poll{ID = 1, QRootID = 1, Title = "eentesttitle"},
                new Poll{ID = 2, QRootID = 100, Title = "eenAndertesttitle"},
            };
            return polls;
        }
        public void AddPoll(Poll poll)
        {
            polls.Add(poll);
        }
        public void DeletePoll(Poll poll)
        {
            polls.Remove(poll);
        }
    }
}
