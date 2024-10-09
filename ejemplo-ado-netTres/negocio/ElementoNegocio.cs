using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio; //agrego dominio.

namespace negocio
{
    public class ElementoNegocio //la hago publica.
    {
        public List<Elemento> listar()
        {
            List<Elemento> lista = new List<Elemento>();
            AccesoDatos datos = new AccesoDatos(); //nace un objeto que tiene un lector que tiene un comnado que tiene una conexion. El comando tiene instancia en la conexion. Esta tiene una instancia y una cadena de configuración configurada.
            try
            {
                datos.setearConuslta("select Id, Descripcion from ELEMENTOS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Elemento aux = new Elemento();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripción"];

                    lista.Add(aux);


                }


                return lista;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al listar los Pokémons", ex); ;
            }
            finally
            {
                datos.cerrarConexion();
            }


        }



    }
}
