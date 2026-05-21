using Veterinaria.Models;
using System.Text.Json;

namespace Veterinaria.Services
{
    public class GatoService
    {
        private readonly string filePath =
    Path.Combine("wwwroot", "data", "gatos.json");

        public List<Gato> ObtenerGatos()
        {
            if (!File.Exists(filePath))
            {
                return new List<Gato>();
            }

            string json = File.ReadAllText(filePath);

            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<Gato>();
            }

            return JsonSerializer.Deserialize<List<Gato>>(json)
                   ?? new List<Gato>();
        }

        public void GuardarGato(Gato gato)
        {
            List<Gato> gatos = ObtenerGatos();

            gatos.Add(gato);

            string json = JsonSerializer.Serialize(
                gatos,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });

            File.WriteAllText(filePath, json);
        }
    }
}
