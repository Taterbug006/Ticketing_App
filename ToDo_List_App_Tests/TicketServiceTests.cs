using ToDo_List_App.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;

namespace ToDo_List_App_Tests
{
    public class TicketServiceTests
    {
        private TicketService _service;
        private TicketContext _context;

        public TicketServiceTests()
        {
            var options = new DbContextOptionsBuilder<TicketContext>()
                .UseInMemoryDatabase(databaseName: "TicketTestDB")
                .Options;

            _context = new TicketContext(options);
            SeedData();
            _service = new TicketService(_context);
        }

        private void SeedData()
        {
            _context.Tickets.Add(new Ticket
            {
                Id = 1,
                Name = "Test Ticket",
                Description = "Sample Description",
                SprintNumber = 1,
                PointValue = 3,
                StatusId = 1
            });

            _context.SaveChanges();
        }

        [Fact]
        public void GetAllTickets_ReturnsAllTickets()
        {
            var result = _service.GetAllTickets();

            Assert.Single(result);
            Assert.Equal("Test Ticket", result.First().Name);
        }

        [Fact]
        public void AddTicket_AddsNewTicketSuccessfully()
        {
            var newTicket = new Ticket
            {
                Name = "New Ticket",
                Description = "New Desc",
                SprintNumber = 2,
                PointValue = 5,
                StatusId = 2
            };

            _service.AddTicket(newTicket);

            var tickets = _service.GetAllTickets();
            Assert.Equal(2, tickets.Count);
        }
    }
}
