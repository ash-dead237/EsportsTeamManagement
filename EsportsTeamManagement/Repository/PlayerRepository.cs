using Microsoft.EntityFrameworkCore;
using EsportsTeamManagement.Models;

public class PlayerRepository : IPlayerRepository
{
    private readonly EsportsTeamManagementDbContext _context;

    public PlayerRepository(
        EsportsTeamManagementDbContext context)
    {
        _context = context;
    }

    public List<Player> GetAllPlayers()
    {
        return _context.Players
                       .Include(p => p.Team)
                       .ToList();
    }

    public Player GetPlayerById(int id)
    {
        return _context.Players
                       .Include(p => p.Team)
                       .FirstOrDefault(x => x.PlayerId == id);
    }

    public void AddPlayer(Player player)
    {
        _context.Players.Add(player);
        _context.SaveChanges();
    }

    public void UpdatePlayer(Player player)
    {
        _context.Players.Update(player);
        _context.SaveChanges();
    }

    public void DeletePlayer(int id)
    {
        var player =
            _context.Players.FirstOrDefault(x => x.PlayerId == id);

        if(player != null)
        {
            _context.Players.Remove(player);
            _context.SaveChanges();
        }
    }
}