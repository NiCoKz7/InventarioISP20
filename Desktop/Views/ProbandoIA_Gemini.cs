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
    public partial class ProbandoIA_Gemini : Form
    {
        public ProbandoIA_Gemini()
        {
            InitializeComponent();
        }

        private async void btnEnviar_Click(object sender, EventArgs e)
        {
            txtRespuesta.Text = "Enviando consulta a la API de Gemini, por favor espere...";
            Env.Load("../../../"); //cargando las variables de entorno del archivo .env
            var apikey = Environment.GetEnvironmentVariable("APIKEY_GEMINI");
            if(apikey == null)
            {
                MessageBox.Show("No se encontró la variable de entorno APIKEY_GEMINI");
                return;
            }
            if (string.IsNullOrEmpty(txtConsulta.Text))
            {
                MessageBox.Show("Por favor ingrese una consulta");
                return;
            }
            //txtRespuesta.Text = $"API Key: {apikey?.Substring(0,6)}";
            //creamos un httpclient para hacer la peticion a la api de gemini con using
            using (var client = new HttpClient())
            {
                var url = "https://generativelanguage.googleapis.com/v1beta/interactions";
                client.DefaultRequestHeaders.Add("x-goog-api-key", $" {apikey}");
                var requestBody = new
                {
                    model = "gemini-3.5-flash",
                    input = txtConsulta.Text
                };
                //var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");
                var response = await client.PostAsJsonAsync(url, requestBody);
                if(response == null)
                {
                    txtRespuesta.Text = "No se pudo obtener la respuesta de la API";
                    return;
                }
                ResponseGemini? responseGemini = await response.Content.ReadFromJsonAsync<ResponseGemini>();
                if(responseGemini == null)
                {
                    txtRespuesta.Text = "No se pudo deseerializar la respuesta de la API";
                    return;
                }
                txtRespuesta.Text = responseGemini.steps[1].content[0].text;
            }
        }
    }
}
