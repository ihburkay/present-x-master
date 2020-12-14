using System.Text.Json.Serialization;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(250)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(250)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(25)]
        public string Username { get; set; }

        [JsonIgnore]
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
        [JsonIgnore]
        public string Password { get; set; }

        [JsonIgnore]
        public List<RefreshToken> RefreshTokens { get; set; }

        [JsonIgnore]
        public List<Present> Presents { get; set; }
    }
}