using System;
using System.Collections.Generic;

namespace EsportsTeamManagement.Models;

public partial class Team
{
    public int TeamId { get; set; }

    public string TeamName { get; set; } = null!;

    public string? Region { get; set; }

    public int? CoachId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual Coach? Coach { get; set; }

    public virtual ICollection<MatchDetail> MatchDetailTeam1s { get; set; } = new List<MatchDetail>();
    
    public virtual ICollection<MatchDetail> MatchDetailTeam2s { get; set; } = new List<MatchDetail>();

    public virtual ICollection<MatchDetail> MatchDetailWinnerTeams { get; set; } = new List<MatchDetail>();

    public virtual ICollection<Player> Players { get; set; } = new List<Player>();
}
