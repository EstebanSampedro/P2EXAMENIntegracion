using System.Net.Http;
using System.Threading.Tasks;


namespace IntegracionP2ES.Services
{
    public class Geocode
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "844845987553450798931x20124"; // Asegúrate de proteger esta clave en un entorno de producción

        public Geocode(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetGeocodeDataAsync(string location)
        {
            var response = await _httpClient.GetAsync($"https://geocode.xyz/{location}?json=1&auth={_apiKey}");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            return result; // Aquí puedes convertir el resultado a un objeto si es necesario
        }
    }
}
