using System;
using System.Collections.Generic;

namespace EsportsTeamManagement.Models;

public partial class Coach
{
    public int CoachId { get; set; }

    public string CoachName { get; set; } = null!;

    public int? ExperienceYears { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();
}
