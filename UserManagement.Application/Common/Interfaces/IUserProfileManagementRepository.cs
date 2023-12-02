using UserManagement.Application.Management.Commands.UsersProfileCommands;
using UserManagement.Domain;

namespace UserManagement.Application.Common.Interfaces
{
    public interface IUserProfileManagementRepository
    {
        Task<UserProfile> CreateUserProfile(CreateUserProfileCommand request);
        Task<UserProfile> GetUserProfile(int request);
        Task<IEnumerable<UserProfile>> UserProfiles();
        Task<UserProfile> UpdateUserProfile(UpdateUserProfileCommand request);
        Task<bool> RemoveUserProfile(int request);
        
    }
}
