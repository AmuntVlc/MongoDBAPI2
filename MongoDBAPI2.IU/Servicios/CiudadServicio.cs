using MongoDBAPI2.IU.Models;
using MongoDBAPI2.IU.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
//using System.Text.Json;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.IO;

namespace MongoDbAPI.IU.Servicios
{
    public class CiudadServicio : ICiudadServicio
    {
        private readonly HttpClient _httpClient;
        public CiudadServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        //public async Task BorrarLibro(string id)
        //{
        //    await _httpClient.DeleteAsync($"api/Libros/{id}");
        //}

        //public async Task GuardarLibro(Libro Libro)
        //{
        //    var LibroJson = new StringContent(JsonConvert.SerializeObject(Libro), Encoding.UTF8, "application/json");
        //    if (String.IsNullOrEmpty(Libro.Id))
        //        await _httpClient.PostAsync("api/Libros/", LibroJson);
        //    else
        //        await _httpClient.PutAsync($"api/Libros/{Libro.Id}", LibroJson);
        //}

        //public async Task<Libro> ObtenerLibro(string id)
        //{
        //    //return await JsonSerializer.DeserializeAsync<Libro>
        //    //(await _httpClient.GetStreamAsync($"api/Libros{id}"),
        //    //new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        //    try
        //    {
        //        StreamReader reader = new StreamReader(await _httpClient.GetStreamAsync($"api/Libros/{id}"));
        //        string text = reader.ReadToEnd();
        //        return JsonConvert.DeserializeObject<Libro>(text);
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }

        //}

        public async Task<IEnumerable<Ciudad>> ObtenerTodosCiudades()
        {
            //return await JsonSerializer.DeserializeAsync<IEnumerable<Libro>>
            //(await _httpClient.GetStreamAsync($"api/Libros"),
            //new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            StreamReader reader = new StreamReader(await _httpClient.GetStreamAsync($"api/Ciudades"));
            string text = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<IEnumerable<Ciudad>>(text);
        }
    }
}


