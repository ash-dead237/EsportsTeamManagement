using EsportsTeamManagement.Models;

public interface ICoachService
{
    List<Coach> GetCoaches();

    Coach GetCoachById(int id);

    void AddCoach(Coach coach);

    void UpdateCoach(Coach coach);

    void DeleteCoach(int id);
}