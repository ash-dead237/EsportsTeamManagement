using EsportsTeamManagement.Models;
using EsportsTeamManagement.Repository;
using Microsoft.AspNetCore.Identity;

namespace EsportsTeamManagement.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserService(
            IUserRepository userRepository,
            IPasswordHasher<User> passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }
        //this IPasswordHasher is inbuilt interface in asp.net core identity that provides methods for hashing and verifying passowords.
        //below ValidateUser
        public User? ValidateUser(string username, string password)
        {
            var user = _userRepository.GetUser(username);
            if (user is null)
                return null;

            PasswordVerificationResult verificationResult;
            try
            {
                verificationResult = _passwordHasher.VerifyHashedPassword(
                    user,
                    user.PasswordHash,
                    password);
            }
            catch (FormatException)
            {
                verificationResult = PasswordVerificationResult.Failed;
            }

            if (verificationResult != PasswordVerificationResult.Failed)
            {
                if (verificationResult == PasswordVerificationResult.SuccessRehashNeeded)
                {
                    user.PasswordHash = _passwordHasher.HashPassword(user, password);
                    _userRepository.UpdateUser(user);
                }

                return user;
            }

            // Migrate accounts created before passwords were hashed.
            if (!string.Equals(user.PasswordHash, password, StringComparison.Ordinal))
                return null;

            user.PasswordHash = _passwordHasher.HashPassword(user, password);
            _userRepository.UpdateUser(user);
            return user;
        }

        public UserRegistrationResult RegisterUser(string username, string email, string password)
        {
            if (_userRepository.GetUser(username) is not null)
                return UserRegistrationResult.UsernameAlreadyExists;

            var viewerRole = _userRepository.GetRole("Viewer");
            if (viewerRole is null)
                return UserRegistrationResult.ViewerRoleNotConfigured;

            var user = new User
            {
                Username = username,
                Email = email,
                RoleId = viewerRole.RoleId
            };
            user.PasswordHash = _passwordHasher.HashPassword(user, password);

            _userRepository.AddUser(user);
            return UserRegistrationResult.Success;
        }
    }
}