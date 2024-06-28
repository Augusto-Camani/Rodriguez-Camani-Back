namespace ApiBarberia;

public interface IAuthenticationService
{
 BaseResponse ValidateUser(AuthenticationRequestBody authenticationRequestBody);
}
