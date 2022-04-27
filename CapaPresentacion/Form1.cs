using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        CN_Productos objectoCN = new CN_Productos();
        private string idproducto=null;
        private bool editar = false;
         
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mostrarProducto();
        }

        private void mostrarProducto()
        {
            CN_Productos objecto = new CN_Productos();
            dataGridView1.DataSource = objecto.mostrarproducto();
        }

        private void btnGuadar_Click(object sender, EventArgs e)
        {
            if (editar == false)
            {
                try
                {
                    objectoCN.inserctarProducto(txtNombre.Text, txtDespricion.Text, txtMarca.Text, txtPrecio.Text, txtStock.Text);
                    MessageBox.Show("Se inserto correctamente");
                    mostrarProducto();
                    limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo insertar los datos" + ex);
                }
            }
            if(editar==true)
            {
                try
                {
                    objectoCN.editarProducto(txtNombre.Text, txtDespricion.Text, txtMarca.Text, txtPrecio.Text, txtStock.Text,idproducto);
                    MessageBox.Show("Se edito correctamente");
                    mostrarProducto();
                    limpiar();
                    editar = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo editar los datos" + ex);
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                editar = true;
                txtNombre.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                txtDespricion.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
                txtMarca.Text = dataGridView1.CurrentRow.Cells["Marca"].Value.ToString();
                txtPrecio.Text = dataGridView1.CurrentRow.Cells["Precio"].Value.ToString();
                txtStock.Text = dataGridView1.CurrentRow.Cells["Stock"].Value.ToString();
                idproducto = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
            }
            else
                MessageBox.Show("Seleccione la fila a editar");
        }

        private void limpiar()
        {
            txtDespricion.Clear();
            txtMarca.Clear();
            txtNombre.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idproducto = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                objectoCN.eliminarProducto(idproducto);
                MessageBox.Show("eliminado correctament");
                mostrarProducto();
            }
            else
                MessageBox.Show("Seleccione la fila a editar");

        }
    }
}
