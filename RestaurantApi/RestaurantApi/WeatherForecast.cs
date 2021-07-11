using System;

namespace RestaurantApi
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
    public class TemperatureRequest
    {
        public int TempMin { get; set; }
        public int TempMax { get; set; }
    }
}
