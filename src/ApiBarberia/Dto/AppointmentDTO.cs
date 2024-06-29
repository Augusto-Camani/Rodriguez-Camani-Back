namespace ApiBarberia;

public class AppointmentDTO
{
    public int ClientId { get; set; }
    public int BarberId { get; set; }
    public int BarberAvailabilityId { get; set; }
    public string Service { get; set; }
    public TimeSpan StartTime { get; set; }
    public DateTime CreationDate { get; set; }

}
