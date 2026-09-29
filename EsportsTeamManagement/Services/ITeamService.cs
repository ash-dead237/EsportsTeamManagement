using EsportsTeamManagement.Models;

public interface ITeamService
{
    List<Team> GetTeams();

    Team GetTeamById(int id);

    void AddTeam(Team team);
    void UpdateTeam(Team team);
    void DeleteTeam(int id);
}