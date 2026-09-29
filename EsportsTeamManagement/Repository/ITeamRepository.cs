using EsportsTeamManagement.Models;

public interface ITeamRepository
{
    List<Team> GetAllTeams();

    Team GetTeamById(int id);

    void AddTeam(Team team);
    void UpdateTeam(Team team);
    void DeleteTeam(int id);
}