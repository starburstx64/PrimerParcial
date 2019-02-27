using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WindowsFormsCRUDMVC.DAO;
using WindowsFormsCRUDMVC.DTO;

namespace WindowsFormsCRUDMVC
{
    public partial class Form1 : Form
    {
        private AccionesDAO dAO;

        public Form1()
        {
            InitializeComponent();
            dAO = new AccionesDAO();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'primer_parcialDataSet.acciones' Puede moverla o quitarla según sea necesario.
            this.accionesTableAdapter.Fill(this.primer_parcialDataSet.acciones);
            UpdateDataGridView();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(TxtId.Text);
                string fecha = TxtFecha.Text;
                float precio = float.Parse(TxtPrecio.Text);
                float dinero = float.Parse(TxtDinero.Text);
                int acciones = int.Parse(TxtAcciones.Text);

                dAO.Insert(new Acciones(id, fecha, precio, dinero, acciones));
                ClearTextBoxes();

                MessageBox.Show("Insertado Correctamente");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(TxtId.Text);
                string fecha = TxtFecha.Text;
                float precio = float.Parse(TxtPrecio.Text);
                float dinero = float.Parse(TxtDinero.Text);
                int acciones = int.Parse(TxtAcciones.Text);

                dAO.Update(new Acciones(id, fecha, precio, dinero, acciones));
                ClearTextBoxes();

                MessageBox.Show("Editado Correctamente");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(TxtId.Text);

                dAO.Delete(id);
                ClearTextBoxes();
                MessageBox.Show("Eliminado Correctamente");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearTextBoxes()
        {
            TxtAcciones.Text = "";
            TxtDinero.Text = "";
            TxtFecha.Text = "";
            TxtId.Text = "";
            TxtPrecio.Text = "";

            UpdateDataGridView();
        }

        private void UpdateDataGridView()
        {
            try
            {
                DataGridView1.DataSource = dAO.SelectAll().Tables[0];
                DataGridView1.Refresh();
                DataGridView1.Update();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
