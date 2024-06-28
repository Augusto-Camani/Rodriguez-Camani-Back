namespace ApiBarberia;

public interface IBarberScheduleFactory
{
    BarberSchedule CreateBarberSchedule(int barberId);
}

