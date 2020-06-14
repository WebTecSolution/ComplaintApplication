using ComplaintsApplication.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComplaintsApplication.ReadWrite.Domain.Commands
{
    public class DeleteComplaintCommand : DeleteCommand
    {
        public DeleteComplaintCommand(int id)
        {
            Id = id;
        }
    }
}
