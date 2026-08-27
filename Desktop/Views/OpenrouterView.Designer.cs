namespace Desktop.Views
{
    partial class OpenrouterView
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
            txtPregunta = new TextBox();
            txtRto = new TextBox();
            btnEnviar = new FontAwesome.Sharp.IconButton();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // txtPregunta
            // 
            txtPregunta.Location = new Point(45, 73);
            txtPregunta.Name = "txtPregunta";
            txtPregunta.Size = new Size(551, 31);
            txtPregunta.TabIndex = 0;
            // 
            // txtRto
            // 
            txtRto.Location = new Point(45, 194);
            txtRto.Multiline = true;
            txtRto.Name = "txtRto";
            txtRto.Size = new Size(551, 219);
            txtRto.TabIndex = 1;
            // 
            // btnEnviar
            // 
            btnEnviar.IconChar = FontAwesome.Sharp.IconChar.None;
            btnEnviar.IconColor = Color.Black;
            btnEnviar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnEnviar.Location = new Point(628, 71);
            btnEnviar.Name = "btnEnviar";
            btnEnviar.Size = new Size(112, 34);
            btnEnviar.TabIndex = 2;
            btnEnviar.Text = "Enviar";
            btnEnviar.UseVisualStyleBackColor = true;
            btnEnviar.Click += btnEnviar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(45, 45);
            label1.Name = "label1";
            label1.Size = new Size(83, 25);
            label1.TabIndex = 3;
            label1.Text = "Pregunta";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(45, 166);
            label2.Name = "label2";
            label2.Size = new Size(92, 25);
            label2.TabIndex = 4;
            label2.Text = "Respuesta";
            // 
            // OpenrouterView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnEnviar);
            Controls.Add(txtRto);
            Controls.Add(txtPregunta);
            Name = "OpenrouterView";
            Text = "OpenrouterView";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtPregunta;
        private TextBox txtRto;
        private FontAwesome.Sharp.IconButton btnEnviar;
        private Label label1;
        private Label label2;
    }
}