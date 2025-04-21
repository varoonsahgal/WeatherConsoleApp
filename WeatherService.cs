using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class WeatherService
{
    private readonly HttpClient _httpClient;

    public WeatherService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<string> GetWeatherAsync(string city)
    {
        var requestUri = $"https://wttr.in/{city}?format=%C+%t";

        var response = await _httpClient.GetAsync(requestUri);
        response.EnsureSuccessStatusCode();

        var weatherData = await response.Content.ReadAsStringAsync();
        return weatherData;
    }
}