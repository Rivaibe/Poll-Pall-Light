using AItemAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.EntityFrameworkCore;

namespace QItemAPI.Models
{
    public class QItem 
    {
        public int ID { get; set; }
        public int? PollID { get; set; }
        public string Title { get; set; }
        public bool EndPoll { get; set; }
        [AllowNull]
		public byte[] QPicture { get; set; }
        [AllowNull]
        public string Value { get; set; }
    }
}
