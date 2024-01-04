using IntegracionP2ES.Models;
using IntegracionP2ES.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace IntegracionP2ES.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly Geocode _geocodeService;

        public ClientesController(ApplicationDbContext context, Geocode geocodeService)
        {
            _context = context;
            _geocodeService = geocodeService;
        }

        // GET: api/clientes/usuario/jalmeida
        [HttpGet("usuario/{username}")]
        public async Task<IActionResult> GetGeocodeDataByUsuario(string username)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Usuario == username);
            if (cliente == null)
            {
                return NotFound("Usuario no encontrado");
            }

            var geocodeData = await _geocodeService.GetGeocodeDataAsync(cliente.Ciudad);
            var geoData = JsonConvert.DeserializeObject<GeocodeData>(geocodeData);

            var city = geoData.Standard.City;
            var province = geoData.Standard.Prov;
            var countryName = geoData.Standard.Countryname;

            var existingData = await _context.CiudadesGeoreferenciadas
                .FirstOrDefaultAsync(g => g.City == city && g.Province == province && g.CountryName == countryName);

            if (existingData == null && city != null && province != null && countryName != null)
            {
                var newGeoData = new CiudadesGeoreferenciadas
                {
                    City = city,
                    Province = province,
                    CountryName = countryName
                };
                _context.CiudadesGeoreferenciadas.Add(newGeoData);
                await _context.SaveChangesAsync();
            }

            return Ok(geocodeData);
        }
    }
}
