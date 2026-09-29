using System.ComponentModel.DataAnnotations;

public class TournamentViewModel
{
    [Required]
    public string TournamentName { get; set; }

    public string Location { get; set; }

    public decimal PrizePool { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }
}