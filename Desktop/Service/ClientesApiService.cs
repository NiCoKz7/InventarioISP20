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
    public class ClientesApiService
    {
        HttpClient httpClient;
        JsonSerializerOptions options;

        public ClientesApiService()
        {
            httpClient = SettingHttpClient();
            options = SettingJsonSerializer();
        }

        public async Task<List<Cliente>?> GetAllAsync()//obteniendo clientes
        {
            try
            {
                var response = await httpClient.GetAsync("");
                if(response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var clientes = JsonSerializer.Deserialize<List<Cliente>>(json, options);
                    return clientes;
                }
                else
                {
                    MessageBox.Show("Error al obtener los clientes: " + response.ReasonPhrase);
                    return null;
                }
            }catch(Exception ex)
            { 
                MessageBox.Show("Error al obtener los clientes: " + ex.Message); 
                return null;
            }
        }

        public async Task<List<Cliente>?> GetAllWithFiltersAsync(string filter)//obteniendo clientes mediante filtro
        {
            //try
            //{
            //    string filtroSupabase = $"?or=(firstname.ilike.*{filter}*,lastname.ilike.*{filter}*,dni.ilike.*{filter}*,address.ilike.*{filter}*)"; //filtro para buscar por nombre o apellido que contenga lo que se pasa por el parametro filter
            //    var response = await httpClient.GetAsync(filtroSupabase);
            //    if (response.IsSuccessStatusCode)
            //    {
            //        var json = await response.Content.ReadAsStringAsync();
            //        var clientes = System.Text.Json.JsonSerializer.Deserialize<List<Cliente>>(json);
            //        return clientes;
            //    }
            //    else
            //    {
            //        MessageBox.Show("Error al obtener los clientes: " + response.ReasonPhrase);
            //        return null;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error al obtener los clientes: " + ex.Message);
            //    return null;
            //}
            return null;
        }

        public async Task<bool> AddClienteAsync(Cliente cliente)//agregando un cliente
        {
            //try
            //{
            //    SettingJsonSerializer();
            //    var json = JsonSerializer.Serialize(cliente, options);
            //    var content = new StringContent(json, Encoding.UTF8, "application/json");
            //    var response = await httpClient.PostAsync("", content);
            //    if (response.IsSuccessStatusCode)
            //    {
            //        return true;
            //    }
            //    else
            //    {
            //        MessageBox.Show("Error al crear el cliente: " + response.ReasonPhrase);
            //        return false;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error al crear el cliente desde la Api: " + ex.Message);
            //    return false;
            //}
            return false;
        }

        public async Task<bool> UpdateClienteAsync(Cliente cliente) //modificando un cliente
        {
            //try
            //{
            //    //configuramos la serializacion del cliente para que ignore las propiedades nulas y no tenga en cuenta mayusculas o minusculas en los nombres de las propiedades
            //    SettingJsonSerializer();
            //    var json = JsonSerializer.Serialize(cliente, options);
            //    var content = new StringContent(json, Encoding.UTF8, "application/json");
            //    string urlSupabase = $"?id=eq.{cliente.Id}"; //filtro para actualizar solo el cliente con el id que se pasa por el parametro cliente
            //    var response = await httpClient.PutAsync(urlSupabase, content);
            //    if (response.IsSuccessStatusCode)
            //    {
            //        return true;
            //    }
            //    else
            //    {
            //        MessageBox.Show("Error al actualizar el cliente: " + response.ReasonPhrase);
            //        return false;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error al actualizar el cliente desde la Api: " + ex.Message);
            //    return false;
            //}
            return false;

        }

        public async Task<bool> DeleteClienteAsync(int id) //eliminando un cliente
        {
            //try
            //{
            //    string urlSupabase = $"?id=eq.{id}"; //filtro para eliminar solo el cliente con el id que se pasa por el parametro id
            //    var response = await httpClient.DeleteAsync(urlSupabase);
            //    if (response.IsSuccessStatusCode)
            //    {
            //        return true;
            //    }
            //    else
            //    {
            //        MessageBox.Show("Error al eliminar el cliente: " + response.ReasonPhrase);
            //        return false;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error al eliminar el cliente desde la Api: " + ex.Message);
            //    return false;
            //}
            return false;
        }

        private HttpClient? SettingHttpClient()
        {
            Env.Load("../../../"); //cargando las variables de entorno del archivo .env
            //var urlApi = Environment.GetEnvironmentVariable("URLAPI");
            var urlApi = Environment.GetEnvironmentVariable("URLAPILOCAL");
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(urlApi+"Clientes");
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

