using EsportsTeamManagement.Models;

namespace EsportsTeamManagement.Repository
{
    public interface IUserRepository
    {
        User? GetUser(string username);
        Role? GetRole(string roleName);
        void AddUser(User user);
        void UpdateUser(User user);
    }
}