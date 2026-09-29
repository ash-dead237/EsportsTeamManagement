using EsportsTeamManagement.Models;

public interface ITournamentService
{
    List<Tournament> GetTournaments();

    Tournament GetTournamentById(int id);

    void AddTournament(Tournament tournament);

    void UpdateTournament(Tournament tournament);

    void DeleteTournament(int id);
}