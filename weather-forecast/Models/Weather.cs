namespace weather_forecast.Models;

public record struct Weather
{
    public float latitude { get; set; }
    public float longitude { get; set; }
    public float generationtime_ms { get; set; }
    public int utc_offset_seconds { get; set; }
    public string timezone { get; set; }
    public string timezone_abbreviation { get; set; }
    public float elevation { get; set; }
    public Hourly_Units hourly_units { get; set; }
    public Hourly hourly { get; set; }
}

public record struct Hourly_Units
{
    public string time { get; set; }
    public string temperature_2m { get; set; }
    public string relative_humidity_2m { get; set; }
    public string apparent_temperature { get; set; }
    public string precipitation { get; set; }
}

public record struct Hourly
{
    public string[] time { get; set; }
    public float[] temperature_2m { get; set; }
    public int[] relative_humidity_2m { get; set; }
    public float[] apparent_temperature { get; set; }
    public float[] precipitation { get; set; }
}
