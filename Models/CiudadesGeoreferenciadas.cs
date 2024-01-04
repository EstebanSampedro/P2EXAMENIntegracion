using System.ComponentModel.DataAnnotations;

namespace IntegracionP2ES.Models
{
    public class CiudadesGeoreferenciadas
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Province { get; set; }

        [Required]
        public string CountryName { get; set; }
    }

}
