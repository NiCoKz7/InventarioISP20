using Firebase.Auth;
using Firebase.Auth.Providers;
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
    public partial class IniciarSesionView : Form
    {
        FirebaseAuthClient? firabeseAuthClient;
        int intentos = 0;
        public IniciarSesionView()
        {
            InitializeComponent();
            ConfiguracionFirabeseAuthClient();
        }

        private void ConfiguracionFirabeseAuthClient()
        {
            var configAuthClient = new FirebaseAuthConfig
            {
                ApiKey = "AIzaSyCjQej4jL27hQXqRcHc_xLwV0CYsxcFjlk",
                AuthDomain = "inventarioisp20nico.firebaseapp.com",
                Providers = new FirebaseAuthProvider[]
                {
                    new EmailProvider()
                }
            };
            firabeseAuthClient = new FirebaseAuthClient(configAuthClient);
        }

        private async void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                var user = await firabeseAuthClient!.SignInWithEmailAndPasswordAsync(textBoxUser.Text, textBoxPassword.Text);
                if (user == null)
                {
                    MessageBox.Show("Usuario o contraseña incorrectos");
                    intentos++;
                    return;
                }
                MessageBox.Show("Inicio de sesión exitoso");
                this.Hide();
                var mainView = new MenuPrincipalView();
                mainView.ShowDialog();
                this.Close();
            }
            catch (FirebaseAuthException error)
            {

                MessageBox.Show("Error al iniciar sesión: " + error.Reason);
                intentos++;
            }
            if (intentos >= 3)
            {
                MessageBox.Show("Demasiados intentos fallidos. La aplicación se cerrará.");
                Application.Exit();
            }
        }

        private void checkBoxVerPassword_CheckedChanged(object sender, EventArgs e)
        {
            textBoxPassword.PasswordChar = checkBoxVerPassword.Checked ? '\0' : '*';
        }
    }
}