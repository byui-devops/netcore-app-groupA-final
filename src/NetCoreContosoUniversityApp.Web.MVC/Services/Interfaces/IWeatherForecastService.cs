using NetCoreContosoUniversityApp.Web.MVC.Models.ViewModels.WeatherForecast;

namespace NetCoreContosoUniversityApp.Web.MVC.Services.Interfaces
{
    public interface IWeatherForecastService
    {
        Task<List<WeatherForecast>?> GetWeatherForecastExample();
    }
}
