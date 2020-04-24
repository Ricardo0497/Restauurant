using BL.Restaurant;
using Restaurant;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant
{
    public partial class FormLogin : Form
    {

        RestaurantSeguridadBL  _seguridad;

        public FormLogin()
        {
            InitializeComponent();

            _seguridad = new RestaurantSeguridadBL ();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("HOlaMundo"); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {


            string Usuario;
            string Contrasena;

            Usuario = textBox1.Text;
            Contrasena = textBox2.Text;

            button1.Enabled = false;
            button1.Text = "Verificando Usuario...";
            Application.DoEvents();

            var usuarioDB = _seguridad.Autorizar (Usuario, Contrasena);

            if(usuarioDB != null)
            {
                Program.UsuarioLogueado = usuarioDB;
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario o Contrasena Incorrecta");
            }
            button1.Enabled = true;
            button1.Text = "Aceptar";
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter) && !string.IsNullOrEmpty (textBox1 .Text))
                {
                textBox2.Focus(); 
            } 

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
        if(e.KeyChar == Convert.ToChar(Keys.Enter) && !string.IsNullOrEmpty (textBox2 .Text))
                {
                button1.PerformClick();
            }
        }
    }
}
