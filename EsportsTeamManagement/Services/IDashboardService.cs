using EsportsTeamManagement.ViewModels;
using EsportsTeamManagement.Models;

namespace EsportsTeamManagement.Services
{
    public interface IDashboardService
    {
        DashboardViewModel GetDashboardData();
        List<TeamLeaderboard> GetLeaderboard();
        List<TopTeamViewModel> GetTopTeams();
    }
}