namespace ApiBarberia;
 public class AppointmentRepository : Repository, IAppointmentRepository
 {
     public AppointmentRepository(DbContextCR context) : base(context)
     {
     }
     public IEnumerable<Appointment> GetAvailableBarberAppointmentsByDate(int barberId , DateTime dateTime)
     {
        return _context.Appointments.Where(a => a.BarberId == barberId && a.BarberAvailability.DayOfTheWeek.Equals(dateTime.DayOfWeek));
     }  
    
     public IEnumerable<Appointment> GetAppointmnetsByUserId(int userId)
     {
        return _context.Appointments.Where(a => a.ClientId == userId);
     }
     public Appointment GetAppointmentById(int appointmentId)
     {
         return _context.Appointments.SingleOrDefault(a => a.AppointmentId == appointmentId);
     }

     public IEnumerable<Appointment> GetAppointmentByBarberId(int barberId)
     {
         return _context.Appointments.Where(a => a.BarberId == barberId);
     }
     public void CreateAppointment(Appointment appointment)
     {
         _context.Add(appointment);
         _context.SaveChanges();
     }
     public void DeleteAppointment(int appointmentid)
     {
         _context.Remove(GetAppointmentById(appointmentid));
         _context.SaveChanges();
     }
 }