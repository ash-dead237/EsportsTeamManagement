using System;
using System.Collections.Generic;

namespace EsportsTeamManagement.Models;

public partial class Player
{
    public int PlayerId { get; set; }

    public string PlayerName { get; set; } = null!;

    public int? Age { get; set; }

    public string? Country { get; set; }

    public string? GameRole { get; set; }

    public string? PlayerRank { get; set; }

    public int? TeamId { get; set; }

    public virtual Team? Team { get; set; }
}
