using System.ComponentModel.DataAnnotations;

namespace ReternamApi.Models
{
    public class Deceased
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string FirstName { get; set; }

        [Required]
        public required string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public DateTime DateOfDeath { get; set; }

        public string? Description { get; set; }

        public string? PhotoUrl { get; set; }

        [Required]
        public int GraveId { get; set; }

        public Grave Grave { get; set; } = null!;
    }
}
