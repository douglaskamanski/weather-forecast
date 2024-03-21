using weather_forecast.Models;

namespace weather_forecast.Service;

public class WeatherApi
{
    private static HttpClient httpClient = new()
    {
        BaseAddress = new Uri("https://api.open-meteo.com")
    };

    public async Task<Weather> ForecastAysnc(float latitude, float longitude)
    {
        string parameters = $"v1/forecast?" +
                            $"latitude={latitude.ToString(System.Globalization.CultureInfo.InvariantCulture)}&" +
                            $"longitude={longitude.ToString(System.Globalization.CultureInfo.InvariantCulture)}&" +
                            $"hourly=temperature_2m,relative_humidity_2m,apparent_temperature,precipitation&" +
                            $"timezone=America%2FSao_Paulo&" +
                            $"forecast_days=1";
        var response = await httpClient.GetFromJsonAsync<Weather>(parameters);

        return response;
    }
}
