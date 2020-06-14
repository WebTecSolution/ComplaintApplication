using ComplaintsApplication.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComplaintsApplication.ReadWrite.Domain.Commands
{
    public class ComplaintCommand : Command
    {
        public int Id { get; protected set; }
        public string ComplaintDescription { get; protected set; }
        public int? ComplaintBy { get; protected set; }
        public DateTime ComplaintDate { get; protected set; } = DateTime.Now;
        public bool IsResolved { get; protected set; } = false;
    }
}
