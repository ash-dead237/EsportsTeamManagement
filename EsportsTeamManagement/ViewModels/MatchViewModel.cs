using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace EsportsTeamManagement.ViewModels
{
    public class MatchViewModel
    {
        [Required]
        public int TournamentId { get; set; }

        [Required]
        public int Team1Id { get; set; }

        [Required]
        public int Team2Id { get; set; }

        public int? WinnerTeamId { get; set; }

        public DateTime MatchDate { get; set; }

        public List<SelectListItem>? Tournaments { get; set; }

        public List<SelectListItem>? Teams { get; set; }

    }
}