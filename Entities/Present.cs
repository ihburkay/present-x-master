
using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class Present
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public byte[] Location { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }

}