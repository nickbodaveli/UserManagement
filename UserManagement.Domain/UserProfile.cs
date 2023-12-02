using System.Text.Json.Serialization;
using UserManagement.Domain.Common.Models;

namespace UserManagement.Domain
{
    public class UserProfile : AggregateRoot
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }

        public int UserId { get; set; } // Foreign key
        [JsonIgnore]
        public User User { get; set; } // Navigation property

        public UserProfile()
        {

        }

        private UserProfile(string firstName, string lastName, string personalNumber, int userId)
        {
            FirstName = firstName;
            LastName = lastName;
            PersonalNumber = personalNumber;
            UserId = userId;
        }

        public static UserProfile CreateUserProfile(string firstName, string lastName, string personalNumber, int userId)
        {
            return new UserProfile(firstName, lastName, personalNumber, userId); 
        }
    }
}
