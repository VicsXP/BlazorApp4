using Veterinaria.Models;
using System.Text.Json;

namespace Veterinaria.Services
{
    public class AveService
    {
        private readonly string filePath =
    Path.Combine("wwwroot", "data", "aves.json");

        public List<Ave> ObtenerAves()
        {
            if (!File.Exists(filePath))
            {
                return new List<Ave>();
            }

            string json = File.ReadAllText(filePath);

            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<Ave>();
            }

            return JsonSerializer.Deserialize<List<Ave>>(json)
                   ?? new List<Ave>();
        }

        public void GuardarAve(Ave ave)
        {
            List<Ave> aves = ObtenerAves();

            aves.Add(ave);

            string json = JsonSerializer.Serialize(
                aves,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });

            File.WriteAllText(filePath, json);
        }
    }
}
