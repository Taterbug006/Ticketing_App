using Microsoft.EntityFrameworkCore;

namespace ToDo_List_App.Models
{
    public class TicketService : ITicketService
    {
        private readonly TicketContext _context;

        public TicketService(TicketContext context)
        {
            _context = context;
        }

        public List<Ticket> GetAllTickets()
        {
            return _context.Tickets.Include(t => t.Status).ToList();
        }

        public void AddTicket(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            _context.SaveChanges();
        }

        public List<Status> GetAllStatuses()
        {
            return _context.Statuses.ToList();
        }
    }
}
