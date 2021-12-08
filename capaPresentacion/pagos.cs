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
using Microsoft.VisualBasic;
using capaDatos;
using System.Data.SqlClient;
using System.Configuration;

namespace capaPresentacion
{
    public partial class pagos : Form
    {
        public pagos()
        {
            InitializeComponent();
        }

        N_Prestamos objNego = new N_Prestamos();
        E_Prestamos objEnti = new E_Prestamos();
        D_Prestamos objDatos = new D_Prestamos();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString);

        SqlCommand comando;

        private void pagos_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         
        }
        //boton que realiza pago
        private void button1_Click(object sender, EventArgs e)
        {
            string entradaPago = Interaction.InputBox("");

            int idp = int.Parse(txtId.Text);

            int pago = int.Parse(entradaPago);
            int monto = int.Parse(txtMonto.Text);

            int totalMonto;

            if (pago <= monto)
            {
                totalMonto = (monto - pago);
                objEnti.montoPrestamo = totalMonto;
            }
            else
            {
                MessageBox.Show("No puede pagar mas de lo que debe");
            }
             //contadores para #de cuotas y sumatoria de pagos realizados hasta compararse con el monto dle prestamo
            objEnti.cuotaPrestamo += 1;
            objEnti.pagoPrestamo += pago;


            con.Open();
            string lineaComandoSql = $"update Prestamos set montoPrestamo = {objEnti.montoPrestamo}, pagoPrestamo = {objEnti.pagoPrestamo}, cuotaPrestamo = {objEnti.cuotaPrestamo} where id = {idp}";
            comando = new SqlCommand(lineaComandoSql, con);
            comando.ExecuteNonQuery();
            con.Close();

            
           // objNego.pagarCuotaPrestamo(objEnti.id, objEnti.montoPrestamo, objEnti.pagoPrestamo, objEnti.cuotaPrestamo);

        }

        //Metodo para traer datos especificos de la base de datos y obtener el monto del prestamo y asi descontarlo mediante pagos
        public void btnTraer_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtId.Text);

                con.Open();
                string lineaComandoSql = $"select montoPrestamo,nombre,apellido,pagoPrestamo,cuotaPrestamo from Prestamos where id = {id}";
                comando = new SqlCommand(lineaComandoSql, con);
                SqlDataReader traerRegistro = comando.ExecuteReader();
                if (traerRegistro.Read())
                {
                    txtMonto.Text = traerRegistro["montoPrestamo"].ToString();
                    txtNombre.Text = traerRegistro["nombre"].ToString();
                    txtApellido.Text = traerRegistro["apellido"].ToString();
                    objEnti.pagoPrestamo = (int)traerRegistro["pagoPrestamo"];
                    objEnti.cuotaPrestamo = (int)traerRegistro["cuotaPrestamo"];

                    txtCuotaPrestamo.Text = objEnti.cuotaPrestamo.ToString();

                    MessageBox.Show("Datos obtenidos");
                }
                else
                {
                    MessageBox.Show("tus datos han sido obtenidos");
                }
                con.Close();
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.Message);
            }

             //objNego.traerDatosPrestamo(objEnti.id, objEnti.montoPrestamo, objEnti.nombre, objEnti.apellido);
            

        }
    }
}
