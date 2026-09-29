using EsportsTeamManagement.Models;

public class TeamService : ITeamService
{
    private readonly ITeamRepository _teamRepository;

    public TeamService(
        ITeamRepository teamRepository)
    {
        _teamRepository = teamRepository;
    }

    public List<Team> GetTeams()
    {
        return _teamRepository.GetAllTeams();
    }
    public Team GetTeamById(int id)

    {
        return _teamRepository.GetTeamById(id);

    }
    public void AddTeam(Team team)
    {
        _teamRepository.AddTeam(team);
    }
    public void UpdateTeam(Team team)

    {
        _teamRepository.UpdateTeam(team);

    }
    public void DeleteTeam(int id)

    {
        _teamRepository.DeleteTeam(id);

    }

}