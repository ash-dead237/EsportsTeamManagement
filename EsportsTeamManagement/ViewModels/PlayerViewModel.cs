using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace EsportsTeamManagement.ViewModels
{
    public class PlayerViewModel
    {
        [Required]
        public string PlayerName { get; set; }

        public int Age { get; set; }

        public string Country { get; set; }

        public string GameRole { get; set; }

        public string PlayerRank { get; set; }

        [Required]
        public int TeamId { get; set; }

        public List<SelectListItem>? Teams { get; set; }
    }
}