using EsportsTeamManagement.Models;
using Microsoft.EntityFrameworkCore;

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
.Include(u => u.Role)
.FirstOrDefault(x =>
x.Username == username &&
x.PasswordHash == password);
        }
    }
}