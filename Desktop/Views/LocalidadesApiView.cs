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
    public partial class LocalidadesApiView : Form
    {
        ProvinciasApiService provinciasService = new ProvinciasApiService();
        LocalidadesApiService localidadesService = new LocalidadesApiService();
        Localidad? LocalidadModificado;
        public LocalidadesApiView()
        {
            InitializeComponent();
            //localidadesService 
            _ = LoadLocalidades();
            _ = LoadComboProvincias();
        }

        private async Task LoadComboProvincias()
        {
            var provincias = await provinciasService.GetAllAsync();
            if (provincias != null)
            {
                cboxProvincias.DataSource = provincias;
                cboxProvincias.DisplayMember = "Name";
                cboxProvincias.ValueMember = "Id";
                cboxProvincias.SelectedValue = -1; // No seleccionar ningún elemento por defecto
            }
        }

        private async Task LoadLocalidades()
        {
            var localidades = await localidadesService.GetAllAsync();
            if (localidades != null)
            {
                dataGridViewLocalidades.DataSource = localidades;
                //ocultamos las columnas que no queremos mostrar
                dataGridViewLocalidades.Columns["Id"].Visible = false;
                dataGridViewLocalidades.Columns["ProvinciaId"].Visible = false;
                //dataGridViewLocalidades.Columns["LocalidadId"].Visible = false;
                dataGridViewLocalidades.Columns["isdeleted"].Visible = false;

            }
        }


        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            Localidad localidad = new Localidad
            {
                Name = txtNombre.Text,
                ProvinciaId = cboxProvincias.SelectedValue != null ? (int)cboxProvincias.SelectedValue : 0 // Asignar un valor predeterminado para ProvinciaId
            };
            bool localidadGuardado;
            if (LocalidadModificado == null)
                localidadGuardado = await localidadesService.AddLocalidadAsync(localidad);
            else
            {
                localidad.Id = LocalidadModificado.Id;
                localidadGuardado = await localidadesService.UpdateLocalidadAsync(localidad);
            }
            if (!localidadGuardado)
            {
                MessageBox.Show("error al guardar la localidad");
                return;
            }
            MessageBox.Show("localidad guardada correctamente");
            await LoadLocalidades();
            ClearTextBox();
            tabControl1.SelectedTab = tabPageLista;
            LocalidadModificado = null;

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
            LocalidadModificado = null;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //capturamos una localidad seleccionada en el datagridview
            if (dataGridViewLocalidades.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una localidad para modificar");
                return;
            }
            LocalidadModificado = (Localidad)dataGridViewLocalidades.CurrentRow.DataBoundItem;
            //llenamos los campos del formulario con los datos de la localidad seleccionada
            txtNombre.Text = LocalidadModificado.Name;
            if (LocalidadModificado.ProvinciaId != 0)
                cboxProvincias.SelectedValue = LocalidadModificado.ProvinciaId;
            //cambiamos a la pestaña de agregar/editar
            tabControl1.SelectedTab = tabPageAgregarEditar;
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            //capturamos la localidad seleccionada en el datagridview
            if (dataGridViewLocalidades.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una localidad para eliminar");
                return;
            }
            var localidadAEliminar = (Localidad)dataGridViewLocalidades.CurrentRow.DataBoundItem;
            //preguntamos si esta seguro de eliminar la localidad
            var result = MessageBox.Show($"¿Está seguro de eliminar la localidad {localidadAEliminar.Name}?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                //eliminamos la localidad
                var localidadEliminada = await localidadesService.DeleteLocalidadAsync((int)localidadAEliminar.Id!);
                if (!localidadEliminada)
                {
                    MessageBox.Show("error al eliminar la localidad");
                    return;
                }

                MessageBox.Show($"localidad {localidadAEliminar.Name} eliminada correctamente");
                await LoadLocalidades();

            }
        }

        private async void checkVerEliminados_CheckedChanged(object sender, EventArgs e)
        {
            textBusqueda.Enabled = !checkVerEliminados.Checked;
            botonBuscar.Enabled = !checkVerEliminados.Checked;
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
                await LoadLocalidades();
            }
        }

        private async Task LoadDeleted()
        {
            var localidades = await localidadesService.GetAllDeletedAsync();
            if (localidades != null)
            {
                dataGridViewLocalidades.DataSource = localidades;
            }
        }

        private async void btnRestaurar_Click(object sender, EventArgs e)
        {
            //capturamos la localidad seleccionado en el datagridview
            if (dataGridViewLocalidades.CurrentRow != null)
            {
                var localidadARestaurar = (Localidad)dataGridViewLocalidades.CurrentRow.DataBoundItem;
                //preguntamos si esta seguro de restaurar a la localidad
                var result = MessageBox.Show($"¿Está seguro de restaurar a la localidad {localidadARestaurar.Name}?", "Confirmar restauración", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    //restauramos la localidad
                    var localidadRestaurada = await localidadesService.RestoreLocalidadAsync((int)localidadARestaurar.Id!);
                    if (localidadRestaurada)
                    {
                        MessageBox.Show($"localidad {localidadARestaurar.Name} restaurada correctamente");
                        await LoadDeleted();
                    }
                    else
                    {
                        MessageBox.Show("error al restaurar la localidad");
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione una localidad para restaurar");
            }
        }

        private void TextBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            // chequeamos si la tecla presionada es Enter y pulsamos el boton de buscar
            if (e.KeyChar == (char)Keys.Enter)
            {
                botonBuscar.PerformClick();
                e.Handled = true; // Evita que el sonido de "ding" se reproduzca
            }
        }

        private async void botonBuscar_Click(object sender, EventArgs e)
        {
            var localidades = await localidadesService.GetAllWithFiltersAsync(textBusqueda.Text);
            if (localidades != null)
            {
                dataGridViewLocalidades.DataSource = localidades;
            }
        }
    }
}
