using EsportsTeamManagement.Models;
using Microsoft.EntityFrameworkCore;
public class CoachRepository : ICoachRepository
{
    private readonly EsportsTeamManagementDbContext _context;

    public CoachRepository(
        EsportsTeamManagementDbContext context)
    {
        _context = context;
    }

    public List<Coach> GetAllCoaches()
    {
        return _context.Coaches.ToList();
    }

    /* public Coach GetCoachById(int id)
     {
         return _context.Coaches
                        .FirstOrDefault(c => c.CoachId == id);
     }
 */
    public Coach GetCoachById(int id)
    {
        return _context.Coaches
            .Include(c => c.Teams)
            .FirstOrDefault(c => c.CoachId == id);
    }

    public void AddCoach(Coach coach)
    {
        _context.Coaches.Add(coach);
        _context.SaveChanges();
    }

    public void UpdateCoach(Coach coach)
    {
        _context.Coaches.Update(coach);
        _context.SaveChanges();
    }

    public void DeleteCoach(int id)
    {
        var coach = _context.Coaches
                            .FirstOrDefault(c => c.CoachId == id);

        if (coach != null)
        {
            _context.Coaches.Remove(coach);
            _context.SaveChanges();
        }
    }
}