using Desktop.Service;
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
    public partial class ProvinciasApiView : Form
    {
        ProvinciasApiService provinciasService = new ProvinciasApiService();
        PaisesApiService paisesService = new PaisesApiService();
        Provincia? ProvinciaModificada;
        public ProvinciasApiView()
        {
            InitializeComponent();
            //localidadesService 
            _ = LoadProvincias();
            _ = LoadComboPaises();
        }

        private async Task LoadComboPaises()
        {
            var paises = await paisesService.GetAllAsync();
            if (paises != null)
            {
                cboxPaises.DataSource = paises;
                cboxPaises.DisplayMember = "Name";
                cboxPaises.ValueMember = "Id";
                cboxPaises.SelectedValue = -1; // No seleccionar ningún elemento por defecto
            }
        }

        private async Task LoadProvincias()
        {
            var provincias = await provinciasService.GetAllAsync();
            if (provincias != null)
            {
                dataGridViewProvincias.DataSource = provincias;
                //ocultamos las columnas que no queremos mostrar
                dataGridViewProvincias.Columns["Id"].Visible = false;
                //dataGridViewProvincias.Columns["ProvinciaId"].Visible = false;
                dataGridViewProvincias.Columns["PaisId"].Visible = false;
                dataGridViewProvincias.Columns["isdeleted"].Visible = false;

            }
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            var provincias = await provinciasService.GetAllWithFiltersAsync(txtBusqueda.Text);
            if (provincias != null)
            {
                dataGridViewProvincias.DataSource = provincias;
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            Provincia provincia = new Provincia
            {
                Name = txtNombre.Text,
                PaisId = cboxPaises.SelectedValue != null ? (int)cboxPaises.SelectedValue : 0 // Asignar un valor predeterminado para ProvinciaId
            };
            bool provinciaGuardado;
            if (ProvinciaModificada == null)
                provinciaGuardado = await provinciasService.AddProvinciaAsync(provincia);
            else
            {
                provincia.Id = ProvinciaModificada.Id;
                provinciaGuardado = await provinciasService.UpdateProvinciaAsync(provincia);
            }
            if (!provinciaGuardado)
            {
                MessageBox.Show("error al guardar la provincia");
                return;
            }
            MessageBox.Show("provincia guardada correctamente");
            await LoadProvincias();
            ClearTextBox();
            tabControl1.SelectedTab = tabPageLista;
            ProvinciaModificada = null;

        }

        private void ClearTextBox()
        {
            txtNombre.Text = "";
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPageAgregarEditar;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPageLista;
            ClearTextBox();
            ProvinciaModificada = null;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //capturamos una localidad seleccionada en el datagridview
            if (dataGridViewProvincias.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una provincia para modificar");
                return;
            }
            ProvinciaModificada = (Provincia)dataGridViewProvincias.CurrentRow.DataBoundItem;
            //llenamos los campos del formulario con los datos de la localidad seleccionada
            txtNombre.Text = ProvinciaModificada.Name;
            if (ProvinciaModificada.PaisId != 0)
                cboxPaises.SelectedValue = ProvinciaModificada.PaisId;
            //cambiamos a la pestaña de agregar/editar
            tabControl1.SelectedTab = tabPageAgregarEditar;
        }

        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            // chequeamos si la tecla presionada es Enter y pulsamos el boton de buscar
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnBuscar.PerformClick();
                e.Handled = true; // Evita que el sonido de "ding" se reproduzca
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            //capturamos la provincia seleccionada en el datagridview
            if (dataGridViewProvincias.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una provincia para eliminar");
                return;
            }
            var provinciaAEliminar = (Provincia)dataGridViewProvincias.CurrentRow.DataBoundItem;
            //preguntamos si esta seguro de eliminar la provincia
            var result = MessageBox.Show($"¿Está seguro de eliminar la provincia {provinciaAEliminar.Name}?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                //eliminamos la provincia
                var provinciasEliminada = await provinciasService.DeleteProvinciaAsync((int)provinciaAEliminar.Id!);
                if (!provinciasEliminada)
                {
                    MessageBox.Show("error al eliminar la provincia");
                    return;
                }

                MessageBox.Show($"provincia {provinciaAEliminar.Name} eliminada correctamente");
                await LoadProvincias();

            }
        }

        private async void checkVerEliminados_CheckedChanged(object sender, EventArgs e)
        {
            txtBusqueda.Enabled = !checkVerEliminados.Checked;
            btnBuscar.Enabled = !checkVerEliminados.Checked;
            btnModificar.Enabled = !checkVerEliminados.Checked;
            btnEliminar.Enabled = !checkVerEliminados.Checked;
            btnNuevo.Enabled = !checkVerEliminados.Checked;
            btnRestaurar.Enabled = checkVerEliminados.Checked;
            if (checkVerEliminados.Checked)
            {
                await LoadDeleted();
            }
            else
            {
                await LoadProvincias();
            }
        }

        private async Task LoadDeleted()
        {
            var provincias = await provinciasService.GetAllDeletedAsync();
            if (provincias != null)
            {
                dataGridViewProvincias.DataSource = provincias;
            }
        }

        private async void btnRestaurar_Click(object sender, EventArgs e)
        {
            //capturamos la provincia seleccionado en el datagridview
            if (dataGridViewProvincias.CurrentRow != null)
            {
                var provinciasARestaurar = (Provincia)dataGridViewProvincias.CurrentRow.DataBoundItem;
                //preguntamos si esta seguro de restaurar a la provincia
                var result = MessageBox.Show($"¿Está seguro de restaurar a la provincia {provinciasARestaurar.Name}?", "Confirmar restauración", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    //restauramos la provincia
                    var provinciasRestaurada = await provinciasService.RestoreProvinciaAsync((int)provinciasARestaurar.Id!);
                    if (provinciasRestaurada)
                    {
                        MessageBox.Show($"provincia {provinciasARestaurar.Name} restaurada correctamente");
                        await LoadDeleted();
                    }
                    else
                    {
                        MessageBox.Show("error al restaurar la provincia");
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione una provincia para restaurar");
            }
        }
    }
}
