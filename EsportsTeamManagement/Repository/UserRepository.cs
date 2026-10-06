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

        public User? GetUser(string username)
        {
            return _context.Users
            .Include(u => u.Role)
            .FirstOrDefault(x => x.Username == username);
        }

        public Role? GetRole(string roleName)
        {
            return _context.Roles.FirstOrDefault(role => role.RoleName == roleName);
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }
    }
}