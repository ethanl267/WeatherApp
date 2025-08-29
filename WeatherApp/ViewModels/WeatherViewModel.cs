using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.ViewModels
{
    public class WeatherViewModel : BaseViewModel
    {
        private readonly WeatherDataApiService _weatherDataApiService;
        private readonly DeviceLocationService _locationService;
        private WeatherData.Root currentWeather;

        public WeatherData.Root CurrentWeather
        {
            get => currentWeather;
            set => SetProperty(ref currentWeather, value);
        }

        public Command GetWeatherByLocationCommand { get; }

        public WeatherViewModel(WeatherDataApiService weatherDataApiService, DeviceLocationService locationService)
        {
            _weatherDataApiService = weatherDataApiService;
            _locationService = locationService;

            GetWeatherByLocationCommand = new Command(async () => await LoadWeatherByLocation());
        }

        private async Task LoadWeatherByLocation()
        {
            if (IsBusy) return;
            IsBusy = true;

            try
            {
                var location = await _locationService.GetCachedLocationAsync();

                if (location != null)
                {
                    CurrentWeather = await _weatherDataApiService.GetCurrentWeatherAsync(location.Latitude, location.Longitude);
                }
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}