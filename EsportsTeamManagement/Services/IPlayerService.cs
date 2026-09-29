using EsportsTeamManagement.Models;

public interface IPlayerService
{
    List<Player> GetPlayers();

    Player GetPlayerById(int id);

    void AddPlayer(Player player);

    void UpdatePlayer(Player player);

    void DeletePlayer(int id);
}