using System.Collections.Generic;

namespace RestaurantApi
{
    public interface IWeatherForecastService
    {
        IEnumerable<WeatherForecast> Get();
        IEnumerable<WeatherForecast> MyGet(int count, int TempMin, int TempMax);
    }
}