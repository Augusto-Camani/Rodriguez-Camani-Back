namespace ApiBarberia;

public interface IValidationService
{
    public bool ValidateEmail(string email);
    public bool ValidatePassword(string password);
}

