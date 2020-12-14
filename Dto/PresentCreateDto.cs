
using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class PresentCreateDto
    {      
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public byte[] Location { get; set; }
        public Guid UserId { get; set; }
        
    }

}