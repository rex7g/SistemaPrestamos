using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Entidad;
using System.Data.SqlClient;
using System.Data;

namespace capaDatos
{
    public class D_Prestamos
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString);

        SqlCommand comando;


        //Metodo para guardar(agregar) todos los datos ingresados(del cliente) por primera vez
        public void guardar(string nombre, string apellido, int edad, int numeroId, string direccion, int pagoPrestamo, int interesPrestamo, int montoPrestamo, int tiempoPrestamo, int cuotaPrestamo)
        {
            con.Open();
            string lineaComandoSql = $"insert into Prestamos values('{nombre}','{apellido}',{edad},{numeroId},'{direccion}',{pagoPrestamo},{interesPrestamo},{montoPrestamo},{tiempoPrestamo},{cuotaPrestamo})";
            comando = new SqlCommand(lineaComandoSql,con);
            comando.ExecuteNonQuery();
            con.Close();
        }


        public void actualizar(int id,string nombre, string apellido, int edad, string direccion)
        {
            con.Open();
            string lineaComandoSql = $"update Prestamos set nombre = '{nombre}', apellido = '{apellido}', edad = {edad}, direccion = '{direccion}' where id = {id}";
            comando = new SqlCommand(lineaComandoSql, con);
            comando.ExecuteNonQuery();
            con.Close();
        }

        public void pagarCuota(int id, int montoPrestamo, int pagoPrestamo, int cuotaPrestamo)
        {
          /*
            con.Open();
            string lineaComandoSql = $"update Prestamos set montoPrestamo = {montoPrestamo}, pagoPrestamo = {pagoPrestamo}, cuotaPrestamo = {cuotaPrestamo} where id = {id}";
            comando = new SqlCommand(lineaComandoSql, con);
            comando.ExecuteNonQuery();
            con.Close();
          */
        }

        public void borrar(int id)
        {
            con.Open();
            string lineaComandoSql = $"delete from Prestamos where id = {id}";
            comando = new SqlCommand(lineaComandoSql, con);
            comando.ExecuteNonQuery();
            con.Close();
        }

        
        //Metodo aun no funciona
        public void traer(int id, int montoPrestamo, string nombre, string apellido)
        {
            E_Prestamos objEnti = new E_Prestamos();
            objEnti.montoPrestamo = objEnti.montoPrestamo - objEnti.pagoPrestamo;
            
             con.Open();
             string lineaComandoSql = $"select montoPrestamo,nombre,apellido from Prestamos where id = {id}";
             comando = new SqlCommand(lineaComandoSql, con);
             SqlDataReader traerRegistro = comando.ExecuteReader();
             if (traerRegistro.Read())
             {
                 montoPrestamo = (int)traerRegistro["montoPrestamo"];
                 nombre = traerRegistro["nombre"].ToString();
                 apellido = traerRegistro["apellido"].ToString();
             }
             else
             {
                 System.Console.WriteLine("No existe el registro introducido");
             }
             con.Close();
            
        }


        //Retorna toda la tabla de base de datos prestamos
        public DataTable listarTabla()
        {
            comando = new SqlCommand("listarNombres", con);
            comando.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adaptar = new SqlDataAdapter(comando);
            DataTable dt = new DataTable();
            adaptar.Fill(dt);
            return dt;
            
        }


    }
}
