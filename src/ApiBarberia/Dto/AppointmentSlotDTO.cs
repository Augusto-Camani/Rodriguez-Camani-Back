namespace ApiBarberia;

public class AppointmentSlotDTO
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public bool IsAvailable { get; set; }
}
