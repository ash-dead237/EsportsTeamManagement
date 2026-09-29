using EsportsTeamManagement.Models;

public class MatchService : IMatchService
{
    private readonly IMatchRepository _repository;

    public MatchService(IMatchRepository repository)
    {
        _repository = repository;
    }

    public List<MatchDetail> GetMatches()
    {
        return _repository.GetAllMatches();
    }

    public MatchDetail GetMatchById(int id)
    {
        return _repository.GetMatchById(id);
    }

    public void AddMatch(MatchDetail match)
    {
        _repository.AddMatch(match);
    }

    public void UpdateMatch(MatchDetail match)
    {
        _repository.UpdateMatch(match);
    }

    public void DeleteMatch(int id)
    {
        _repository.DeleteMatch(id);
    }
}