using EsportsTeamManagement.Repository;
using EsportsTeamManagement.ViewModels;

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
    }
}