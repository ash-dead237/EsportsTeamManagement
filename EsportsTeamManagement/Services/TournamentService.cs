using EsportsTeamManagement.Models;

public class TournamentService : ITournamentService
{
    private readonly ITournamentRepository _repository;

    public TournamentService(
        ITournamentRepository repository)
    {
        _repository = repository;
    }

    public List<Tournament> GetTournaments()
    {
        return _repository.GetAllTournaments();
    }

    public Tournament GetTournamentById(int id)
    {
        return _repository.GetTournamentById(id);
    }

    public void AddTournament(Tournament tournament)
    {
        _repository.AddTournament(tournament);
    }

    public void UpdateTournament(Tournament tournament)
    {
        _repository.UpdateTournament(tournament);
    }

    public void DeleteTournament(int id)
    {
        _repository.DeleteTournament(id);
    }
}