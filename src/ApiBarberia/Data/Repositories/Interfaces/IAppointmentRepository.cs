﻿namespace ApiBarberia;

public interface IAppointmentRepository
{
    public IEnumerable<Appointment> GetAvailableBarberAppointmentsByDate(int barberId, DateTime dateTime);
    public Appointment GetAppointmentById(int appointmentId);
    public IEnumerable<Appointment> GetAppointmnetsByUserId(int userId);
    public IEnumerable<Appointment> GetAppointmentByBarberId(int barberId);
    public void CreateAppointment(Appointment appointment);
    public void DeleteAppointment(int appointmentid);
}
