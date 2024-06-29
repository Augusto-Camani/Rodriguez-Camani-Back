namespace ApiBarberia;

        public interface IAppointmentService
        {
            IEnumerable<Appointment> GetAvailableBarberAppointmentsByDate(int barberId, DateTime dateTime);
            IEnumerable<AppointmentDTO> GetAppointmentsByBarberId(int barberId);
            AppointmentDTO GetAppointmentById(int appointmentId);
            void CreateAppointment(AppointmentDTO appointmentCreateDTO);
            void DeleteAppointment(int appointmentId);
        }
