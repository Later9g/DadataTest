namespace DadataTest.AdressService;

public interface IAdressService
{
    public Task<AdressResponseDTO> getAdress(AdressDTO adressDTO);
}
