using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
 
using Microsoft.Data.SqlClient; //Tuve que actualizar lo q dice Maxi. antes decía : using System.Data.SqlClient; ahora cambié Miicrosoft.Data.SqlClient;
using System.Net; //Agregamos esta biblioteca para para poder usar la base de datos con conexión externa a una red, o sea, no en mi propia computadora. Hacer esto antes que B:
                      //hacer uso de funcionalidades relacionadas con la red (por ejemplo, descargando datos desde una API, enviando correos electrónicos, o similar). 
    
using dominio;



    namespace negocio
    {
         public class PokemonNegocio  //Cada Clase -que represente una tabla- Va a tener su Clase_de_Negocios con los métodos de acceso a  datos. //Borré el "internal" class ..
        {
            public List<Pokemon> listar()
            {                                                                   //creo una lista tipo public. Dentro pongo un try/catch. en try, todo lo quep ueda fallar.
                List<Pokemon> lista = new List<Pokemon>();

                //B: Las cosas que necesito para conectarme a algún lado -en este orden:

                SqlConnection conexion = new SqlConnection();
                SqlCommand comando = new SqlCommand(); //con este objeto podré realizar acciónes.
                SqlDataReader lector; //con esto obtendré el set de datos que necesito. No le geneo instancia ya que al obtener la lectura se crea la instancia de un objeto.

                try
                {   //acá pongo todo aquello q puede fallar.
                    conexion.ConnectionString = "server=.\\SQLEXPRESS; database=POKEDEX_DB; integrated security=true"; //este comando es una cadena de conexiones.
                                                                                                                       //Luego de "server = " pongo la dire que tengo en la base de datos. Arriba dbotón connect ->
                                                                                                                       //conectar al motor -> se pone la dirección q allí figura. (la barra invertida del medio q sale
                                                                                                                       //roja hay q ponerla doble -es la última q sale-). LA primera parte si es tu pc, podés cambiar
                                                                                                                       //la dirección por " (local) " o directamente " . "   . Luego a dónde me voy a conectar: database = nombre_de_la_db. 
                                                                                                                       //Luego pongo el nombre d ela base de datos y la autentificación: Windows autentication(en la DB) -> integrated security = true. 
                                                                                                                       //Si tuviera usuario propio, pongo false. Luego " ; " user: ccc; pasword: xxx;

                    comando.CommandType = System.Data.CommandType.Text;   //3 tipos: T.Texto: inyecto una sentencia SQL.
                                                                          //T.Procedimiento almacenado, así le piod q ejecute una función q está 
                                                                          //guardada en la base de datos. T. Enlace directo conla tabla, no lo usamos.


                    comando.CommandText = " select Numero, Nombre, P.Descripcion, UrlImagen, E.Descripcion as Tipo, D.Descripcion Debilidad\r\nfrom POKEMONS P, ELEMENTOS E, ELEMENTOS D \r\nwhere E.id = P.IdTipo and D.id = P.IdDebilidad";  //Luego, tengo q pasarle un texto, q será la consulta SQL. Recomiendo escribirla primero en el sql server y luego copiarla al VS comm.
                                                                                                                                                                                                                                               //E.Descripcion as Tipo = a poner un espacio, o sea, saco "as" y dejo un espacio entre una col y otra pero sin poner ",".
                                                                                                                                                                                                                                               //puedo copiar "Select..." y probarlo en MSQL como consulta para corroborar q funcione.
                    comando.Connection = conexion; //realizo la conexión.

                    conexion.Open();
                    lector = comando.ExecuteReader();  //realizo un lectura de esos datos. Me generará una suerte de colección de objetos.

                    while (lector.Read())
                    {
                        //Para leerlos hago un while. El .Read() se fijará si hay lectura. De ser asó, posicionará el puntero en la primera fila y devuelve true.
                        //Luego bajará al otro y así hasta q no haya más. Cada vez q baje reutilizará la variable. Creará una nueva var en el stack de objetos.

                        Pokemon aux = new Pokemon();  //Genero un Pokemón auxiliar y lo empiezo a cargar con los datos del lector de ese registro.
                        aux.Numero = lector.GetInt32(0);  //a Get hay que especificarle q dato va a buscar. El Int32 es el más común, el 16 es short,etc.
                        aux.Nombre = (string)lector["Nombre"]; //hay get string pero también puedo hacer lo de aca. Pongo [] y el nombre de la columna.
                        aux.Descripcion = (string)lector["Descripcion"];
                        aux.UrlImagen = (string)lector["UrlImagen"];
                        aux.Tipo = new Elemento(); //creo un nuevo elemento con este constructor. Asi le asigno a Tipo un elemento contenedor para ejecurar y guardar el dato que pediré abajo.
                        aux.Tipo.Descripcion = (string)lector["Tipo"]; //Al principio, el objeto Tipo no tiene un constructor. Para poder usarlo hago lo de arriba: si no, me dará referencia nula.
                        aux.Debilidad = new Elemento();
                        aux.Debilidad.Descripcion = (string)lector["Tipo"];


                        lista.Add(aux);             // finalmente agrego el Pokemón a la lista.
                    }

                    conexion.Close();            //Cierro la conección.

                    return lista;                       //al final del contenido del try ira el return.
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar los Pokémons", ex);
                }
            }
        }
    }
