using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BL.Restaurant
{
    public partial class FormAdminUsuario : Form
    {
        RestaurantSeguridadBL _seguridadBL;

        public FormAdminUsuario()
        {
            InitializeComponent();

            _seguridadBL = new RestaurantSeguridadBL(); // Inicializamos Variable

            usuarioBindingSource.DataSource = _seguridadBL.ObtenerUsuarios();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            _seguridadBL.AgregarUsuario();
            usuarioBindingSource.MoveLast();

            DeshabilitarHabilitarBotones(false);
        }

        private void usuarioBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            usuarioBindingSource.EndEdit();
            var usuario = (Usuario)usuarioBindingSource.Current;

            var resultado = _seguridadBL.GuardarUsuario(usuario);
            if (resultado.Exitoso == true)
            {
                usuarioBindingSource.ResetBindings(false);
                DeshabilitarHabilitarBotones(true);
                MessageBox.Show("Usuario guardado con exito");
            }
            else
            {
                MessageBox.Show(resultado.Mensaje);
            }
        }

        private void DeshabilitarHabilitarBotones(bool valor)
        {
            bindingNavigatorMoveFirstItem.Enabled = valor;
            bindingNavigatorMoveLastItem.Enabled = valor;
            bindingNavigatorMovePreviousItem.Enabled = valor;
            bindingNavigatorMoveNextItem.Enabled = valor;
            bindingNavigatorPositionItem.Enabled = valor;

            bindingNavigatorAddNewItem.Enabled = valor;
            bindingNavigatorDeleteItem.Enabled = valor;
            //       toolStripButtonCancelar.Visible = !valor;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (idTextBox.Text != "")
            {
                var resultado = MessageBox.Show("Desea eliminar este registro?", "Eliminar", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    var id = Convert.ToInt32(idTextBox.Text);
                    Eliminar(id);
                }
            }
        }

        private void Eliminar(int id)
        {
            var resultado = _seguridadBL.EliminarUsuario(id);

            if (resultado == true)
            {
                usuarioBindingSource.ResetBindings(false);
            }
            else
            {
                MessageBox.Show("Error al eliminar el usuario, intente de nuevo");
            }
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            _seguridadBL.CancelarCambios();
            DeshabilitarHabilitarBotones(true);
        }
    }
}







