namespace Desktop.Views
{
    partial class PerfumesView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabPageLista = new TabPage();
            btnModificar = new FontAwesome.Sharp.IconButton();
            btnNuevo = new FontAwesome.Sharp.IconButton();
            btnBuscar = new FontAwesome.Sharp.IconButton();
            txtBusqueda = new TextBox();
            label2 = new Label();
            dataGridViewPerfumes = new DataGridView();
            tabPageAddEdit = new TabPage();
            btnCancelar = new FontAwesome.Sharp.IconButton();
            btnGuardar = new FontAwesome.Sharp.IconButton();
            txtMarca = new TextBox();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            txtPrecio = new TextBox();
            txtTamaño = new TextBox();
            txtEnvase = new TextBox();
            txtTipo = new TextBox();
            txtGenero = new TextBox();
            txtNombre = new TextBox();
            label1 = new Label();
            btnEliminar = new FontAwesome.Sharp.IconButton();
            tabControl1.SuspendLayout();
            tabPageLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPerfumes).BeginInit();
            tabPageAddEdit.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageLista);
            tabControl1.Controls.Add(tabPageAddEdit);
            tabControl1.Location = new Point(12, 72);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(776, 366);
            tabControl1.TabIndex = 0;
            // 
            // tabPageLista
            // 
            tabPageLista.Controls.Add(btnModificar);
            tabPageLista.Controls.Add(btnNuevo);
            tabPageLista.Controls.Add(btnBuscar);
            tabPageLista.Controls.Add(txtBusqueda);
            tabPageLista.Controls.Add(label2);
            tabPageLista.Controls.Add(dataGridViewPerfumes);
            tabPageLista.Location = new Point(4, 34);
            tabPageLista.Name = "tabPageLista";
            tabPageLista.Padding = new Padding(3);
            tabPageLista.Size = new Size(768, 328);
            tabPageLista.TabIndex = 0;
            tabPageLista.Text = "Lista";
            tabPageLista.UseVisualStyleBackColor = true;
            // 
            // btnModificar
            // 
            btnModificar.IconChar = FontAwesome.Sharp.IconChar.None;
            btnModificar.IconColor = Color.Black;
            btnModificar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnModificar.Location = new Point(650, 161);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(112, 34);
            btnModificar.TabIndex = 5;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.IconChar = FontAwesome.Sharp.IconChar.None;
            btnNuevo.IconColor = Color.Black;
            btnNuevo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnNuevo.Location = new Point(650, 109);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(112, 34);
            btnNuevo.TabIndex = 4;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.IconChar = FontAwesome.Sharp.IconChar.None;
            btnBuscar.IconColor = Color.Black;
            btnBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnBuscar.Location = new Point(650, 21);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(112, 34);
            btnBuscar.TabIndex = 3;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtBusqueda
            // 
            txtBusqueda.Location = new Point(82, 23);
            txtBusqueda.Name = "txtBusqueda";
            txtBusqueda.Size = new Size(539, 31);
            txtBusqueda.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 26);
            label2.Name = "label2";
            label2.Size = new Size(67, 25);
            label2.TabIndex = 1;
            label2.Text = "Buscar:";
            // 
            // dataGridViewPerfumes
            // 
            dataGridViewPerfumes.AllowUserToAddRows = false;
            dataGridViewPerfumes.AllowUserToDeleteRows = false;
            dataGridViewPerfumes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPerfumes.Location = new Point(6, 70);
            dataGridViewPerfumes.Name = "dataGridViewPerfumes";
            dataGridViewPerfumes.ReadOnly = true;
            dataGridViewPerfumes.RowHeadersWidth = 62;
            dataGridViewPerfumes.Size = new Size(615, 252);
            dataGridViewPerfumes.TabIndex = 0;
            // 
            // tabPageAddEdit
            // 
            tabPageAddEdit.Controls.Add(btnEliminar);
            tabPageAddEdit.Controls.Add(btnCancelar);
            tabPageAddEdit.Controls.Add(btnGuardar);
            tabPageAddEdit.Controls.Add(txtMarca);
            tabPageAddEdit.Controls.Add(label9);
            tabPageAddEdit.Controls.Add(label8);
            tabPageAddEdit.Controls.Add(label7);
            tabPageAddEdit.Controls.Add(label6);
            tabPageAddEdit.Controls.Add(label5);
            tabPageAddEdit.Controls.Add(label4);
            tabPageAddEdit.Controls.Add(label3);
            tabPageAddEdit.Controls.Add(txtPrecio);
            tabPageAddEdit.Controls.Add(txtTamaño);
            tabPageAddEdit.Controls.Add(txtEnvase);
            tabPageAddEdit.Controls.Add(txtTipo);
            tabPageAddEdit.Controls.Add(txtGenero);
            tabPageAddEdit.Controls.Add(txtNombre);
            tabPageAddEdit.Location = new Point(4, 34);
            tabPageAddEdit.Name = "tabPageAddEdit";
            tabPageAddEdit.Padding = new Padding(3);
            tabPageAddEdit.Size = new Size(768, 328);
            tabPageAddEdit.TabIndex = 1;
            tabPageAddEdit.Text = "Agregar/Editar";
            tabPageAddEdit.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.IconChar = FontAwesome.Sharp.IconChar.None;
            btnCancelar.IconColor = Color.Black;
            btnCancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCancelar.Location = new Point(609, 134);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(112, 34);
            btnCancelar.TabIndex = 16;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.IconChar = FontAwesome.Sharp.IconChar.None;
            btnGuardar.IconColor = Color.Black;
            btnGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnGuardar.Location = new Point(609, 88);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(112, 34);
            btnGuardar.TabIndex = 15;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // txtMarca
            // 
            txtMarca.Location = new Point(141, 91);
            txtMarca.Name = "txtMarca";
            txtMarca.Size = new Size(407, 31);
            txtMarca.TabIndex = 14;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(32, 282);
            label9.Name = "label9";
            label9.Size = new Size(60, 25);
            label9.TabIndex = 13;
            label9.Text = "Precio";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(32, 245);
            label8.Name = "label8";
            label8.Size = new Size(74, 25);
            label8.TabIndex = 12;
            label8.Text = "Tamaño";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(32, 208);
            label7.Name = "label7";
            label7.Size = new Size(66, 25);
            label7.TabIndex = 11;
            label7.Text = "Envase";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(32, 171);
            label6.Name = "label6";
            label6.Size = new Size(47, 25);
            label6.TabIndex = 10;
            label6.Text = "Tipo";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(32, 134);
            label5.Name = "label5";
            label5.Size = new Size(69, 25);
            label5.TabIndex = 9;
            label5.Text = "Genero";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(32, 97);
            label4.Name = "label4";
            label4.Size = new Size(60, 25);
            label4.TabIndex = 8;
            label4.Text = "Marca";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(32, 60);
            label3.Name = "label3";
            label3.Size = new Size(78, 25);
            label3.TabIndex = 7;
            label3.Text = "Nombre";
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(141, 276);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(407, 31);
            txtPrecio.TabIndex = 6;
            // 
            // txtTamaño
            // 
            txtTamaño.Location = new Point(141, 239);
            txtTamaño.Name = "txtTamaño";
            txtTamaño.Size = new Size(407, 31);
            txtTamaño.TabIndex = 5;
            // 
            // txtEnvase
            // 
            txtEnvase.Location = new Point(141, 202);
            txtEnvase.Name = "txtEnvase";
            txtEnvase.Size = new Size(407, 31);
            txtEnvase.TabIndex = 4;
            // 
            // txtTipo
            // 
            txtTipo.Location = new Point(141, 165);
            txtTipo.Name = "txtTipo";
            txtTipo.Size = new Size(407, 31);
            txtTipo.TabIndex = 3;
            // 
            // txtGenero
            // 
            txtGenero.Location = new Point(141, 128);
            txtGenero.Name = "txtGenero";
            txtGenero.Size = new Size(407, 31);
            txtGenero.TabIndex = 2;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(141, 54);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(407, 31);
            txtNombre.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(16, 21);
            label1.Name = "label1";
            label1.Size = new Size(189, 48);
            label1.TabIndex = 1;
            label1.Text = "Perfumes";
            // 
            // btnEliminar
            // 
            btnEliminar.IconChar = FontAwesome.Sharp.IconChar.None;
            btnEliminar.IconColor = Color.Black;
            btnEliminar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnEliminar.Location = new Point(609, 199);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(112, 34);
            btnEliminar.TabIndex = 17;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // PerfumesView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(tabControl1);
            Name = "PerfumesView";
            Text = "PerfumesView";
            tabControl1.ResumeLayout(false);
            tabPageLista.ResumeLayout(false);
            tabPageLista.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPerfumes).EndInit();
            tabPageAddEdit.ResumeLayout(false);
            tabPageAddEdit.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPageLista;
        private TabPage tabPageAddEdit;
        private Label label1;
        private Label label2;
        private DataGridView dataGridViewPerfumes;
        private TextBox txtBusqueda;
        private FontAwesome.Sharp.IconButton btnModificar;
        private FontAwesome.Sharp.IconButton btnNuevo;
        private FontAwesome.Sharp.IconButton btnBuscar;
        private TextBox txtGenero;
        private TextBox textBox2;
        private TextBox txtNombre;
        private TextBox txtPrecio;
        private TextBox txtTamaño;
        private TextBox txtEnvase;
        private TextBox txtTipo;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private TextBox txtMarca;
        private FontAwesome.Sharp.IconButton iconButton3;
        private FontAwesome.Sharp.IconButton btnCancelar;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private FontAwesome.Sharp.IconButton btnEliminar;
    }
}