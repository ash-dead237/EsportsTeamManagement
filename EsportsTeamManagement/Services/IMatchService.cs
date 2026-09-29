using EsportsTeamManagement.Models;

public interface IMatchService
{
    List<MatchDetail> GetMatches();

    MatchDetail GetMatchById(int id);

    void AddMatch(MatchDetail match);

    void UpdateMatch(MatchDetail match);

    void DeleteMatch(int id);
}