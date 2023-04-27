using System.ComponentModel.DataAnnotations;

namespace StudentAPI.Models
{
    public class Todo
    {
        [Key]
        public int ID { get; set; }
        public string? Description { get; set; }

    }
}