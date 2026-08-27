using Desktop.Models;
using DotNetEnv;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.Views
{
    public partial class OpenrouterView : Form
    {
        public OpenrouterView()
        {
            InitializeComponent();
        }

        private async void btnEnviar_Click(object sender, EventArgs e)
        {
            txtRto.Text = "Enviando consulta a la API de OpenRouter, por favor espere...";
            Env.Load("../../../"); // Cargando las variables de entorno del archivo .env
            var apikey = Environment.GetEnvironmentVariable("APIKEY_OPENROUTER");
            if (apikey == null)
            {
                MessageBox.Show("No se encontró la variable de entorno APIKEY_OPENROUTER");
                return;
            }
            if (string.IsNullOrEmpty(txtPregunta.Text))
            {
                MessageBox.Show("Por favor ingrese una consulta");
                return;
            }
            // Creamos un HttpClient para hacer la petición a la API de OpenRouter
            using (var client = new HttpClient())
            {
                var url = "https://openrouter.ai/api/v1/chat/completions";

                client.DefaultRequestHeaders.Add("Authorization",$"Bearer {apikey}");
                var requestBody = new
                {
                    model = "openai/gpt-chat-latest",
                    max_tokens = 300,
                    messages = new[]
                    {
                    new
                    {
                        role = "user",
                        content = txtPregunta.Text
                    }
                    }
                };
                var response = await client.PostAsJsonAsync(url, requestBody);
                if (response == null)
                {
                    txtRto.Text = "No se pudo obtener la respuesta de la API";
                    return;
                }
                ResponseOpenrouter? responseOpenRouter = await response.Content.ReadFromJsonAsync<ResponseOpenrouter>();
                if (responseOpenRouter == null)
                {
                    txtRto.Text = "No se pudo deserializar la respuesta de la API";
                    return;
                }
                txtRto.Text = responseOpenRouter.choices[0].message.content;
            }
        }
    }
}
