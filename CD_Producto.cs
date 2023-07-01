using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDeDatos
{
    public class CD_Producto
    {
        private CD_Conexion conexion= new CD_Conexion();
        SqlDataReader leer;
        DataTable tabla=new DataTable ();
        SqlCommand comando = new SqlCommand();

        public DataTable Mostrar()
        {
            comando.Connection=conexion.AbrirConexion();
            comando.CommandText = "MostrarTabla";
            leer= comando.ExecuteReader();
            tabla.Load(leer);
            return tabla;
        }
        public void Insertar(string nombre,string descripcion,Double Precio,int Stock )
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText= "InsertarProducto";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre",nombre);
            comando.Parameters.AddWithValue("@descripcion", descripcion);
            comando.Parameters.AddWithValue("@Precio", Precio);
            comando.Parameters.AddWithValue("@Stock", Stock);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();

        }
        public void Editar(string nombre, string Descripcion, Double Precio, int Stock,int id)
        {
            
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ActualizarProducto";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@Descripcion", Descripcion);
            comando.Parameters.AddWithValue("@Precio", Precio);
            comando.Parameters.AddWithValue("@Stock", Stock);
            comando.Parameters.AddWithValue("@Id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
        public void Eliminar(int id)
        {
            comando.Connection=conexion.AbrirConexion();
            comando.CommandText = "EliminarProducto";
            comando.CommandType = CommandType.StoredProcedure;
           
            comando.Parameters.AddWithValue("@IdProd", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }



    }
}
