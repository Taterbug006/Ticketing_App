using ToDo_List_App.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;
using System;
using System.Linq;

namespace ToDo_List_App.Tests
{
    public class TicketServiceTests
    {
        private readonly TicketContext _context;
        private readonly TicketService _service;

        public TicketServiceTests()
        {
            var options = new DbContextOptionsBuilder<TicketContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _context = new TicketContext(options);
            _context.Database.EnsureCreated();

            _service = new TicketService(_context);
        }

        [Fact]
        public void AddTicket_AddsNewTicketSuccessfully()
        {
            var ticket = new Ticket
            {
                Name = "Sample Ticket",
                Description = "Something to do",
                SprintNumber = 1,
                PointValue = 3,
                StatusId = 1
            };

            _service.AddTicket(ticket);

            var tickets = _service.GetAllTickets();

            Assert.Single(tickets);
            Assert.Equal("Sample Ticket", tickets.First().Name);
        }

        [Fact]
        public void GetAllTickets_ReturnsAllTickets()
        {
            _context.Tickets.Add(new Ticket
            {
                Name = "First Ticket",
                Description = "Testing retrieval",
                SprintNumber = 2,
                PointValue = 5,
                StatusId = 1
            });
            _context.SaveChanges();

            var tickets = _service.GetAllTickets();

            Assert.Single(tickets);
            Assert.Equal("First Ticket", tickets[0].Name);
        }

        [Fact]
        public void GetAllStatuses_ReturnsStatuses()
        {
            var statuses = _service.GetAllStatuses();

            Assert.Equal(4, statuses.Count);
            Assert.Contains(statuses, s => s.Name == "To Do");
            Assert.Contains(statuses, s => s.Name == "Done");
        }
    }
}
