using System.ComponentModel.DataAnnotations;

namespace ReternamApi.Models
{
    public class GraveType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }
    }
}
