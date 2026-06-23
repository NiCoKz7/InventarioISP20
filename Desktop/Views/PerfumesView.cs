using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Desktop.Models;
using Desktop.Service;

namespace Desktop.Views
{
    public partial class PerfumesView : Form
    {
        PerfumeService perfumeService = new PerfumeService();
        Perfume perfumeModificado;
        public PerfumesView()
        {
            InitializeComponent();
            LoadPerfumes();
        }

        private async void LoadPerfumes()
        {
            var perfumes = perfumeService.GetAllAsync();
            if (perfumes != null)
            {
                dataGridViewPerfumes.DataSource = perfumes;
            }
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            var perfumes = await perfumeService.GetAllWithFiltersAsync(txtBusqueda.Text);
            if (perfumes != null)
            {
                dataGridViewPerfumes.DataSource = perfumes;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPageAddEdit;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridViewPerfumes.CurrentRow != null)
            {
                perfumeModificado = (Perfume)dataGridViewPerfumes.CurrentRow.DataBoundItem;
                txtNombre.Text = perfumeModificado.nombre;
                txtMarca.Text = perfumeModificado.marca;
                txtGenero.Text = perfumeModificado.genero;
                txtTipo.Text = perfumeModificado.tipo;
                txtEnvase.Text = perfumeModificado.tipo_envase;
                txtTamaño.Text = perfumeModificado.tamaño_ml.ToString();
                txtPrecio.Text = perfumeModificado.precio.ToString();
                tabControl1.SelectedTab = tabPageAddEdit;
            }
            else
            {
                MessageBox.Show("Seleccione un perfume para modificar.");
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            Perfume perfume = new Perfume
            {
                nombre = txtNombre.Text,
                marca = txtMarca.Text,
                genero = txtGenero.Text,
                tipo = txtTipo.Text,
                tipo_envase = txtEnvase.Text,
                tamaño_ml = int.Parse(txtTamaño.Text),
                precio = int.Parse(txtPrecio.Text)
            };
            bool perfumeGuardado;
            if (perfumeModificado == null)
            {
                perfumeGuardado = await perfumeService.AddPerfumeAsync(perfume);
            }
            else
            {
                perfume.id = perfumeModificado.id;
                perfume.created_at = perfumeModificado.created_at;
                perfumeGuardado = await perfumeService.UpdatePerfumeAsync(perfume);
            }
            if (perfumeGuardado)
            {
                MessageBox.Show("Perfume guardado correctamente.");
                LoadPerfumes();
                ClearForm();
                tabControl1.SelectedTab = tabPageLista;
                perfumeModificado = null;
            }
            else
            {
                MessageBox.Show("Error al guardar el perfume.");
            }
        }

        private void ClearForm()
        {
            txtNombre.Text = "";
            txtMarca.Text = "";
            txtGenero.Text = "";
            txtTipo.Text = "";
            txtEnvase.Text = "";
            txtTamaño.Text = "";
            txtPrecio.Text = "";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPageLista;
            ClearForm();
            perfumeModificado = null;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //eliminando un perfume
            if (dataGridViewPerfumes.CurrentRow != null)
            {
                perfumeModificado = (Perfume)dataGridViewPerfumes.CurrentRow.DataBoundItem;
                var result = MessageBox.Show($"¿Está seguro de eliminar el perfume {perfumeModificado.nombre}?", "Confirmar eliminación", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    bool perfumeEliminado = perfumeService.DeletePerfumeAsync((int)perfumeModificado.id).Result;
                    if (perfumeEliminado)
                    {
                        MessageBox.Show("Perfume eliminado correctamente.");
                        LoadPerfumes();
                        perfumeModificado = null;
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el perfume.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un perfume para eliminar.");
            }
        }
    }
}
