using Desktop.Models;
using DotNetEnv;
using Supabase;
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
    public class ClienteSupabaseService
    {
 
        Supabase.Client supabase;

        public ClienteSupabaseService()
        {
            _ = SettingSupabaseClient();

        }

        public async Task<List<Cliente>?> GetAllAsync()//obteniendo clientes
        {
            try
            {
                var result = await supabase.From<Cliente>().Get();
                var clientes = result.Models;
                return clientes;
            }
            catch(Exception ex)
            { 
                MessageBox.Show("Error al obtener los clientes desde supabase: " + ex.Message); 
                return null;
            }
        }

        public async Task<List<Cliente>?> GetAllWithFiltersAsync(string filter)//obteniendo clientes mediante filtro
        {
            try
            {
                var result = await supabase
                .From<Cliente>()
                .Get();

                return result.Models
                        .Where(c =>
                            c.firstname.Contains(filter, StringComparison.OrdinalIgnoreCase) ||
                            c.lastname.Contains(filter, StringComparison.OrdinalIgnoreCase) ||
                            c.dni.Contains(filter, StringComparison.OrdinalIgnoreCase))
                        .ToList();
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
                var response = await supabase.From<Cliente>().Insert(cliente);
                return response.ResponseMessage!.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear el cliente desde supabase: " + ex.Message);
                return false;
            }

        }

        public async Task<bool> UpdateClienteAsync(Cliente cliente) //modificando un cliente
        {
            try
            {
                var response = await supabase.From<Cliente>().Upsert(cliente);
                return response.ResponseMessage!.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el cliente desde supabase: " + ex.Message);
                return false;
            }

        }

        public async Task<bool> DeleteClienteAsync(int id) //eliminando un cliente
        {
            try
            {
                await supabase.From<Cliente>()
                    .Where(c => c.id == id)
                    .Delete();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el cliente desde supabase: " + ex.Message);
                return false;
            }
        }

        private async Task SettingSupabaseClient()
        {
            Env.Load("../../../"); //cargando las variables de entorno del archivo .env
            var url = Environment.GetEnvironmentVariable("SUPABASE_URL");
            var key = Environment.GetEnvironmentVariable("SUPABASE_KEY");

            var options = new Supabase.SupabaseOptions
            {
                AutoConnectRealtime = true
            };

            supabase = new Supabase.Client(url, key, options);
            await supabase.InitializeAsync();
        }

    }
}

