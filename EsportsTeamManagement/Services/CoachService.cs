using EsportsTeamManagement.Models;

public class CoachService : ICoachService
{
    private readonly ICoachRepository _coachRepository;

    public CoachService(
        ICoachRepository coachRepository)
    {
        _coachRepository = coachRepository;
    }

    public List<Coach> GetCoaches()
    {
        return _coachRepository.GetAllCoaches();
    }

    public Coach GetCoachById(int id)
    {
        return _coachRepository.GetCoachById(id);
    }

    public void AddCoach(Coach coach)
    {
        _coachRepository.AddCoach(coach);
    }

    public void UpdateCoach(Coach coach)
    {
        _coachRepository.UpdateCoach(coach);
    }

    public void DeleteCoach(int id)
    {
        _coachRepository.DeleteCoach(id);
    }
}