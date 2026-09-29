namespace EsportsTeamManagement.Models
{
    public class TeamLeaderboard
    {
        public long Ranking { get; set; }

        public string TeamName { get; set; } = string.Empty;

        public int TotalWins { get; set; }
    }
}