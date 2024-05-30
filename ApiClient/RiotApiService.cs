using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

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

    public async Task<T> GetAsync<T>(string endpoint)
    {
        string url = $"https://{_region}.api.riotgames.com{endpoint}?api_key={_apiKey}";

        HttpResponseMessage response = await _client.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            string jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(jsonResponse);
        }
        else if (response.StatusCode == (System.Net.HttpStatusCode)429)
        {
            throw new Exception("Erro ao acessar a API: Muitas requisições. Tente novamente mais tarde.");
        }
        else
        {
            throw new Exception($"Erro ao acessar a API: {response.StatusCode}");
        }
    }

    public async Task<T> GetAsyncByRegion<T>(string endpoint)
    {
        string url = $"https://BR1.api.riotgames.com{endpoint}?api_key={_apiKey}";

        HttpResponseMessage response = await _client.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            string jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(jsonResponse);
        }
        else if (response.StatusCode == (System.Net.HttpStatusCode)429)
        {
            throw new Exception("Erro ao acessar a API: Muitas requisições. Tente novamente mais tarde.");
        }
        else
        {
            throw new Exception($"Erro ao acessar a API: {response.StatusCode}");
        }
    }

    public async Task<string> GetDataDragonAsync(string url)
    {
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

    public string LoadLocalDataDragonJson(string filePath)
    {
        if (File.Exists(filePath))
        {
            return File.ReadAllText(filePath);
        }
        else
        {
            throw new Exception($"Arquivo não encontrado: {filePath}");
        }
    }
}
