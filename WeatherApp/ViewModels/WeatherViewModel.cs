using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;
using WeatherApp.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WeatherApp.ViewModels
{
    public class WeatherViewModel : INotifyPropertyChanged
    {
        private readonly WeatherDataApiService _weatherDataApiService;
        public event PropertyChangedEventHandler PropertyChanged;
        private WeatherData _currentWeather;
        public WeatherData CurrentWeather
        {
            get => _currentWeather;
            set
            {
                _currentWeather = value;
                OnPropertyChanged();
            }
        }

        public WeatherViewModel(WeatherDataApiService weatherDataApiService)
        {
            _weatherDataApiService = weatherDataApiService;
        }
       
        public async Task LoadWeatherAsync(string city)
        {
            CurrentWeather = await _weatherDataApiService.GetCurrentWeatherAsync(city);
        }

        

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
