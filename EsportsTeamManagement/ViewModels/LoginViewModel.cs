using System.ComponentModel.DataAnnotations;

namespace EsportsTeamManagement.ViewModels
{
    public class LoginViewModel
    {
        [Required, StringLength(50)]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}