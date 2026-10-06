using EsportsTeamManagement.Models;

namespace EsportsTeamManagement.Services
{
    public interface IUserService
    {
        User? ValidateUser(string username, string password);
        UserRegistrationResult RegisterUser(string username, string email, string password);
    }

    public enum UserRegistrationResult
    {
        Success,
        UsernameAlreadyExists,
        ViewerRoleNotConfigured
    }
}




/// <summary>
/// ValidateUser method in IUserService interface is used to validate the  user credentials againts the stored user data .
//It returns a User Object if the credentials are valid  or null if they are invalid.
///above enum is used to represent the posssible outcomes of a user regsiteration attempt.
///the RegisterUser method in the IUserService interface make the use of this enum type to indicate the result.
/// </summary>