using DotNetEnv;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Desktop.Service
{
    public class ProvinciasApiService
    {
        HttpClient httpClient;
        JsonSerializerOptions options;

        public ProvinciasApiService()
        {
            httpClient = SettingHttpClient();
            options = SettingJsonSerializer();
        }

        public async Task<List<Provincia>?> GetAllAsync()//obteniendo provincias
        {
            try
            {
                var response = await httpClient.GetAsync("");
                if(response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var provincias = JsonSerializer.Deserialize<List<Provincia>>(json, options);
                    return provincias;
                }
                else
                {
                    MessageBox.Show("Error al obtener las provincias: " + response.ReasonPhrase);
                    return null;
                }
            }catch(Exception ex)
            { 
                MessageBox.Show("Error al obtener las provincias: " + ex.Message); 
                return null;
            }
        }

        public async Task<List<Provincia>?> GetAllWithFiltersAsync(string filter)//obteniendo provincias mediante filtro
        {
            try
            {
                var response = await httpClient.GetAsync($"?filtro={filter}");
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Error al obtener las provincias: " + response.ReasonPhrase);
                    return null;
                }
                var json = await response.Content.ReadAsStringAsync();
                var provincias = JsonSerializer.Deserialize<List<Provincia>>(json, options);
                return provincias;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener las provincias: " + ex.Message);
                return null;
            }
        }
        public async Task<List<Provincia>?> GetAllDeletedAsync()//obteniendo provincias eliminadas
        {
            try
            {
                var response = await httpClient.GetAsync("deleteds");
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Error al obtener las provincias eliminadas: " + response.ReasonPhrase);
                    return null;
                }
                var json = await response.Content.ReadAsStringAsync();
                var provincias = JsonSerializer.Deserialize<List<Provincia>>(json, options);
                return provincias;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener las provincias eliminadas: " + ex.Message);
                return null;
            }
        }

        public async Task<bool> AddProvinciaAsync(Provincia provincia)//agregando una provincia
        {
            try
            {
                SettingJsonSerializer();
                var json = JsonSerializer.Serialize(provincia, options);
                var ProvinciaJson = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("", ProvinciaJson);
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Error al crear la provincia: " + response.ReasonPhrase);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear la provincia desde la Api: " + ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateProvinciaAsync(Provincia provincia) //modificando una provincia
        {
            try
            {
                // Configuramos las opciones de serialización para ignorar propiedades nulas y hacer que la búsqueda de propiedades sea insensible a mayúsculas
                var options = new JsonSerializerOptions
                {
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                    PropertyNameCaseInsensitive = true,
                };
                //configuramos la serializacion de las provincias para que ignore las propiedades nulas y no tenga en cuenta mayusculas o minusculas en los nombres de las propiedades
                SettingJsonSerializer();
                var json = JsonSerializer.Serialize(provincia, options);
                var ProvinciaJson = new StringContent(json, Encoding.UTF8, "application/json");
                string IdProvincia = provincia.Id.ToString(); //filtro para actualizar solo la provincia con el id que se pasa por el parametro provincia
                var response = await httpClient.PutAsync(IdProvincia, ProvinciaJson);
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Error al actualizar la provincia: " + response.ReasonPhrase);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la provincia desde la Api: " + ex.Message);
                return false;
            }

        }

        public async Task<bool> DeleteProvinciaAsync(int id) //eliminando una provincia
        {
            try
            {
                var response = await httpClient.DeleteAsync(id.ToString());
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Error al eliminar la provincia: " + response.ReasonPhrase);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la provincia desde la Api: " + ex.Message);
                return false;
            }

        }
        //restaurar una provincia
        public async Task<bool> RestoreProvinciaAsync(int id)
        {
            try
            {
                var response = await httpClient.PutAsync($"restore/{id}", null);
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Error al restaurar la provincia: " + response.ReasonPhrase);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al restaurar la provincia desde la Api: " + ex.Message);
                return false;
            }
        }

        private HttpClient? SettingHttpClient()
        {
            Env.Load("../../../"); //cargando las variables de entorno del archivo .env
            //var urlApi = Environment.GetEnvironmentVariable("URLAPI");
            var urlApi = Environment.GetEnvironmentVariable("URLAPILOCAL");
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(urlApi+"Provincias/");
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            return httpClient;
        }

        private JsonSerializerOptions SettingJsonSerializer()
        {
            return new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                PropertyNameCaseInsensitive = true,
            };
        }
    }
}

