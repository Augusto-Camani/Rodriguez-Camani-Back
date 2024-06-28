using AutoMapper;

namespace ApiBarberia;

public class AdminProfile : Profile
{
    public AdminProfile()
    {
        CreateMap<Admin, AdminDTO>();
        CreateMap<AdminDTO, Admin>();
    }
}