using EsportsTeamManagement.Models;
using EsportsTeamManagement.ViewModels;

namespace EsportsTeamManagement.Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly EsportsTeamManagementDbContext _context;

        public DashboardRepository(
            EsportsTeamManagementDbContext context)
        {
            _context = context;
        }

        public DashboardViewModel GetDashboardData()
        {
            return new DashboardViewModel
            {
                TotalPlayers = _context.Players.Count(),
                TotalTeams = _context.Teams.Count(),
                TotalCoaches = _context.Coaches.Count(),
                TotalTournaments = _context.Tournaments.Count()
            };
        }
    }
}