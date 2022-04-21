namespace lw4API
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        private int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
}