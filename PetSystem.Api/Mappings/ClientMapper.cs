using AutoMapper;
using PetSystem.Core.Entities.Models;
using PetSystem.Core.Entities.Requests.ClienteRequests;
using PetSystem.Core.Entities.ValueObjects;

namespace PetSystem.Api.Mappings;

public class ClientMapper : Profile
{
    public ClientMapper()
    {
        CreateMap<InsertClientRequest, Client>().ReverseMap();
        CreateMap<InsertClientRequest, Contact>().ReverseMap();
        CreateMap<InsertClientRequest, Address>().ReverseMap();

        CreateMap<UpdateClientRequest, Client>().ReverseMap();
        CreateMap<UpdateClientRequest, Contact>().ReverseMap();
        CreateMap<UpdateClientRequest, Address>().ReverseMap();
    }
}