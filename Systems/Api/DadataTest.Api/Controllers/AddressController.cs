using DadataTest.AdressService;
using Microsoft.AspNetCore.Mvc;

namespace DadataTest.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AddressController : ControllerBase
{
    private readonly IAdressService adressService;

    public AddressController(IAdressService adressService)
    {
        this.adressService = adressService;
    }

    [HttpGet("standardize")]
    public async Task<IActionResult> StandardizeAddress([FromQuery] string rawAddress)
    {
        if (string.IsNullOrWhiteSpace(rawAddress))
        {
            return BadRequest("Address is required.");
        }

        var standardizedAddress = await adressService.getAdress(new AdressDTO { RawAddress = rawAddress });
        return Ok(standardizedAddress);
    }
}
