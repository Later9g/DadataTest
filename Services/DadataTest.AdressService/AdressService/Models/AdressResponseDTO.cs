using AutoMapper;
namespace DadataTest.AdressService;

public class AdressResponseDTO
{
    public string Country { get; set; }
    public string City { get; set; }
    public string Region { get; set; }
    public string Settlement { get; set; }
    public string Street { get; set; }
    public string House { get; set; }
    public string Flat { get; set; }
}