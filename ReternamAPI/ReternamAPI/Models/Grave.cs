using System.ComponentModel.DataAnnotations;
namespace ReternamAPI.Models
{
    public class Grave
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string Sector { get; set; }

        [Required]
        public int Row { get; set; }

        [Required]
        public int GraveNumber { get; set; }

        [Required]
        public int GraveTypeId { get; set; }

        public GraveType GraveType { get; set; } = null!;
    }
}
