using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ToDo_List_App.Models;

public class HomeController : Controller
{
    private readonly ITicketService _ticketService;

    public HomeController(ITicketService ticketService)
    {
        _ticketService = ticketService;
    }

    public IActionResult Index()
    {
        var tickets = _ticketService.GetAllTickets();
        return View(tickets);
    }

    public IActionResult Add()
    {
        ViewBag.Statuses = new SelectList(_ticketService.GetAllStatuses(), "Id", "Name");
        return View();
    }

    [HttpPost]
    public IActionResult Add(Ticket ticket)
    {
        if (ModelState.IsValid)
        {
            _ticketService.AddTicket(ticket);
            return RedirectToAction("Index");
        }

        ViewBag.Statuses = new SelectList(_ticketService.GetAllStatuses(), "Id", "Name");
        return View(ticket);
    }
}
