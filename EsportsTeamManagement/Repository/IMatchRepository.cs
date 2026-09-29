using EsportsTeamManagement.Models;

public interface IMatchRepository
{
    List<MatchDetail> GetAllMatches();

    MatchDetail GetMatchById(int id);

    void AddMatch(MatchDetail match);

    void UpdateMatch(MatchDetail match);

    void DeleteMatch(int id);
}