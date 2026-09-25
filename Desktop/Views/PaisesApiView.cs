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
    public partial class PaisesApiView : Form
    {
        //ProvinciasApiService provinciasService = new ProvinciasApiService();
        PaisesApiService paisesService = new PaisesApiService();
        Pais? PaisModificado;
        public PaisesApiView()
        {
            InitializeComponent();
            _ = LoadPaises();
        }

        private async Task LoadPaises()
        {
            var paises = await paisesService.GetAllAsync();
            if (paises != null)
            {
                dataGridViewPaises.DataSource = paises;
                //ocultamos las columnas que no queremos mostrar
                dataGridViewPaises.Columns["Id"].Visible = false;
                //dataGridViewProvincias.Columns["ProvinciaId"].Visible = false;
                //dataGridViewProvincias.Columns["PaisId"].Visible = false;
                dataGridViewPaises.Columns["isdeleted"].Visible = false;

            }
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            var paises = await paisesService.GetAllWithFiltersAsync(txtBusqueda.Text);
            if (paises != null)
            {
                dataGridViewPaises.DataSource = paises;
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            Pais pais = new Pais
            {
                Name = txtNombre.Text,
                //PaisId = cboxPaises.SelectedValue != null ? (int)cboxPaises.SelectedValue : 0 // Asignar un valor predeterminado para ProvinciaId
            };
            bool paisGuardado;
            if (PaisModificado == null)
                paisGuardado = await paisesService.AddPaisesAsync(pais);
            else
            {
                pais.Id = PaisModificado.Id;
                paisGuardado = await paisesService.UpdatePaisesAsync(pais);
            }
            if (!paisGuardado)
            {
                MessageBox.Show("error al guardar el pais");
                return;
            }
            MessageBox.Show("pais guardado correctamente");
            await LoadPaises();
            ClearTextBox();
            tabControl1.SelectedTab = tabPageLista;
            PaisModificado = null;

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
            PaisModificado = null;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //capturamos una localidad seleccionada en el datagridview
            if (dataGridViewPaises.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un pais para modificar");
                return;
            }
            PaisModificado = (Pais)dataGridViewPaises.CurrentRow.DataBoundItem;
            //llenamos los campos del formulario con los datos de la localidad seleccionada
            txtNombre.Text = PaisModificado.Name;
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
            if (dataGridViewPaises.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un pais para eliminar");
                return;
            }
            var paisAEliminar = (Pais)dataGridViewPaises.CurrentRow.DataBoundItem;
            //preguntamos si esta seguro de eliminar la provincia
            var result = MessageBox.Show($"¿Está seguro de eliminar el pais {paisAEliminar.Name}?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                //eliminamos la provincia
                var paisEliminado = await paisesService.DeletePaisAsync((int)paisAEliminar.Id!);
                if (!paisEliminado)
                {
                    MessageBox.Show("error al eliminar el pais");
                    return;
                }

                MessageBox.Show($"pais {paisAEliminar.Name} eliminado correctamente");
                await LoadPaises();

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
                await LoadPaises();
            }
        }

        private async Task LoadDeleted()
        {
            var paises = await paisesService.GetAllDeletedAsync();
            if (paises != null)
            {
                dataGridViewPaises.DataSource = paises;
            }
        }

        private async void btnRestaurar_Click(object sender, EventArgs e)
        {
            //capturamos el pais seleccionado en el datagridview
            if (dataGridViewPaises.CurrentRow != null)
            {
                var paisesARestaurar = (Pais)dataGridViewPaises.CurrentRow.DataBoundItem;
                //preguntamos si esta seguro de restaurar al pais
                var result = MessageBox.Show($"¿Está seguro de restaurar al pais {paisesARestaurar.Name}?", "Confirmar restauración", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    //restauramos la provincia
                    var paisRestaurado = await paisesService.RestorePaisAsync((int)paisesARestaurar.Id!);
                    if (paisRestaurado)
                    {
                        MessageBox.Show($"pais {paisesARestaurar.Name} restaurado correctamente");
                        await LoadDeleted();
                    }
                    else
                    {
                        MessageBox.Show("error al restaurar el pais");
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un pais para restaurar");
            }
        }
    }
}
