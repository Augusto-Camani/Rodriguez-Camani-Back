namespace ApiBarberia;

    public interface IAppointmentService
    {
        IEnumerable<Appointment> GetAvailableBarberAppointmentsByDate(int barberId, DateTime dateTime);
        IEnumerable<AppointmentDTO> GetAppointmentsByBarberId(int barberId);
        IEnumerable<AppointmentSlotDTO> GetAppointmentsByBarberAndDate(int barberId, DateTime date);
        AppointmentDTO GetAppointmentById(int appointmentId);
        void CreateAppointment(AppointmentDTO appointmentCreateDTO);
        void DeleteAppointment(int appointmentId);
    }
