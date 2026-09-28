using System;
using System.Collections.Generic;

namespace EsportsTeamManagement.Models;

public partial class Tournament
{
    public int TournamentId { get; set; }

    public string? TournamentName { get; set; }

    public string? Location { get; set; }

    public decimal? PrizePool { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public virtual ICollection<MatchDetail> MatchDetails { get; set; } = new List<MatchDetail>();
    //why are we using new List<Matchdetail> because 
    //we are initializing the collection propert to an empty List of matchdetail object.
    //This ensures that the MatchDetails collection is not null when a tournament object is created,
    //Allwoing us to add match details to thet collection without having to chech for null values first.
}
