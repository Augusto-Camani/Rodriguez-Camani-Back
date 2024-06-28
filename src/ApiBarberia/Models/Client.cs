namespace ApiBarberia;

public class Client : User
{
    public Client() : base()
    {
        UserType = UserType.Client;
    }
    public int Age { get; set; }
    public int PhoneNumber { get; set; }
    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}