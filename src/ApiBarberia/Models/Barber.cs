namespace ApiBarberia;

public class Barber : User
{
    public Barber() : base()
    {
        UserType = UserType.Barber;
    }
    public Specialties Specialties { get; set; }
    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}