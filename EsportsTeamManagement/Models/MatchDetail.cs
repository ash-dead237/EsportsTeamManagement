using System;
using System.Collections.Generic;

namespace EsportsTeamManagement.Models;

public partial class MatchDetail
{
    public int MatchId { get; set; }

    public int TournamentId { get; set; }

    public int Team1Id { get; set; }

    public int Team2Id { get; set; }

    public int? WinnerTeamId { get; set; }

    public DateTime? MatchDate { get; set; }

    public virtual Team Team1 { get; set; } = null!;

    public virtual Team Team2 { get; set; } = null!;

    public virtual Tournament Tournament { get; set; } = null!;

    public virtual Team? WinnerTeam { get; set; }
}
