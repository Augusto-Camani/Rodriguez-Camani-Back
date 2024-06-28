namespace ApiBarberia;

public class BarberDTO
{
    public string UserName { get; set; }

    public string PasswordHash { get; set; }

    public string Email { get; set; }

    public Specialties Specialties { get; set; }
}
