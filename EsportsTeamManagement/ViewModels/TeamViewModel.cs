using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EsportsTeamManagement.ViewModels
{
    public class TeamViewModel
    {
        [Required]
        public string TeamName { get; set; }

        [Required]
        public string Region { get; set; }

        public int? CoachId { get; set; }
        public List<SelectListItem>? Coaches { get; set; }
    }
}