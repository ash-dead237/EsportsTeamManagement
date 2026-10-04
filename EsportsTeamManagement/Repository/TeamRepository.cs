using EsportsTeamManagement.Models;
using Microsoft.EntityFrameworkCore;
 

public class TeamRepository : ITeamRepository
{
    private readonly EsportsTeamManagementDbContext _context;

    public TeamRepository(
        EsportsTeamManagementDbContext context)
    {
        _context = context;
    }
    /* public Team GetTeamById(int id)
     {
         return _context.Teams.FirstOrDefault(t => t.TeamId == id);
     }
     */
    public Team GetTeamById(int id)
    {
        return _context.Teams
            .Include(t => t.Coach)
            .FirstOrDefault(t => t.TeamId == id);
    }

    // 👇 Added your Team creation logic
    public void AddTeam(Team team)
    {
        _context.Teams.Add(team);
        _context.SaveChanges();
    }
    public void UpdateTeam(Team team)

    {
        _context.Teams.Update(team);
        _context.SaveChanges();

    }
    public void DeleteTeam(int id)
    {
        var team = _context.Teams.FirstOrDefault(t => t.TeamId == id);

        if (team != null)
        {
            _context.Teams.Remove(team);
            _context.SaveChanges();
        }
    }

   /* public List<Team> GetAllTeams()
    {
        return _context.Teams.ToList();
    }
    */
    public List<Team> GetAllTeams()
{
    return _context.Teams
        .Include(t => t.Coach)
        .ToList();
}
}
