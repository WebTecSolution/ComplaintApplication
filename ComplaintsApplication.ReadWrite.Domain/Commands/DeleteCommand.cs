using ComplaintsApplication.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComplaintsApplication.ReadWrite.Domain.Commands
{
    public class DeleteCommand : Command
    {
        public int Id { get; protected set; }
    }
}
