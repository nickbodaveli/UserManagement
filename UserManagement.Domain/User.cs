using UserManagement.Domain.Common.Models;

namespace UserManagement.Domain
{
    public class User : AggregateRoot
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }

        public User()
        {

        }

        private User(string userName,string password,string email, bool isActive)
        {
            UserName = userName;
            Password = password;
            Email = email;
            IsActive = isActive;
        }

        public static User Create(string userName, string password, string email, bool isActive)
        {
            return new User(userName,password,email, isActive);
        }
    }
}
