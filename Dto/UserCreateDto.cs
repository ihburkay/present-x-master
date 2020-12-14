
using System;
using System.Text.Json.Serialization;
using WebApi.Entities;

namespace WebApi.Dto
{
    public class UserCreateDto    
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password{get;set;}
        public DateTime DateOfJoning
        {
            get
            {
                return this.dateCreated.HasValue
                   ? this.dateCreated.Value
                   : DateTime.Now;
            }

            set { this.dateCreated = value; }
        }

        private DateTime? dateCreated = null;

        /*public UserCreateDto(User user)
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
            Username = user.Username;      
            Password = user.Password;
        }*/
    }
}