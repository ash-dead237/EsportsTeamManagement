using EsportsTeamManagement.Models;

namespace EsportsTeamManagement.Repository
{
    public interface IUserRepository
    {
        User GetUser(string username, string password);
    }
}