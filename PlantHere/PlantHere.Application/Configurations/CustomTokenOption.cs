namespace PlantHere.Application.Configurations
{
    public class CustomTokenOption
    {
        public List<String> Audiences { get; set; }

        public string Issuer { get; set; }

        public string SecurityKey { get; set; }

    }
}
