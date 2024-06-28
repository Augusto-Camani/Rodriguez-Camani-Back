namespace ApiBarberia;

public interface IAppointmentScheduleAdapter
{
    public IEnumerable<AppointmentSlotDTO> GetAvailableSlotsForBarberAndDate(int barberId, DateTime date);
}
