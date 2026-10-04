using EsportsTeamManagement.ViewModels;
using EsportsTeamManagement.Models;
namespace EsportsTeamManagement.ViewModels
{
    //view model class does not contain any business logic or data access code. 
    //It is used to transfer data between the controller and the view in an MVC application.
    //It contains properties that represent the data to be displayed on the dashboard.
    //view model gets data  from the repository layer and is passed to the view for rendering.
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