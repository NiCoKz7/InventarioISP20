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
    public partial class ClientesApiView : Form
    {
        ClientesApiService clientesService = new ClientesApiService();
        Cliente? clienteModificado;
        public ClientesApiView()
        {
            InitializeComponent();
            //clientesService 
            _ = LoadClientes();
        }

        private async Task LoadClientes()
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
                Firstname = txtNombre.Text,
                Lastname = txtApellido.Text,
                Dni = txtDni.Text,
                Address = txtDireccion.Text,
                LocalidadId = 1 // Asignar un valor predeterminado para LocalidadId
            };
            bool clienteGuardado;
            if (clienteModificado == null)
                clienteGuardado = await clientesService.AddClienteAsync(cliente);
            else
            {
                cliente.Id = clienteModificado.Id;
                cliente.Created_at = clienteModificado.Created_at;
                cliente.LocalidadId = clienteModificado.LocalidadId;
                clienteGuardado = await clientesService.UpdateClienteAsync(cliente);
            }
            if (!clienteGuardado)
            {
                MessageBox.Show("error al guardar el cliente");
                return;
            }
            MessageBox.Show("cliente guardado correctamente");
            await LoadClientes();
            ClearTextBox();
            tabControl1.SelectedTab = tabPageLista;
            clienteModificado = null;
            
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
            if (dataGridViewClientes.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un cliente para modificar");
                return;
            }
            clienteModificado = (Cliente)dataGridViewClientes.CurrentRow.DataBoundItem;
            //llenamos los campos del formulario con los datos del cliente seleccionado
            txtNombre.Text = clienteModificado.Firstname;
            txtApellido.Text = clienteModificado.Lastname;
            txtDni.Text = clienteModificado.Dni;
            txtDireccion.Text = clienteModificado.Address;
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
            //capturamos el cliente seleccionado en el datagridview
            if (dataGridViewClientes.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un cliente para eliminar");
                return;
            }
            var clienteAEliminar = (Cliente)dataGridViewClientes.CurrentRow.DataBoundItem;
            //preguntamos si esta seguro de eliminar el cliente
            var result = MessageBox.Show($"¿Está seguro de eliminar al cliente {clienteAEliminar.Firstname} {clienteAEliminar.Lastname}?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                //eliminamos al cliente
                var clienteEliminado = await clientesService.DeleteClienteAsync((int)clienteAEliminar.Id!);
                if (!clienteEliminado)
                {
                    MessageBox.Show("error al eliminar el cliente");
                    return;
                }

                MessageBox.Show($"cliente {clienteAEliminar.Firstname} {clienteAEliminar.Lastname} eliminado correctamente");
                await LoadClientes();

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
                await LoadClientes();
            }
        }

        private async Task LoadDeleted()
        {
            var clientes = await clientesService.GetAllDeletedAsync();
            if (clientes != null)
            {
                dataGridViewClientes.DataSource = clientes;
            }
        }

        private async void btnRestaurar_Click(object sender, EventArgs e)
        {
            //capturamos el cliente seleccionado en el datagridview
            if (dataGridViewClientes.CurrentRow != null)
            {
                var clienteARestaurar = (Cliente)dataGridViewClientes.CurrentRow.DataBoundItem;
                //preguntamos si esta seguro de restaurar el cliente
                var result = MessageBox.Show($"¿Está seguro de restaurar al cliente {clienteARestaurar.Firstname} {clienteARestaurar.Lastname}?", "Confirmar restauración", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    //restauramos al cliente
                    var clienteRestaurado = await clientesService.RestoreClienteAsync((int)clienteARestaurar.Id!);
                    if (clienteRestaurado)
                    {
                        MessageBox.Show($"cliente {clienteARestaurar.Firstname} {clienteARestaurar.Lastname} restaurado correctamente");
                        await LoadDeleted();
                    }
                    else
                    {
                        MessageBox.Show("error al restaurar el cliente");
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un cliente para restaurar");
            }
        }
    }
}
