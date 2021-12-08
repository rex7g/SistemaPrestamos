using capaNegocios;
using Entidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace capaPresentacion
{
    public partial class form2 : Form
    {
        public form2()
        {
            InitializeComponent();
        }

        N_Prestamos objNego = new N_Prestamos();
        E_Prestamos objEnti = new E_Prestamos();

        private void form2_Load(object sender, EventArgs e)
        {

        }
       
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
            objEnti.nombre = txtNombre.Text;
            objEnti.apellido = txtApellido.Text;
            objEnti.edad = int.Parse(txtEdad.Text);
            objEnti.numeroId = int.Parse(txtNumeroId.Text);
            objEnti.direccion = txtDireccion.Text;
            objEnti.pagoPrestamo = int.Parse(txtPagoPrestamo.Text);//cuotas menzuales
            objEnti.interesPrestamo = 0;

            objEnti.montoPrestamo = int.Parse(txtMontoPrestamo.Text);
                if (objEnti.montoPrestamo <= 200000)
                {
                    objEnti.interesPrestamo = 22;
                }
                else if (objEnti.montoPrestamo <= 400000)
                {
                    objEnti.interesPrestamo = 16;
                }
                else
                {
                    objEnti.interesPrestamo = 14;
                }
                

            objEnti.tiempoPrestamo = int.Parse(txtTiempoPrestamo.Text);



            objEnti.cuotaPrestamo = 0;
        
            objNego.guardarCliente(objEnti.nombre, objEnti.apellido, objEnti.edad, objEnti.numeroId, objEnti.direccion, objEnti.pagoPrestamo, objEnti.interesPrestamo, objEnti.montoPrestamo, objEnti.tiempoPrestamo, objEnti.cuotaPrestamo);
             
            MessageBox.Show("tus datos se guardaron exitosamente");
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                objNego.listarTabla();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           DataTable dt = objNego.listarTabla();
            dataGridView1.DataSource = dt;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
