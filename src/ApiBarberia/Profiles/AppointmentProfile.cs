using AutoMapper;

namespace ApiBarberia;

public class AppointmentProfile : Profile
{
    public AppointmentProfile()
    {
        CreateMap<Appointment, AppointmentDTO>();
        CreateMap<AppointmentDTO, Appointment>();
        
    }
}