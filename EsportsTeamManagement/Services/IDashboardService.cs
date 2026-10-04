using EsportsTeamManagement.ViewModels;
using EsportsTeamManagement.Models;

namespace EsportsTeamManagement.Services
{
    public interface IDashboardService
    {//provides methods to retrieve dashboard data,leaderboard and top teams info.
        DashboardViewModel GetDashboardData();
        List<TeamLeaderboard> GetLeaderboard();
        List<TopTeamViewModel> GetTopTeams();
    }
}