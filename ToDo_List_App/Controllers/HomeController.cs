using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDo_List_App.Models;


public class HomeController : Controller
{
    private readonly TicketContext _context;

    public HomeController(TicketContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var tickets = _context.Tickets.Include(t => t.Status).ToList();
        return View(tickets);
    }

    public IActionResult Add()
    {
        ViewBag.Statuses = new SelectList(_context.Statuses, "Id", "Name");
        return View();
    }

    [HttpPost]
    public IActionResult Add(Ticket ticket)
    {
        if (ModelState.IsValid)
        {
            _context.Tickets.Add(ticket);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        ViewBag.Statuses = new SelectList(_context.Statuses, "Id", "Name");
        return View(ticket);
    }
}
