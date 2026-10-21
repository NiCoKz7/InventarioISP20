using Desktop.Service;
using Microsoft.Reporting.WinForms;
using Services.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.Views
{
    public partial class SplashView : Form
    {
        bool dataReady = false;
        bool printReady = false;
        public SplashView()
        {
            InitializeComponent();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            progressBar.Increment(5);
            if(dataReady && printReady)
            {
                timer.Stop();
                this.Hide();
                IniciarSesionView iniciarSesion = new IniciarSesionView();
                iniciarSesion.ShowDialog();
                this.Close();
            }
        }

        private async Task GetData()
        {
            await Task.Run(async () =>
            {
                ClientesApiService clientesService = new ClientesApiService();
                var clientes = await clientesService.GetAllAsync();
                dataReady = true;
            });
        }

        private async Task PrintReport()
        {
            await Task.Run(() =>
            {
                ReportViewer _report = new ReportViewer();
                _report.LocalReport.ReportEmbeddedResource = "Desktop.Reports.ClienteInfor.rdlc";

                var clientes = new List<Cliente>
                {
                    new Cliente { Id = 1, Firstname = "auti alberto", Lastname = "gomis", Address = "Calle 123", Dni = "12345678" }
                };

                _report.LocalReport.DataSources.Add(new ReportDataSource("DSClientes", clientes));
                _report.SetDisplayMode(DisplayMode.PrintLayout);
                _report.ZoomMode = ZoomMode.Percent;
                _report.ZoomPercent = 100;

                _report.RefreshReport();
                printReady = true;
            });
        }

        private async void SplashView_Activated(object sender, EventArgs e)
        {
            var getDataTask = GetData();
            var printReportTask = PrintReport();
            await Task.WhenAll(getDataTask, printReportTask);
        }
    }
}
