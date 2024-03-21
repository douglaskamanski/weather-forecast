namespace weather_forecast.Models;

public record struct Municipios
{
    public int codigo_ibge { get; init; }
    public string nome { get; init; }
    public string uf { get; init; }
    public string nome_uf { get; init; }
    public float latitude { get; init; }
    public float longitude { get; init; }
}
