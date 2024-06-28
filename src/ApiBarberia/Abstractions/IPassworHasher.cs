namespace ApiBarberia;

public interface IPasswordHasher
{
    public string HashPassword(string password);
    public bool Verify(string passwordHash, string inputPassword);
}