using System.ComponentModel.DataAnnotations;

namespace EsportsTeamManagement.ViewModels
{
    public class TeamViewModel
    {
        [Required]
        public string TeamName { get; set; }

        [Required]
        public string Region { get; set; }

        public int? CoachId { get; set; }
    }
}