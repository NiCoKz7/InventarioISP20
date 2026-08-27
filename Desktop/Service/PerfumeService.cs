using Desktop.Models;
using DotNetEnv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Desktop.Service
{
    public class PerfumeService
    {
        HttpClient httpClient;
        JsonSerializerOptions options;

        public PerfumeService()
        {
            httpClient = SettingHttpClient();
            options = SettingJsonSerializer();
        }

        public async Task<List<Perfume>?> GetAllAsync() //obteniendo todos los perfumes
        {
            try
            {
                var response = await httpClient.GetAsync("");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var perfumes = JsonSerializer.Deserialize<List<Perfume>>(json);
                    return perfumes;
                }
                else
                {
                    MessageBox.Show("Error al obtener los perfumes: " + response.ReasonPhrase);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los perfumes desde la api: " + ex.Message);
                return null;
            }
        }

        public async Task<List<Perfume>?> GetAllWithFiltersAsync(string filter) //obteniendo perfumes mediante filtro
        {
            try
            {
                string filtroSupabase = $"?or=(nombre.ilike.*{filter}*,marca.ilike.*{filter}*,genero.ilike.*{filter}*,tipo.ilike.*{filter}*)"; //filtro para buscar por nombre o marca o genero o tipo que contenga lo que se pasa por el parametro filter
                var response = await httpClient.GetAsync(filtroSupabase);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var perfumes = System.Text.Json.JsonSerializer.Deserialize<List<Perfume>>(json);
                    return perfumes;
                }
                else
                {
                    MessageBox.Show("Error al obtener los perfumes: " + response.ReasonPhrase);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los perfumes desde la api: " + ex.Message);
                return null;
            }
        }

        public async Task<bool> AddPerfumeAsync(Perfume perfume) //agregando un nuevo perfume
        {
            try
            {
                SettingJsonSerializer();
                var json = JsonSerializer.Serialize(perfume, options);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("", content);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Error al agregar el perfume: " + response.ReasonPhrase);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el perfume desde la api: " + ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdatePerfumeAsync(Perfume perfume) //actualizando un perfume
        {
            try
            {
                SettingJsonSerializer();
                var json = JsonSerializer.Serialize(perfume,options);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                string urlSupabase = $"?id=eq.{perfume.id}";
                var response = await httpClient.PutAsync(urlSupabase, content);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Error al actualizar el perfume: " + response.ReasonPhrase);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el perfume desde la api: " + ex.Message);
                return false;
            }
        }

        public async Task<bool> DeletePerfumeAsync(int id) //eliminando un perfume
        {
            try
            {
                string urlSupabase = $"?id=eq.{id}";
                var response = await httpClient.DeleteAsync(urlSupabase);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Error al eliminar el perfume: " + response.ReasonPhrase);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el perfume desde la api: " + ex.Message);
                return false;
            }
        }

        private JsonSerializerOptions SettingJsonSerializer()
        {
            return new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                PropertyNameCaseInsensitive = true,
            };
        }

        private HttpClient? SettingHttpClient()
        {
            Env.Load("../../../"); //cargando las variables de entorno del archivo .env
            //cargamos la apikey de supabase desde el archivo .env para no exponerla en el codigo
            var apikey = Environment.GetEnvironmentVariable("SUPABASE_KEY");
            //la url de la api la obtenemos del archivo .env para no exponerla en el codigo
            string urlApi = Environment.GetEnvironmentVariable("SUPABASE_URL") + "/rest/v1/Perfumes";
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(urlApi);
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            httpClient.DefaultRequestHeaders.Add("apikey", apikey);
            return httpClient;
        }
    }
}
