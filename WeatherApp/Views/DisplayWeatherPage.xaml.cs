using WeatherApp.ViewModels;

namespace WeatherApp.Views;

public partial class DisplayWeatherPage : ContentPage
{
    private readonly WeatherViewModel _viewModel;

    public DisplayWeatherPage(WeatherViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
        _viewModel = viewModel;
    }
}