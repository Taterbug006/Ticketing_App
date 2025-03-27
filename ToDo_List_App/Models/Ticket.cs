namespace ToDo_List_App.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int SprintNumber { get; set; }
        public int PointValue { get; set; }
        public int StatusId { get; set; }
        public Status? Status { get; set; }
    }
}

