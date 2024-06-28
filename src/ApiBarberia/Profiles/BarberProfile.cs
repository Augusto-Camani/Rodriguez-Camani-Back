using AutoMapper;

namespace ApiBarberia;

public class BarberProfile : Profile
{
    public BarberProfile()
    {
        CreateMap<Barber, BarberDTO>();
        CreateMap<BarberDTO, Barber>();
    }

}
