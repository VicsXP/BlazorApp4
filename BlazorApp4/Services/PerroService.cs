using Veterinaria.Models;
using System.Text.Json;

namespace Veterinaria.Services
{
    public class PerroService
    {
        private readonly string filePath =
    Path.Combine("wwwroot", "data", "perros.json");

        public List<Perro> ObtenerPerros()
        {
            if (!File.Exists(filePath))
            {
                return new List<Perro>();
            }

            string json = File.ReadAllText(filePath);

            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<Perro>();
            }

            return JsonSerializer.Deserialize<List<Perro>>(json)
                   ?? new List<Perro>();
        }

        public void GuardarPerro(Perro perro)
        {
            List<Perro> perros = ObtenerPerros();

            perros.Add(perro);

            string json = JsonSerializer.Serialize(
                perros,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });

            File.WriteAllText(filePath, json);
        }
    }
}
