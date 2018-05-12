using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Listas_enlazadas_dobles
{
    public partial class Form1 : Form
    {
        Inventario prod = new Inventario();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(txtCodigo.Text); 
            Producto nuevo;
            nuevo = new Producto(codigo, txtNombre.Text, txtDesc.Text, txtCantidad.Text,
                txtCosto.Text);
            prod.agregar(nuevo);
            limpiarTodasTxt();
            txtLista.Text = "Producto Agregado------";
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            txtLista.Clear();
            txtLista.Text += prod.listar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            txtLista.Clear();
            int codigo = Convert.ToInt32(txtCodigo.Text);
            txtLista.Text += prod.buscar(codigo);
        }



        private void limpiarTodasTxt()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtDesc.Clear();
            txtCantidad.Clear();
            txtCosto.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(txtCodigo.Text);
            txtLista.Clear();
            prod.eliminar(codigo);
            txtLista.Text = "Producto Eliminado-----";
        }

        private void btnElimiPrimero_Click(object sender, EventArgs e)
        {
            txtLista.Clear();
            prod.eliminarPrimero();
            txtLista.Text = "Producto #1 Eliminado-----";
        }

        private void btnElimiUltimo_Click(object sender, EventArgs e)
        {
            txtLista.Clear();
            prod.eliminarUltimo();
            txtLista.Text = "Ultimo producto eliminado----";
        }

        private void btnInverVista_Click(object sender, EventArgs e)
        {
            txtLista.Text = prod.invertir();
        }
    }
}
