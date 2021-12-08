using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidad;
using capaNegocios;

namespace capaPresentacion
{
    public partial class borrar : Form
    {
        public borrar()
        {
            InitializeComponent();
        }

        N_Prestamos objNego = new N_Prestamos();
        E_Prestamos objEnti = new E_Prestamos();


        private void borrar_Load(object sender, EventArgs e)
        {
            DataTable dt = objNego.listarTabla();
            dataGridView1.DataSource = dt;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                objEnti.id = int.Parse(txtId.Text);
      
                objNego.borrarCliente(objEnti.id);

                MessageBox.Show("Se han borrado exitosamente");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }

            DataTable dt = objNego.listarTabla();
            dataGridView1.DataSource = dt;
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            objNego.listarTabla();
        }
    }
}
