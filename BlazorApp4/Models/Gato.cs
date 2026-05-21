namespace Veterinaria.Models
{
    public class Gato : Animal
    {
        public string Pelaje { get; set; } = string.Empty;

        public bool EsDomestico { get; set; }
    }
}
