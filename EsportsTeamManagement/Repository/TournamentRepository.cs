using EsportsTeamManagement.Models;

public class TournamentRepository : ITournamentRepository
{
    private readonly EsportsTeamManagementDbContext _context;

    public TournamentRepository(
        EsportsTeamManagementDbContext context)
    {
        _context = context;
    }

    public List<Tournament> GetAllTournaments()
    {
        return _context.Tournaments.ToList();
    }

    public Tournament GetTournamentById(int id)
    {
        return _context.Tournaments
                       .FirstOrDefault(t => t.TournamentId == id);
    }

    public void AddTournament(Tournament tournament)
    {
        _context.Tournaments.Add(tournament);
        _context.SaveChanges();
    }

    public void UpdateTournament(Tournament tournament)
    {
        _context.Tournaments.Update(tournament);
        _context.SaveChanges();
    }

    public void DeleteTournament(int id)
    {
        var tournament = _context.Tournaments
                                 .FirstOrDefault(t => t.TournamentId == id);

        if (tournament != null)
        {
            _context.Tournaments.Remove(tournament);
            _context.SaveChanges();
        }
    }
}