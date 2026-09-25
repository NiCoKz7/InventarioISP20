namespace Desktop.Views
{
    partial class LocalidadesApiView
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
            label1 = new Label();
            tabControl1 = new TabControl();
            tabPageLista = new TabPage();
            botonBuscar = new Button();
            textBusqueda = new TextBox();
            btnRestaurar = new Button();
            checkVerEliminados = new CheckBox();
            btnEliminar = new FontAwesome.Sharp.IconButton();
            btnModificar = new FontAwesome.Sharp.IconButton();
            btnNuevo = new FontAwesome.Sharp.IconButton();
            label2 = new Label();
            dataGridViewLocalidades = new DataGridView();
            tabPageAgregarEditar = new TabPage();
            label7 = new Label();
            cboxProvincias = new ComboBox();
            txtNombre = new TextBox();
            btnCancelar = new FontAwesome.Sharp.IconButton();
            btnGuardar = new FontAwesome.Sharp.IconButton();
            label3 = new Label();
            tabControl1.SuspendLayout();
            tabPageLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewLocalidades).BeginInit();
            tabPageAgregarEditar.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Black", 11F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(207, 31);
            label1.TabIndex = 0;
            label1.Text = "Localidades Api";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageLista);
            tabControl1.Controls.Add(tabPageAgregarEditar);
            tabControl1.Location = new Point(12, 43);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(776, 395);
            tabControl1.TabIndex = 1;
            // 
            // tabPageLista
            // 
            tabPageLista.Controls.Add(botonBuscar);
            tabPageLista.Controls.Add(textBusqueda);
            tabPageLista.Controls.Add(btnRestaurar);
            tabPageLista.Controls.Add(checkVerEliminados);
            tabPageLista.Controls.Add(btnEliminar);
            tabPageLista.Controls.Add(btnModificar);
            tabPageLista.Controls.Add(btnNuevo);
            tabPageLista.Controls.Add(label2);
            tabPageLista.Controls.Add(dataGridViewLocalidades);
            tabPageLista.Location = new Point(4, 34);
            tabPageLista.Name = "tabPageLista";
            tabPageLista.Padding = new Padding(3);
            tabPageLista.Size = new Size(768, 357);
            tabPageLista.TabIndex = 0;
            tabPageLista.Text = "Lista";
            tabPageLista.UseVisualStyleBackColor = true;
            // 
            // botonBuscar
            // 
            botonBuscar.Location = new Point(600, 20);
            botonBuscar.Name = "botonBuscar";
            botonBuscar.Size = new Size(112, 34);
            botonBuscar.TabIndex = 10;
            botonBuscar.Text = "Buscar";
            botonBuscar.UseVisualStyleBackColor = true;
            botonBuscar.Click += botonBuscar_Click;
            // 
            // textBusqueda
            // 
            textBusqueda.Location = new Point(118, 17);
            textBusqueda.Name = "textBusqueda";
            textBusqueda.Size = new Size(444, 31);
            textBusqueda.TabIndex = 9;
            textBusqueda.KeyPress += TextBusqueda_KeyPress;
            // 
            // btnRestaurar
            // 
            btnRestaurar.Enabled = false;
            btnRestaurar.Location = new Point(600, 315);
            btnRestaurar.Name = "btnRestaurar";
            btnRestaurar.Size = new Size(112, 34);
            btnRestaurar.TabIndex = 8;
            btnRestaurar.Text = "Restaurar";
            btnRestaurar.UseVisualStyleBackColor = true;
            btnRestaurar.Click += btnRestaurar_Click;
            // 
            // checkVerEliminados
            // 
            checkVerEliminados.AutoSize = true;
            checkVerEliminados.Location = new Point(600, 280);
            checkVerEliminados.Name = "checkVerEliminados";
            checkVerEliminados.Size = new Size(154, 29);
            checkVerEliminados.TabIndex = 7;
            checkVerEliminados.Text = "Ver eliminados";
            checkVerEliminados.UseVisualStyleBackColor = true;
            checkVerEliminados.CheckedChanged += checkVerEliminados_CheckedChanged;
            // 
            // btnEliminar
            // 
            btnEliminar.IconChar = FontAwesome.Sharp.IconChar.None;
            btnEliminar.IconColor = Color.Black;
            btnEliminar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnEliminar.Location = new Point(600, 163);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(112, 34);
            btnEliminar.TabIndex = 6;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnModificar
            // 
            btnModificar.IconChar = FontAwesome.Sharp.IconChar.None;
            btnModificar.IconColor = Color.Black;
            btnModificar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnModificar.Location = new Point(600, 123);
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
            btnNuevo.Location = new Point(600, 83);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(112, 34);
            btnNuevo.TabIndex = 4;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 20);
            label2.Name = "label2";
            label2.Size = new Size(67, 25);
            label2.TabIndex = 1;
            label2.Text = "Buscar:";
            // 
            // dataGridViewLocalidades
            // 
            dataGridViewLocalidades.AllowUserToAddRows = false;
            dataGridViewLocalidades.AllowUserToDeleteRows = false;
            dataGridViewLocalidades.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewLocalidades.Location = new Point(6, 58);
            dataGridViewLocalidades.Name = "dataGridViewLocalidades";
            dataGridViewLocalidades.ReadOnly = true;
            dataGridViewLocalidades.RowHeadersWidth = 62;
            dataGridViewLocalidades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewLocalidades.Size = new Size(556, 293);
            dataGridViewLocalidades.TabIndex = 0;
            // 
            // tabPageAgregarEditar
            // 
            tabPageAgregarEditar.Controls.Add(label7);
            tabPageAgregarEditar.Controls.Add(cboxProvincias);
            tabPageAgregarEditar.Controls.Add(txtNombre);
            tabPageAgregarEditar.Controls.Add(btnCancelar);
            tabPageAgregarEditar.Controls.Add(btnGuardar);
            tabPageAgregarEditar.Controls.Add(label3);
            tabPageAgregarEditar.Location = new Point(4, 34);
            tabPageAgregarEditar.Name = "tabPageAgregarEditar";
            tabPageAgregarEditar.Padding = new Padding(3);
            tabPageAgregarEditar.Size = new Size(768, 357);
            tabPageAgregarEditar.TabIndex = 1;
            tabPageAgregarEditar.Text = "Agregar/Editar";
            tabPageAgregarEditar.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(42, 179);
            label7.Name = "label7";
            label7.Size = new Size(83, 25);
            label7.TabIndex = 14;
            label7.Text = "Provincia";
            // 
            // cboxProvincias
            // 
            cboxProvincias.FormattingEnabled = true;
            cboxProvincias.Location = new Point(186, 179);
            cboxProvincias.Name = "cboxProvincias";
            cboxProvincias.Size = new Size(325, 33);
            cboxProvincias.TabIndex = 13;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(186, 107);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(325, 31);
            txtNombre.TabIndex = 12;
            // 
            // btnCancelar
            // 
            btnCancelar.IconChar = FontAwesome.Sharp.IconChar.None;
            btnCancelar.IconColor = Color.Black;
            btnCancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCancelar.Location = new Point(633, 177);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(112, 34);
            btnCancelar.TabIndex = 9;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.IconChar = FontAwesome.Sharp.IconChar.None;
            btnGuardar.IconColor = Color.Black;
            btnGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnGuardar.Location = new Point(633, 104);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(112, 34);
            btnGuardar.TabIndex = 8;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(42, 113);
            label3.Name = "label3";
            label3.Size = new Size(78, 25);
            label3.TabIndex = 4;
            label3.Text = "Nombre";
            // 
            // LocalidadesApiView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Controls.Add(label1);
            Name = "LocalidadesApiView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Clientes";
            tabControl1.ResumeLayout(false);
            tabPageLista.ResumeLayout(false);
            tabPageLista.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewLocalidades).EndInit();
            tabPageAgregarEditar.ResumeLayout(false);
            tabPageAgregarEditar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TabControl tabControl1;
        private TabPage tabPageLista;
        private TabPage tabPageAgregarEditar;
        private DataGridView dataGridViewLocalidades;
        private Label label2;
        private TextBox textBox1;
        private FontAwesome.Sharp.IconButton btnCancelar;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private Label label3;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox txtNombre;
        private FontAwesome.Sharp.IconButton btnNuevo;
        private FontAwesome.Sharp.IconButton btnModificar;
        private FontAwesome.Sharp.IconButton btnEliminar;
        private CheckBox checkVerEliminados;
        private Button btnRestaurar;
        private Label label7;
        private ComboBox cboxProvincias;
        private Button botonBuscar;
        private TextBox textBusqueda;
    }
}