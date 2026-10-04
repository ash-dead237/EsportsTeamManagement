using EsportsTeamManagement.Models;
using EsportsTeamManagement.ViewModels;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore;



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
            DashboardViewModel dashboard = new DashboardViewModel
            {
                TotalPlayers = _context.Players.Count(),
                TotalTeams = _context.Teams.Count(),
                TotalCoaches = _context.Coaches.Count(),
                TotalTournaments = _context.Tournaments.Count()
            };
            //below 

            dashboard.TopTeams = GetTopTeams();
            dashboard.Leaderboard = GetLeaderboard();
            dashboard.RecentMatches = GetRecentMatches();

            return dashboard;
        }
        public List<TeamLeaderboard> GetLeaderboard()
        {
            return _context.TeamLeaderboards
                           .OrderBy(t => t.Ranking)
                           .ToList();
        }

        public List<TopTeamViewModel> GetTopTeams()
        {
            var topTeams = new List<TopTeamViewModel>();

            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))

            {
                SqlCommand cmd =
                    new SqlCommand("sp_GetTopTeams", connection);

                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    topTeams.Add(new TopTeamViewModel
                    {
                        TeamName = reader["TeamName"].ToString(),
                        Wins = Convert.ToInt32(reader["Wins"])
                    });
                }
            }

            return topTeams;

        }


        public List<MatchDetail> GetRecentMatches()
        {
            return _context.MatchDetails
                .Include(m => m.Team1)
                .Include(m => m.Team2)
                .Include(m => m.WinnerTeam)
                .OrderByDescending(m => m.MatchDate)
                .Take(5)
                .ToList();
        }




    }
}