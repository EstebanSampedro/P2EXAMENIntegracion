namespace IntegracionP2ES.Models
{
    public class GeocodeData
    {
        public Standard Standard { get; set; }
        public Location Loc { get; set; }
    }

    public class Standard
    {
        public string City { get; set; }
        public string Prov { get; set; }
        public string Countryname { get; set; }
    }

    public class Location
    {
        public string Longt { get; set; }
        public string Latt { get; set; }
    }


}
