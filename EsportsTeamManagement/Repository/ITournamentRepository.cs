using EsportsTeamManagement.Models;

public interface ITournamentRepository
{
    List<Tournament> GetAllTournaments();

    Tournament GetTournamentById(int id);

    void AddTournament(Tournament tournament);

    void UpdateTournament(Tournament tournament);

    void DeleteTournament(int id);
}