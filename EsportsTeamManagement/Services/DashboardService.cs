using EsportsTeamManagement.Repository;
using EsportsTeamManagement.ViewModels;
using EsportsTeamManagement.Models;

namespace EsportsTeamManagement.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IDashboardRepository _dashboardRepository;

        public DashboardService(
            IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }
        public DashboardViewModel GetDashboardData()
        {
            return _dashboardRepository.GetDashboardData();
        }
        public List<TeamLeaderboard> GetLeaderboard()
        {
            return _dashboardRepository.GetLeaderboard();
        }
        public List<TopTeamViewModel> GetTopTeams()
        {
            return _dashboardRepository.GetTopTeams();
        }


    }
}