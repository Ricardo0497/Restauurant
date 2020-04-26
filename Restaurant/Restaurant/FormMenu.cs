using BL.Restaurant;
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
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formLogin = new FormLogin();
            formLogin.ShowDialog();

            if (Program.UsuarioLogueado != null)
            {
                toolStripStatusLabel1.Text = "usuario :" + Program.UsuarioLogueado.Nombre; 
            }

            if(Program.UsuarioLogueado.TipoUsuario == "Usuario de Caja")
            {
                productoToolStripMenuItem.Visible = true;
                diarioToolStripMenuItem.Visible = false;
                semanalToolStripMenuItem.Visible = false;
                mensualToolStripMenuItem.Visible = false;
                facturaToolStripMenuItem.Visible = true;
                agregarToolStripMenuItem.Visible = false;
                reporteDeProductoToolStripMenuItem.Visible = false;
                reporteDeFacturaToolStripMenuItem.Visible = false;
                cambiarToolStripMenuItem.Visible = true;
                eliminarUsuarioToolStripMenuItem.Visible = false;
                administradoresDeUsuariosToolStripMenuItem.Visible = false; 
                loginToolStripMenuItem.Visible = false;
                
            }

            if (Program.UsuarioLogueado.TipoUsuario == "Usuario de Venta")
            {
                productoToolStripMenuItem.Visible = true;
                diarioToolStripMenuItem.Visible = true;
                semanalToolStripMenuItem.Visible = true;
                mensualToolStripMenuItem.Visible = true;
                facturaToolStripMenuItem.Visible = true;
                agregarToolStripMenuItem.Visible = false;
                reporteDeProductoToolStripMenuItem.Visible = true ;
                reporteDeFacturaToolStripMenuItem.Visible = true;
                cambiarToolStripMenuItem.Visible = true;
                eliminarUsuarioToolStripMenuItem.Visible = false;
                administradoresDeUsuariosToolStripMenuItem.Visible = false;
                loginToolStripMenuItem.Visible = false;
            }


            if(Program.UsuarioLogueado .TipoUsuario == "Administrador de Login" )
                {
                productoToolStripMenuItem.Visible = true;
                diarioToolStripMenuItem.Visible = true;
                semanalToolStripMenuItem.Visible = true;
                mensualToolStripMenuItem.Visible = true;
                facturaToolStripMenuItem.Visible = true;
                agregarToolStripMenuItem.Visible = false;
                reporteDeProductoToolStripMenuItem.Visible = true;
                reporteDeFacturaToolStripMenuItem.Visible = true;
                cambiarToolStripMenuItem.Visible = true;
                eliminarUsuarioToolStripMenuItem.Visible = true;
                administradoresDeUsuariosToolStripMenuItem.Visible = true;
                loginToolStripMenuItem.Visible = true;
            }





        }

        private void diarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formDiario = new FormDiario ();
           
            formDiario.Show();
        }

        private void semanalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formDiario = new FormDiario();
            
            formDiario.Show();

        }

        private void mensualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formMensual = new FormMensual();

            formMensual.Show();  
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formUsuario = new FormUsuario();
            
            formUsuario.Show();
        }

        private void contrasenaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formContrasena = new FormContrasena();
           
            formContrasena.Show();
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formAgregar = new FormAgregar();
           
            formAgregar.Show();
        }

        private void eliminarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formEliminar = new FormEliminar();
            
            formEliminar.Show();
        }

        private void facturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formFactura = new FormFactura();
         //   formFactura.MdiParent = this; 
            formFactura.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Hola");

            MessageBox.Show("Bienvenidos a Nuestro Sistema");

            var formLogin = new FormLogin();
            formLogin.ShowDialog();
        }

        private void productoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formProducto = new FormProducto();
            formProducto.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var formComidas = new FormComidas();

            formComidas.Show();
        }

        private void reporteDeProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formreporteProductos = new FormReporteProducto();
     //     formreporteProductos.MdiParent = this;
            formreporteProductos.Show();
        }

        private void reporteDeFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formreporteFacturas = new FormReporteFacturas();
            //     formreporteProductos.MdiParent = this;
            formreporteFacturas.Show();
        }

        private void administradoresDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var formAdminUsuarios = new FormAdminUsuario();

            formAdminUsuarios.Show();
            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formularioClientes = new FormularioClientes2();
            formularioClientes.ShowDialog();
        }
    }
}
