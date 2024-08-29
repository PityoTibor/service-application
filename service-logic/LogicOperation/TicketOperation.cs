using Microsoft.EntityFrameworkCore.Metadata.Internal;
using service_logic.LogicHandyman;
using service_logic.LogicTicket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_logic.LogicOperation
{
    public class TicketOperation : ITicketOperation
    {
        private readonly ITicketLogic ticketLogic;
        private readonly IHandymanLogic handymanLogic;

        public TicketOperation(ITicketLogic ticketLogic, IHandymanLogic handymanLogic)
        {
            this.handymanLogic = handymanLogic;
            this.ticketLogic = ticketLogic;
        }

        public async Task<bool> AssignTicket(Guid handyman, Guid ticket)
        {
            return true;
        }

        public async Task<bool> AutoAssignTicket(Guid ticketId)
        {
            var ticket = await ticketLogic.GetOneAsync(ticketId);
            
            if (ticket.StatusEnum == service_data.Models.EntityModels.StatusEnum.unassigned && ticket.Handyman_id == null)
            {
                var skills = ticket.TicketSkills.ToList();
                var handymans = await handymanLogic.GetAllAsync();

                var selectedHandyman = handymans.Select


            return true;
        }
    }
}
