using EsportsTeamManagement.Models;

namespace EsportsTeamManagement.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly EsportsTeamManagementDbContext _context;

        public UserRepository(EsportsTeamManagementDbContext context)
        {
            _context = context;
        }

        public User GetUser(string username, string password)
        {
            return _context.Users
                .FirstOrDefault(x =>
                    x.Username == username &&
                    x.PasswordHash == password);
        }
    }
}