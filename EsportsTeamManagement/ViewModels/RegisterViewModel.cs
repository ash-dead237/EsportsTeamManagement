using System.ComponentModel.DataAnnotations;

namespace EsportsTeamManagement.ViewModels
{
    public class RegisterViewModel
    {
        [Required, StringLength(50, MinimumLength = 3)]
        public string Username { get; set; } = string.Empty;

        [Required, EmailAddress, StringLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required, MinLength(8), StringLength(64)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Required, Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}

//We use string.Empty (which is equivalent to "") as a default value to prevent compiler warnings about null values.
//Prevents compile-time warnings by giving the property a blank default value instead of null.