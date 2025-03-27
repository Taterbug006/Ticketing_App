using Microsoft.EntityFrameworkCore;
using ToDo_List_App.Models;


public class TicketContext : DbContext
{
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Status> Statuses { get; set; }

    public TicketContext(DbContextOptions<TicketContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Status>().HasData(
            new Status { Id = 1, Name = "To Do" },
            new Status { Id = 2, Name = "In Progress" },
            new Status { Id = 3, Name = "QA" },
            new Status { Id = 4, Name = "Done" }
        );
    }
}
