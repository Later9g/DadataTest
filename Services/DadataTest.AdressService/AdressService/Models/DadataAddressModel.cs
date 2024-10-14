using AutoMapper;
using Dadata.Model;

namespace DadataTest.AdressService;

public class DadataAddressModel
{
    public string Country { get; set; }
    public string City { get; set; }
    public string Region { get; set; }
    public string Settlement { get; set; }
    public string Street { get; set; }
    public string House { get; set; }
    public string Flat { get; set; }
}

public class AddressProfile : Profile
{
    public AddressProfile()
    {
        CreateMap<DadataAddressModel, AdressResponseDTO>();
    }
}