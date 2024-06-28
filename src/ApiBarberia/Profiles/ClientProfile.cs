using AutoMapper;

namespace ApiBarberia;

public class ClientProfile : Profile
{
    public ClientProfile()
    {
        CreateMap<Client, ClientDTO>();
        CreateMap<ClientDTO, Client>();
    }
}
