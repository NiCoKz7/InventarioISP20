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
            try
            {
                var response = await httpClient.GetAsync($"?filtro={filter}");
                if (response.IsSuccessStatusCode)
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los clientes: " + ex.Message);
                return null;
            }
        }
        public async Task<List<Cliente>?> GetAllDeletedAsync()//obteniendo clientes
        {
            try
            {
                var response = await httpClient.GetAsync("deleteds");
                if (response.IsSuccessStatusCode)
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los clientes: " + ex.Message);
                return null;
            }
        }

        public async Task<bool> AddClienteAsync(Cliente cliente)//agregando un cliente
        {
            try
            {
                SettingJsonSerializer();
                var json = JsonSerializer.Serialize(cliente, options);
                var ClienteJson = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("", ClienteJson);
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Error al crear el cliente: " + response.ReasonPhrase);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear el cliente desde la Api: " + ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateClienteAsync(Cliente cliente) //modificando un cliente
        {
            try
            {
                // Configuramos las opciones de serialización para ignorar propiedades nulas y hacer que la búsqueda de propiedades sea insensible a mayúsculas
                var options = new JsonSerializerOptions
                {
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                    PropertyNameCaseInsensitive = true,
                };
                //configuramos la serializacion del cliente para que ignore las propiedades nulas y no tenga en cuenta mayusculas o minusculas en los nombres de las propiedades
                SettingJsonSerializer();
                var json = JsonSerializer.Serialize(cliente, options);
                var ClienteJson = new StringContent(json, Encoding.UTF8, "application/json");
                string IdCliente = cliente.Id.ToString(); //filtro para actualizar solo el cliente con el id que se pasa por el parametro cliente
                var response = await httpClient.PutAsync(IdCliente, ClienteJson);
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Error al actualizar el cliente: " + response.ReasonPhrase);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el cliente desde la Api: " + ex.Message);
                return false;
            }

        }

        public async Task<bool> DeleteClienteAsync(int id) //eliminando un cliente
        {
            try
            {
                var response = await httpClient.DeleteAsync(id.ToString());
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Error al eliminar el cliente: " + response.ReasonPhrase);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el cliente desde la Api: " + ex.Message);
                return false;
            }

        }
        //restaurar un cliente
        public async Task<bool> RestoreClienteAsync(int id) //eliminando un cliente
        {
            try
            {
                var response = await httpClient.PutAsync($"restore/{id}", null);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Error al restaurar el cliente: " + response.ReasonPhrase);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al restaurar el cliente desde la Api: " + ex.Message);
                return false;
            }
        }

        private HttpClient? SettingHttpClient()
        {
            Env.Load("../../../"); //cargando las variables de entorno del archivo .env
            //var urlApi = Environment.GetEnvironmentVariable("URLAPI");
            var urlApi = Environment.GetEnvironmentVariable("URLAPILOCAL");
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(urlApi+"Clientes/");
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

