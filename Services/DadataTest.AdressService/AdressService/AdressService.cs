using System.Text.Json;
using System.Text;
using AutoMapper;
using DadataTest.Services.Settings;
using Dadata.Model;
using Dadata;

namespace DadataTest.AdressService;

public class AdressService : IAdressService
{
    private readonly IHttpClientFactory httpClientFactory;
    private readonly DadataSettings dadataSettings;
    private readonly IMapper mapper;

    public AdressService(IHttpClientFactory httpClientFactory,DadataSettings dadataSettings, IMapper mapper)
    {
        this.httpClientFactory = httpClientFactory;
        this.dadataSettings = dadataSettings;
        this.mapper = mapper;
    }

    public async Task<AdressResponseDTO> getAdress(AdressDTO adressDTO)
    {
        var httpClient = httpClientFactory.CreateClient();

        var url = dadataSettings.BaseUrl;
        var token = dadataSettings.Token;
        var secret = dadataSettings.Secret;

        var api = new CleanClientAsync(token, secret);
        var result = await api.Clean<Address>("мск сухонска 11/-89");

        var request = new HttpRequestMessage(HttpMethod.Post, url) 
        {
            Content = new StringContent(JsonSerializer.Serialize(new[] { adressDTO.RawAddress }), Encoding.UTF8, "application/json")
        };

        request.Headers.Add("Authorization", $"Token {token}");
        request.Headers.Add("X-Secret", secret); 

        var response = await httpClient.SendAsync(request);

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new Exception($"Error while calling Dadata API. StatusCode: {response.StatusCode}, Content: {errorContent}");
        }

        var responseContent = await response.Content.ReadAsStringAsync();

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var dadataResponse = JsonSerializer.Deserialize<List<DadataAddressModel>>(responseContent, options)?.FirstOrDefault();

        if (dadataResponse == null)
        {
            throw new Exception("Dadata API returned null or invalid response.");
        }

        // Преобразуем в DTO с помощью AutoMapper
        var standardizedAddress = mapper.Map<AdressResponseDTO>(dadataResponse);

        return standardizedAddress;
    }

}
