
using System;
using System.Text.Json.Serialization;
using WebApi.Entities;

namespace WebApi.Dto
{
    public class UserReadDto    
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password{get;set;}
    }
}