using UserManagement.Domain;

namespace UserManagement.Application.Common.Interfaces
{
    public interface IHelperRepository
    {
        public string Encrypt(string password);
        public bool Verify(string password, string hashedPassword);
        public string GenerateJWTToken(User user);
    }
}
