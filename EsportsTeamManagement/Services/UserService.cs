using EsportsTeamManagement.Models;
using EsportsTeamManagement.Repository;

namespace EsportsTeamManagement.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User ValidateUser(string username, string password)
        {
            return _userRepository.GetUser(username, password);
        }
    }
}