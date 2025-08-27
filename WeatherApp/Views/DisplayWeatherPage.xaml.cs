using WeatherApp.ViewModels;
using WeatherApp.Services;
using WeatherApp.Models;


namespace WeatherApp.Views;

public partial class DisplayWeatherPage : ContentPage
{
	private readonly WeatherViewModel _viewModel;

	public DisplayWeatherPage(WeatherViewModel viewModel)

    {
		InitializeComponent();
        BindingContext = _viewModel = viewModel;

    }

    private async void OnGetWeatherClicked(object sender, EventArgs e)
    {
        var city = CityEntry.Text;
        if (!string.IsNullOrWhiteSpace(city))
        {
            await _viewModel.LoadWeatherAsync(city);
            Console.WriteLine($"Loaded weather for {city}");
        }
    }
}