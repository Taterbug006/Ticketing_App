
namespace ToDo_List_App.Models
{
    public interface ITicketService
    {
        List<Ticket> GetAllTickets();
        void AddTicket(Ticket ticket);
        List<Status> GetAllStatuses();
    }
}
