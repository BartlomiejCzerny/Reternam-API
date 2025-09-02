using System.ComponentModel.DataAnnotations;

namespace ReternamAPI.Models
{
    public class GraveType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }
    }
}
