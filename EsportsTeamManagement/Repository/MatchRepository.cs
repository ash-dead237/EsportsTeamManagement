using Microsoft.EntityFrameworkCore;
using EsportsTeamManagement.Models;

namespace EsportsTeamManagement.Repository
{
    public class MatchRepository : IMatchRepository
    {
        private readonly EsportsTeamManagementDbContext _context;

        public MatchRepository(
            EsportsTeamManagementDbContext context)
        {
            _context = context;
        }

        public List<MatchDetail> GetAllMatches()
        {
            return _context.MatchDetails
                .Include(m => m.Tournament)
                .Include(m => m.Team1)
                .Include(m => m.Team2)
                .Include(m => m.WinnerTeam)
                .ToList();
        }

        public MatchDetail GetMatchById(int id)
        {
            return _context.MatchDetails
                .Include(m => m.Tournament)
                .Include(m => m.Team1)
                .Include(m => m.Team2)
                .Include(m => m.WinnerTeam)
                .FirstOrDefault(m => m.MatchId == id);
        }

        public void AddMatch(MatchDetail match)
        {
            _context.MatchDetails.Add(match);
            _context.SaveChanges();
        }

        public void UpdateMatch(MatchDetail match)
        {
            _context.MatchDetails.Update(match);
            _context.SaveChanges();
        }

        public void DeleteMatch(int id)
        {
            var match =
                _context.MatchDetails.FirstOrDefault(x => x.MatchId == id);

            if (match != null)
            {
                _context.MatchDetails.Remove(match);
                _context.SaveChanges();
            }
        }
    }
}