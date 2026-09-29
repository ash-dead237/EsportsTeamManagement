using EsportsTeamManagement.Models;

public interface ICoachRepository
{
    List<Coach> GetAllCoaches();

    Coach GetCoachById(int id);

    void AddCoach(Coach coach);

    void UpdateCoach(Coach coach);

    void DeleteCoach(int id);
}