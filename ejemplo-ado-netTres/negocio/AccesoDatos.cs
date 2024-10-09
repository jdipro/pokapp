using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient; //System.Data,SqlClient, no ta.


namespace negocio
{
    public class AccesoDatos
    {
        private SqlConnection conexion; //cada uno de estos objetos deben tener sus propiedades.
        private SqlCommand comando;
        private SqlDataReader lector; //para leer este lector privado tengo q hacer un objeto público: abajo.
        public SqlDataReader Lector
        {
            get { return lector; }
        }
        public AccesoDatos() { 
        
            conexion = new SqlConnection("server=ANGA-PC\\SQLEXPRESS; database=POKEDEX_DB; integrated security=true");
            comando = new SqlCommand();
        }

        public void setearConuslta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw new Exception("Error en el acceso a datos", ex); 
            }
        }
        public void cerrarConexion()
        {
            if (lector != null)
            
                lector.Close();
            conexion.Close();
        
        }
    }
}
