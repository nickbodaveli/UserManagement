using Microsoft.EntityFrameworkCore;
using UserManagement.Application.Common.Interfaces;
using UserManagement.Application.Management.Commands.UsersProfileCommands;
using UserManagement.Domain;
using UserManagement.EFCore.Common;

namespace UserManagement.Infrastructure.Persistance.Repositories
{
    public class UserProfileRepository : IUserProfileManagementRepository
    {
        private readonly UserManagementDbContext _context;

        public UserProfileRepository(UserManagementDbContext context)
        {
            _context = context;
        }

        public async Task<UserProfile> CreateUserProfile(CreateUserProfileCommand request)
        {
            var userProfile = await _context.UserProfiles.FirstOrDefaultAsync(x => x.UserId == request.UserId);

            if (userProfile == null)
            {
                var newUserProfile = UserProfile.CreateUserProfile(request.FirstName, request.LastName, request.PersonalNumber, request.UserId);

                _context.Add(newUserProfile);
                await _context.SaveChangesAsync();
            }

            return userProfile;
        }

        public async Task<IEnumerable<UserProfile>> UserProfiles()
        {
            var userProfiles = await _context.UserProfiles.ToListAsync();

            if (userProfiles == null)
            {
                throw new Exception("User Profiles not found");
            }

            return userProfiles;
        }


        public async Task<UserProfile> GetUserProfile(int request)
        {
            var userProfile = await _context.UserProfiles.FirstOrDefaultAsync(x => x.Id == request);

            if (userProfile == null)
            {
                throw new Exception("User Profile not found");
            }

            return userProfile;
        }

        public async Task<UserProfile> UpdateUserProfile(UpdateUserProfileCommand request)
        {
            var userProfile = await _context.UserProfiles.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (userProfile == null)
            {
                throw new Exception("User Profile not found");
            }

            userProfile.FirstName = request.FirstName;
            userProfile.LastName = request.LastName;
            userProfile.PersonalNumber = request.PersonalNumber;
            //userProfile.UserId = request.UserId;

            _context.Update(userProfile);
            await _context.SaveChangesAsync();

            return userProfile;
        }

        public async Task<bool> RemoveUserProfile(int request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            _context.Remove(user);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
