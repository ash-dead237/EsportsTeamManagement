using EsportsTeamManagement.ViewModels;
using EsportsTeamManagement.Models;
namespace EsportsTeamManagement.ViewModels
{
    public class DashboardViewModel
    {
        public int TotalPlayers { get; set; }
        public int TotalTeams { get; set; }
        public int TotalCoaches { get; set; }
        public int TotalTournaments { get; set; }
        public List<TopTeamViewModel> TopTeams { get; set; } = new List<TopTeamViewModel>();
        public List<TeamLeaderboard> Leaderboard { get; set; } = new List<TeamLeaderboard>();
        public List<MatchDetail> RecentMatches { get; set; }  = new List<MatchDetail>();
    }
}