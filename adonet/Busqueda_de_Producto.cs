﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace adonet
{
    public partial class busqueda_productos : Form
    {
        Conexion_db objConexion = new Conexion_db();
        internal int _idProducto;

        public busqueda_productos()
        {
            InitializeComponent();
        }

        private void grdBusquedaClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void busqueda_productos_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'sistemadebicirepuestosDataSet3.productos' Puede moverla o quitarla según sea necesario.
            this.productosTableAdapter.Fill(this.sistemadebicirepuestosDataSet3.productos);
            grdBusquedaProducto.DataSource =
               objConexion.obtener_datos().Tables["productos"].DefaultView;
        }
        void filtrar_datos(String valor)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = grdBusquedaProducto.DataSource;
            bs.Filter = "nombre like '%" + valor + "%'";
            grdBusquedaProducto.DataSource = bs;
        }

        private void btnseleccionar_Click(object sender, EventArgs e)
        {
            if (grdBusquedaProducto.RowCount > 0)
            {
                _idProducto = int.Parse(grdBusquedaProducto.CurrentRow.Cells[0].Value.ToString());
                Close();

            }
            else
            {
                MessageBox.Show("NO hay datos que seleccionar", "Busqueda de Producto",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            filtrar_datos(txtbuscar.Text);
        }
    }

}








