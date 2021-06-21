using System.Diagnostics.CodeAnalysis;

namespace PollAPI.Models 
{
    public class PollVariables 
    {
        public int ID { get; set; }
        [AllowNull]
        public int? PollId { get; set; }
        [AllowNull]
        public int QId { get; set; }
        [AllowNull]
        public int AId { get; set; }
        [AllowNull]
        public string Text { get; set; }
        [AllowNull]
        public double Number { get; set; }
        [AllowNull]
        public bool Boolean { get; set; }
        [AllowNull]
		public byte[] Picture { get; set; }
        [AllowNull]
        public bool QText { get; set; }
        [AllowNull]
        public bool QImage { get; set; }
        [AllowNull]
        public bool QBool { get; set; }
        [AllowNull]
        public bool QNumber { get; set; }
    }
}
