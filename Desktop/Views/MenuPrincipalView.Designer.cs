namespace Desktop.Views
{
    partial class MenuPrincipalView
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            BtnWelcome = new FontAwesome.Sharp.IconButton();
            menuStrip1 = new MenuStrip();
            iconMenuItem1 = new FontAwesome.Sharp.IconMenuItem();
            SubMenuArticulos = new FontAwesome.Sharp.IconMenuItem();
            SubMenuCategorias = new FontAwesome.Sharp.IconMenuItem();
            SubMenuPrestamos = new FontAwesome.Sharp.IconMenuItem();
            SubMenuUbicaciones = new FontAwesome.Sharp.IconMenuItem();
            iconMenuItem2 = new FontAwesome.Sharp.IconMenuItem();
            salirDelSistema = new FontAwesome.Sharp.IconMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // BtnWelcome
            // 
            BtnWelcome.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            BtnWelcome.BackColor = SystemColors.ActiveCaption;
            BtnWelcome.IconChar = FontAwesome.Sharp.IconChar.Users;
            BtnWelcome.IconColor = Color.Black;
            BtnWelcome.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnWelcome.ImageAlign = ContentAlignment.MiddleLeft;
            BtnWelcome.Location = new Point(12, 389);
            BtnWelcome.Name = "BtnWelcome";
            BtnWelcome.Size = new Size(172, 62);
            BtnWelcome.TabIndex = 0;
            BtnWelcome.Text = "Saludo";
            BtnWelcome.UseVisualStyleBackColor = false;
            BtnWelcome.Click += BtnWelcome_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { iconMenuItem1, iconMenuItem2 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 33);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // iconMenuItem1
            // 
            iconMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { SubMenuArticulos, SubMenuCategorias, SubMenuPrestamos, SubMenuUbicaciones });
            iconMenuItem1.IconChar = FontAwesome.Sharp.IconChar.House;
            iconMenuItem1.IconColor = Color.Black;
            iconMenuItem1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconMenuItem1.Name = "iconMenuItem1";
            iconMenuItem1.Size = new Size(118, 29);
            iconMenuItem1.Text = "Principal";
            // 
            // SubMenuArticulos
            // 
            SubMenuArticulos.IconChar = FontAwesome.Sharp.IconChar.Opera;
            SubMenuArticulos.IconColor = Color.Black;
            SubMenuArticulos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            SubMenuArticulos.Name = "SubMenuArticulos";
            SubMenuArticulos.Size = new Size(208, 34);
            SubMenuArticulos.Text = "Articulos";
            SubMenuArticulos.Click += SubMenuArticulos_Click;
            // 
            // SubMenuCategorias
            // 
            SubMenuCategorias.IconChar = FontAwesome.Sharp.IconChar.Memory;
            SubMenuCategorias.IconColor = Color.Black;
            SubMenuCategorias.IconFont = FontAwesome.Sharp.IconFont.Auto;
            SubMenuCategorias.Name = "SubMenuCategorias";
            SubMenuCategorias.Size = new Size(208, 34);
            SubMenuCategorias.Text = "Categorías";
            SubMenuCategorias.Click += SubMenuCategorias_Click;
            // 
            // SubMenuPrestamos
            // 
            SubMenuPrestamos.IconChar = FontAwesome.Sharp.IconChar.PepperHot;
            SubMenuPrestamos.IconColor = Color.Black;
            SubMenuPrestamos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            SubMenuPrestamos.Name = "SubMenuPrestamos";
            SubMenuPrestamos.Size = new Size(208, 34);
            SubMenuPrestamos.Text = "Prestamos";
            // 
            // SubMenuUbicaciones
            // 
            SubMenuUbicaciones.IconChar = FontAwesome.Sharp.IconChar.U;
            SubMenuUbicaciones.IconColor = Color.Black;
            SubMenuUbicaciones.IconFont = FontAwesome.Sharp.IconFont.Auto;
            SubMenuUbicaciones.Name = "SubMenuUbicaciones";
            SubMenuUbicaciones.Size = new Size(208, 34);
            SubMenuUbicaciones.Text = "Ubicaciones";
            // 
            // iconMenuItem2
            // 
            iconMenuItem2.DropDownItems.AddRange(new ToolStripItem[] { salirDelSistema });
            iconMenuItem2.IconChar = FontAwesome.Sharp.IconChar.DesktopAlt;
            iconMenuItem2.IconColor = Color.Black;
            iconMenuItem2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconMenuItem2.Name = "iconMenuItem2";
            iconMenuItem2.Size = new Size(85, 29);
            iconMenuItem2.Text = "Salir";
            // 
            // salirDelSistema
            // 
            salirDelSistema.IconChar = FontAwesome.Sharp.IconChar.Unlock;
            salirDelSistema.IconColor = Color.Black;
            salirDelSistema.IconFont = FontAwesome.Sharp.IconFont.Auto;
            salirDelSistema.Name = "salirDelSistema";
            salirDelSistema.Size = new Size(241, 34);
            salirDelSistema.Text = "Salir del sistema";
            salirDelSistema.Click += salirDelSistema_Click;
            // 
            // MenuPrincipalView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BtnWelcome);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "MenuPrincipalView";
            Text = "Sistema de inventario ISP20 - 2° año TSDS";
            WindowState = FormWindowState.Maximized;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FontAwesome.Sharp.IconButton BtnWelcome;
        private MenuStrip menuStrip1;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem1;
        private FontAwesome.Sharp.IconMenuItem SubMenuArticulos;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem2;
        private FontAwesome.Sharp.IconMenuItem salirDelSistema;
        private FontAwesome.Sharp.IconMenuItem SubMenuCategorias;
        private FontAwesome.Sharp.IconMenuItem SubMenuPrestamos;
        private FontAwesome.Sharp.IconMenuItem SubMenuUbicaciones;
    }
}
