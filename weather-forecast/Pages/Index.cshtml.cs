using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using weather_forecast.Models;
using weather_forecast.Service;

namespace weather_forecast.Pages;

public class IndexModel : PageModel
{
    private static string path = "Files\\municipios.json";
    private static readonly string jsonString = System.IO.File.ReadAllText(path);
    public List<Municipios>? municipios = JsonSerializer.Deserialize<List<Municipios>>(jsonString);
    public Weather climaResponse = new();
    public bool acessouApi = false;
    public string nomeUf = string.Empty;

    public async Task OnPostAsync()
    {
        acessouApi = false;

        if (int.TryParse(Request.Form["slcMunicipio"], out int codigoIbgeMunicipio))
        {
            var municipio = (from m in municipios
                             where m.codigo_ibge == codigoIbgeMunicipio
                             select new
                             {
                                 Latitude = m.latitude,
                                 Longitude = m.longitude,
                                 NomeUf = m.nome_uf
                             }).FirstOrDefault();

            if (municipio is not null)
            {
                WeatherApi clima = new();
                climaResponse = await clima.ForecastAysnc(municipio.Latitude, municipio.Longitude);
                nomeUf = municipio.NomeUf;
                acessouApi = true;
            }
        }
    }
}
