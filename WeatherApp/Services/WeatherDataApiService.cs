using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class WeatherDataApiService
    {
        private readonly HttpClient _httpClient;
        private const string ApiKey = "c9927a9f7184ee02b2880ccf5a33889f";
        private const string BaseUrl = "https://api.openweathermap.org/data/2.5/";

        public WeatherDataApiService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<WeatherData.Root> GetCurrentWeatherAsync(double latitude, double longitude)
        {
            var response = await _httpClient.GetStringAsync($"{BaseUrl}weather?lat={latitude}&lon={longitude}&appid={ApiKey}&units=metric");

            return JsonSerializer.Deserialize<WeatherData.Root>(response);
        }
    }
}
