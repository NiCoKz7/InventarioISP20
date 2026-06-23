namespace Desktop.Views
{
    public partial class MenuPrincipalView : Form
    {
        public MenuPrincipalView()
        {
            InitializeComponent();
        }

        #region codigo del boton saludo
        private void BtnWelcome_Click(object sender, EventArgs e)
        {
            MessageBox.Show("bienvenido a la app de escritorio");
        }
        #endregion

        private void salirDelSistema_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SubMenuArticulos_Click(object sender, EventArgs e)
        {
            ArticulosView articulosView = new();
            articulosView.MdiParent = this; // Establece el formulario principal como padre MDI
            articulosView.Show();
        }

        private void SubMenuCategorias_Click(object sender, EventArgs e)
        {
            CategoriasView categoriasView = new();
            categoriasView.ShowDialog();
            //no puedo volver a abrir la ventana de categoriasView porque ShowDialog() bloquea la ventana principal hasta que se cierre la ventana de categoriasView. Si quiero poder abrir la ventana de categoriasView varias veces, debo usar Show() en lugar de ShowDialog().
        }

        private void SubMenuClientes_Click(object sender, EventArgs e)
        {
            ClientesView clientesView = new();
            clientesView.ShowDialog();
        }

        private void SubMenuPerfumes_Click(object sender, EventArgs e)
        {
            PerfumesView perfumesView = new(); 
            perfumesView.ShowDialog();
        }
    }
}
