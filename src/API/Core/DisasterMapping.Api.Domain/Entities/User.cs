using DisasterMapping.Api.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterMapping.Api.Domain.Entities
{
    public class User:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? ContactNumber { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool Status { get; set; } = true;

        public ICollection<UserOperationClaim> UserOperationClaims { get; set; }



        public User()
        {

        }

        public User(string firstName, string lastName, string email, string? contactNumber=null):this()
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            ContactNumber = contactNumber;
        }
    }
}
