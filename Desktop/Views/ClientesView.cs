using Desktop.Models;
using Desktop.Service;
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
    public partial class ClientesView : Form
    {
        ClientesService clientesService = new ClientesService();
        Cliente clienteModificado;
        public ClientesView()
        {
            InitializeComponent();
            //clientesService 
            LoadClientes();
        }

        private async void LoadClientes()
        {
            var clientes = await clientesService.GetAllAsync();
            if (clientes != null)
            {
                dataGridViewClientes.DataSource = clientes;
            }
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            var clientes = await clientesService.GetAllWithFiltersAsync(txtBusqueda.Text);
            if (clientes != null)
            {
                dataGridViewClientes.DataSource = clientes;
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente
            {
                firstname = txtNombre.Text,
                lastname = txtApellido.Text,
                dni = txtDni.Text,
                address = txtDireccion.Text
            };
            bool clienteGuardado;
            if (clienteModificado == null)
                clienteGuardado = await clientesService.AddClienteAsync(cliente);
            else
            {
                cliente.id = clienteModificado.id;
                cliente.created_at = clienteModificado.created_at;
                clienteGuardado = await clientesService.UpdateClienteAsync(cliente);
            }
            if (clienteGuardado)
            {
                MessageBox.Show("cliente guardado correctamente");
                LoadClientes();
                ClearTextBox();
                tabControl1.SelectedTab = tabPageLista;
                clienteModificado = null;
            }
            else
                MessageBox.Show("error al guardar el cliente");
        }

        private void ClearTextBox()
        {
            txtNombre.Text = "";
            txtApellido.Clear();
            txtDni.Clear();
            txtDireccion.Text = "";
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPageAgregarEditar;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPageLista;
            ClearTextBox();
            clienteModificado = null;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //capturamos el cliente seleccionado en el datagridview
            if (dataGridViewClientes.CurrentRow != null)
            {
                clienteModificado = (Cliente)dataGridViewClientes.CurrentRow.DataBoundItem;
                //llenamos los campos del formulario con los datos del cliente seleccionado
                txtNombre.Text = clienteModificado.firstname;
                txtApellido.Text = clienteModificado.lastname;
                txtDni.Text = clienteModificado.dni;
                txtDireccion.Text = clienteModificado.address;
                //cambiamos a la pestaña de agregar/editar
                tabControl1.SelectedTab = tabPageAgregarEditar;
            }
            else
            {
                MessageBox.Show("Seleccione un cliente para modificar");
            }
        }
    }
}
