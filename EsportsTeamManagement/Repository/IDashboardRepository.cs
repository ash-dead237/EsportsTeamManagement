using EsportsTeamManagement.ViewModels;

namespace EsportsTeamManagement.Repository
{
    public interface IDashboardRepository
    {
        DashboardViewModel GetDashboardData();
    }
}