namespace mainAPI.Configuration
{
    public class Configuration
    {
        public static IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();
    }
}
