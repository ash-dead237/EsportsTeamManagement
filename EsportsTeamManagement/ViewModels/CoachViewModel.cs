using System.ComponentModel.DataAnnotations;

public class CoachViewModel
{
    [Required]
    public string CoachName { get; set; }

    public int ExperienceYears { get; set; }

    public string Email { get; set; }
}