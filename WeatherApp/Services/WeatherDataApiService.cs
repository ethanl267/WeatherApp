using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class WeatherDataApiService
    {
        private HttpClient _httpClient;
        private const string ApiKey = "ae088606657a7537989abe91de3934d9";
        private const string BaseUrl = "https://api.openweathermap.org/data/2.5/";


        public WeatherDataApiService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<WeatherData> GetCurrentWeatherAsync(string city)
        {
            var response = await _httpClient.GetStringAsync($"{BaseUrl}weather?q={city}&appid={ApiKey}&units=metric");
            return JsonSerializer.Deserialize<WeatherData>(response);
        }

    }
}
