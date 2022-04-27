using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_Productos
    {
        private CD_conexion conexion = new CD_conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable mostrar()
        {
            comando.Connection = conexion.abrirconexion();
            comando.CommandText = "MostrarProductos";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.cerrarconexion();
            return tabla;
        }

        public void inserctar(string nombre, string desc, string marca, double precio, int stock)
        {

            comando.Connection = conexion.abrirconexion();
            comando.CommandText = "insertarProducto";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@desc", desc);
            comando.Parameters.AddWithValue("@marca", marca);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@stock", stock);

            comando.ExecuteNonQuery(); 

            comando.Parameters.Clear();
        }

        public void editar(string nombre, string desc, string marca, double precio, int stock, int id)
        {

            comando.Connection = conexion.abrirconexion();
            comando.CommandText = "editarProductos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@desc", desc);
            comando.Parameters.AddWithValue("@marca", marca);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@stock", stock);
            comando.Parameters.AddWithValue("@id", id);

            comando.ExecuteNonQuery(); 

            comando.Parameters.Clear();
        }

        public void eliminar(int id)
        {
            comando.Connection = conexion.abrirconexion();
            comando.CommandText = "eliminarproducto";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@idpro", id);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }
    }
}
