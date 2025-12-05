using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Window_Forms_Proyecto_Final_Programacion_Estructurada
{
    public class Recomendacion
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public double Puntuacion { get; set; }
        public string Motivo { get; set; }
    }

    public class RecomendadorIA
    {
        private readonly HttpClient http = new HttpClient();
        private const string URL = "http://localhost:11434/api/generate";
        private const string MODEL = "llama3";

        public async Task<List<Recomendacion>> RecomendarIA(List<Libro> libros, string genero, string autor)
        {
            string jsonLibros = JsonSerializer.Serialize(libros);

            string prompt = $@"
Eres un recomendador experto de libros.

Aquí está la lista de libros disponibles (en JSON):
{jsonLibros}

El usuario desea recomendaciones según:
- Género: {genero}
- Autor preferido: {autor}

Devuelve una lista de recomendaciones en este formato JSON exacto:
[
  {{
    ""Titulo"": ""..."",
    ""Autor"": ""..."",
    ""Puntuacion"": 0,
    ""Motivo"": ""...""
  }}
]
";

            var body = new
            {
                model = MODEL,
                prompt = prompt,
                stream = false
            };

            var requestBody = new StringContent(
                JsonSerializer.Serialize(body),
                Encoding.UTF8,
                "application/json"
            );

            var response = await http.PostAsync(URL, requestBody);
            string result = await response.Content.ReadAsStringAsync();

            using JsonDocument doc = JsonDocument.Parse(result);
            string raw = doc.RootElement.GetProperty("response").GetString();

            try
            {
                return JsonSerializer.Deserialize<List<Recomendacion>>(raw);
            }
            catch
            {
                return new List<Recomendacion>
                {
                    new Recomendacion
                    {
                        Titulo = "No se pudo procesar la respuesta de la IA",
                        Autor = "-",
                        Motivo = raw
                    }
                };
            }
        }
    }
}