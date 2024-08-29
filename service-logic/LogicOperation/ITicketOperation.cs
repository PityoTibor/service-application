using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_logic.LogicOperation
{
    public interface ITicketOperation
    {
        public Task<bool> AssignTicket(Guid handyman, Guid ticket);
        public Task<bool> AutoAssignTicket(Guid ticket);
    }
}
