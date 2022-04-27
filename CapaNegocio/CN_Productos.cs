using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
     public class CN_Productos
    {
        private CD_Productos objetoCD = new CD_Productos();

        public DataTable mostrarproducto()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.mostrar();
            return tabla;
        }

        public void inserctarProducto(string nombre,string desc,string marca,string precio,string stock)
        {
            objetoCD.inserctar(nombre, desc, marca,Convert.ToDouble(precio),Convert.ToInt32(stock));
        }

        public void editarProducto(string nombre, string desc, string marca, string precio, string stock,string id)
        {
            objetoCD.editar(nombre, desc, marca, Convert.ToDouble(precio), Convert.ToInt32(stock),Convert.ToInt32(id));
        }

        public void eliminarProducto(string id)
        {
            objetoCD.eliminar(Convert.ToInt32(id));
        }
    }
}
