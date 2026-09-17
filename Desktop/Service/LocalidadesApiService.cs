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
    public class LocalidadesApiService
    {
        HttpClient httpClient;
        JsonSerializerOptions options;

        public LocalidadesApiService()
        {
            httpClient = SettingHttpClient();
            options = SettingJsonSerializer();
        }

        public async Task<List<Localidad>?> GetAllAsync()//obteniendo localidades
        {
            try
            {
                var response = await httpClient.GetAsync("");
                if(response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var localidades = JsonSerializer.Deserialize<List<Localidad>>(json, options);
                    return localidades;
                }
                else
                {
                    MessageBox.Show("Error al obtener las localidades: " + response.ReasonPhrase);
                    return null;
                }
            }catch(Exception ex)
            { 
                MessageBox.Show("Error al obtener las localidades: " + ex.Message); 
                return null;
            }
        }

        public async Task<List<Localidad>?> GetAllWithFiltersAsync(string filter)//obteniendo localidades mediante filtro
        {
            try
            {
                var response = await httpClient.GetAsync($"?filtro={filter}");
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Error al obtener las localidades: " + response.ReasonPhrase);
                    return null;
                }
                var json = await response.Content.ReadAsStringAsync();
                var localidades = JsonSerializer.Deserialize<List<Localidad>>(json, options);
                return localidades;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener las localidades: " + ex.Message);
                return null;
            }
        }
        public async Task<List<Localidad>?> GetAllDeletedAsync()//obteniendo localidades eliminadas
        {
            try
            {
                var response = await httpClient.GetAsync("deleteds");
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Error al obtener las localidades: " + response.ReasonPhrase);
                    return null;
                }
                var json = await response.Content.ReadAsStringAsync();
                var localidades = JsonSerializer.Deserialize<List<Localidad>>(json, options);
                return localidades;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener las localidades eliminadas: " + ex.Message);
                return null;
            }
        }

        public async Task<bool> AddLocalidadAsync(Localidad localidad)//agregando una localidad
        {
            try
            {
                SettingJsonSerializer();
                var json = JsonSerializer.Serialize(localidad, options);
                var LocalidadJson = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("", LocalidadJson);
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Error al crear la localidad: " + response.ReasonPhrase);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear la localidad desde la Api: " + ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateLocalidadAsync(Localidad localidad) //modificando una localidad
        {
            try
            {
                // Configuramos las opciones de serialización para ignorar propiedades nulas y hacer que la búsqueda de propiedades sea insensible a mayúsculas
                var options = new JsonSerializerOptions
                {
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                    PropertyNameCaseInsensitive = true,
                };
                //configuramos la serializacion de las localidades para que ignore las propiedades nulas y no tenga en cuenta mayusculas o minusculas en los nombres de las propiedades
                SettingJsonSerializer();
                var json = JsonSerializer.Serialize(localidad, options);
                var LocalidadJson = new StringContent(json, Encoding.UTF8, "application/json");
                string IdLocalidad = localidad.Id.ToString(); //filtro para actualizar solo la localidad con el id que se pasa por el parametro localidad
                var response = await httpClient.PutAsync(IdLocalidad, LocalidadJson);
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Error al actualizar la localidad: " + response.ReasonPhrase);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la localidad desde la Api: " + ex.Message);
                return false;
            }

        }

        public async Task<bool> DeleteLocalidadAsync(int id) //eliminando una localidad
        {
            try
            {
                var response = await httpClient.DeleteAsync(id.ToString());
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Error al eliminar la localidad: " + response.ReasonPhrase);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la localidad desde la Api: " + ex.Message);
                return false;
            }

        }
        //restaurar una localidad
        public async Task<bool> RestoreLocalidadAsync(int id)
        {
            try
            {
                var response = await httpClient.PutAsync($"restore/{id}", null);
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Error al restaurar la localidad: " + response.ReasonPhrase);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al restaurar la localidad desde la Api: " + ex.Message);
                return false;
            }
        }

        private HttpClient? SettingHttpClient()
        {
            Env.Load("../../../"); //cargando las variables de entorno del archivo .env
            //var urlApi = Environment.GetEnvironmentVariable("URLAPI");
            var urlApi = Environment.GetEnvironmentVariable("URLAPILOCAL");
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(urlApi+"Localidades/");
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

