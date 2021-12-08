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
    public partial class Modificar : Form
    {
        public Modificar()
        {
            InitializeComponent();
        }

        N_Prestamos objNego = new N_Prestamos();
        E_Prestamos objEnti = new E_Prestamos();

        private void Modificar_Load(object sender, EventArgs e)
        {
            DataTable dt = objNego.listarTabla();
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            objNego.listarTabla();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                objEnti.id = int.Parse(txtId.Text);
                objEnti.nombre = txtNombre.Text;
                objEnti.apellido = txtApellido.Text;
                objEnti.edad = int.Parse(txtEdad.Text);
                objEnti.direccion = txtDireccion.Text;


                objNego.actualizarCliente(objEnti.id, objEnti.nombre, objEnti.apellido, objEnti.edad, objEnti.direccion);

                MessageBox.Show("tus datos se actualizaron exitosamente");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }

            DataTable dt = objNego.listarTabla();
            dataGridView1.DataSource = dt;
        }
    }
}
