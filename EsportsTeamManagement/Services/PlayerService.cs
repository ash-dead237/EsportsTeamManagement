using EsportsTeamManagement.Models;
using EsportsTeamManagement.Repository;

namespace EsportsTeamManagement.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public List<Player> GetPlayers()
        {
            return _playerRepository.GetAllPlayers();
        }
        public Player GetPlayerById(int id)

        {

            return _playerRepository.GetPlayerById(id);

        }
        public void AddPlayer(Player player)
        {
            _playerRepository.AddPlayer(player);

        }

        public void UpdatePlayer(Player player)
        {
            _playerRepository.UpdatePlayer(player);

        }

        public void DeletePlayer(int id)
        {
            _playerRepository.DeletePlayer(id);

        }
    }
}
