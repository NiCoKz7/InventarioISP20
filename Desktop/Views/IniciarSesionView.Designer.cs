namespace Desktop.Views
{
    partial class IniciarSesionView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IniciarSesionView));
            btnIniciarSesion = new Button();
            btnCancelar = new Button();
            label1 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            textBoxUser = new TextBox();
            textBoxPassword = new TextBox();
            checkBoxVerPassword = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnIniciarSesion
            // 
            btnIniciarSesion.Location = new Point(554, 305);
            btnIniciarSesion.Name = "btnIniciarSesion";
            btnIniciarSesion.Size = new Size(140, 50);
            btnIniciarSesion.TabIndex = 1;
            btnIniciarSesion.Text = "Iniciar Sesion";
            btnIniciarSesion.UseVisualStyleBackColor = true;
            btnIniciarSesion.Click += btnIniciarSesion_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(722, 305);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(140, 50);
            btnCancelar.TabIndex = 2;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(450, 90);
            label1.Name = "label1";
            label1.Size = new Size(72, 25);
            label1.TabIndex = 3;
            label1.Text = "Usuario";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(421, 178);
            label2.Name = "label2";
            label2.Size = new Size(101, 25);
            label2.TabIndex = 4;
            label2.Text = "Contraseña";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logoisp20;
            pictureBox1.InitialImage = (Image)resources.GetObject("pictureBox1.InitialImage");
            pictureBox1.Location = new Point(12, 37);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(380, 330);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // textBoxUser
            // 
            textBoxUser.Location = new Point(554, 84);
            textBoxUser.Name = "textBoxUser";
            textBoxUser.Size = new Size(308, 31);
            textBoxUser.TabIndex = 6;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(554, 175);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '*';
            textBoxPassword.Size = new Size(308, 31);
            textBoxPassword.TabIndex = 7;
            // 
            // checkBoxVerPassword
            // 
            checkBoxVerPassword.AutoSize = true;
            checkBoxVerPassword.Location = new Point(554, 234);
            checkBoxVerPassword.Name = "checkBoxVerPassword";
            checkBoxVerPassword.Size = new Size(157, 29);
            checkBoxVerPassword.TabIndex = 8;
            checkBoxVerPassword.Text = "Ver Contraseña";
            checkBoxVerPassword.UseVisualStyleBackColor = true;
            checkBoxVerPassword.CheckedChanged += checkBoxVerPassword_CheckedChanged;
            // 
            // IniciarSesionView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(921, 409);
            Controls.Add(checkBoxVerPassword);
            Controls.Add(textBoxPassword);
            Controls.Add(textBoxUser);
            Controls.Add(pictureBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCancelar);
            Controls.Add(btnIniciarSesion);
            Name = "IniciarSesionView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Iniciar Sesion";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox checkBox1;
        private Button btnIniciarSesion;
        private Button btnCancelar;
        private Label label1;
        private Label label2;
        private PictureBox pictureBox1;
        private TextBox textBoxUser;
        private TextBox textBoxPassword;
        private CheckBox checkBoxVerPassword;
    }
}