using System;
using System.Net.Http;
using System.Threading.Tasks;

public class RiotApiService
{
    private readonly string _apiKey;
    private readonly string _region;
    private readonly HttpClient _client;

    public RiotApiService(IConfiguration configuration)
    {     
        _apiKey = configuration["RiotApi:ApiKey"] ?? throw new ArgumentException("ApiKey não encontrada na configuração.");
        _region = configuration["RiotApi:Region"] ?? throw new ArgumentException("Region não encontrada na configuração.");
        _client = new HttpClient();
    }

    public async Task<string> GetAsync(string endpoint)
    {
        string url = $"https://{_region}.api.riotgames.com{endpoint}?api_key={_apiKey}";

        HttpResponseMessage response = await _client.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsStringAsync();
        }
        else
        {
            throw new Exception($"Erro ao acessar a API: {response.StatusCode}");
        }
    }
}
