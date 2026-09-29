using EsportsTeamManagement.ViewModels;
using EsportsTeamManagement.Models;

namespace EsportsTeamManagement.Repository
{
    public interface IDashboardRepository
    {
        DashboardViewModel GetDashboardData();
        List<TeamLeaderboard> GetLeaderboard();
        List<TopTeamViewModel> GetTopTeams();
        List<MatchDetail> GetRecentMatches();

    }
}