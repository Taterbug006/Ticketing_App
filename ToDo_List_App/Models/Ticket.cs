using System.ComponentModel.DataAnnotations;

namespace ToDo_List_App.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name Required.")]
        [StringLength(100, ErrorMessage = "Cannot exceed 100 characters.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Description required.")]
        [StringLength(500, ErrorMessage = "Cannot exceed 500 characters.")]
        public string? Description { get; set; }

        [Range(1, 100, ErrorMessage = "Must be between 1 and 100.")]
        public int SprintNumber { get; set; }

        [Range(1, 100, ErrorMessage = "Must be between 1 and 100.")]
        public int PointValue { get; set; }

        [Required(ErrorMessage = "Status required.")]
        public int StatusId { get; set; }

        public Status? Status { get; set; }
    }
}