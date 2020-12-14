
using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class PresentReadDto
    {        
        public Guid Id { get; set; }     
        public string Name { get; set; }       
        public byte[] Location { get; set; } 
        public Guid UserId { get; set; } 
    }

}