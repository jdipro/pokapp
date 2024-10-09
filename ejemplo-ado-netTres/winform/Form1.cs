using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;




namespace winform
{
    public partial class frmPokemonsLoad : Form
    {

        private List<Pokemon> listaPokemons; //var de atributo.


      


        private void form1(object sender, EventArgs e)
        {


            PokemonNegocio negocio = new PokemonNegocio();  //genero nuev instancia llamada negocio al loader
            listaPokemons = negocio.listar(); //Si bien me funcionaba sin hacer la listaPokemons, de esta nueva forma me permite agregar más cosas.
            dgvPokemons.DataSource = listaPokemons; //Le  asigno  al DGV la búsqueda de datos y le asigno la lista correspondiente.
                                                    //pictureBoxPokemon.Load(listaPokemons[0].UrlImagen); //pbPokemon, recibe un string url. El url del primero pokemon de la lista (arranca en 0 como un vector).
                                                    //en las propiedades del picture box, side mode es la del tamaño de la imagen -> strechimage (ajustar).
                                                    //Luego, voy a la grilla -no la imagen- y con el botón del rayito en la zona de propiedades busco el evento que me puede servir para pasar al pokemon de abajo y lo cargue.

            dgvPokemons.Columns["UrlImagen"].Visible = false; //con esto la columna UrlImagen no se verá en el cuadro ya que quiero la imagen y no la columna con el link. Puedo poner el nombre o el número de índice.
            cargarImage(listaPokemons[0].UrlImagen);//luego de agregar p v cargarImagen, modifico el método  dvgPokemons_Selectionchanged() y Pokemon negocio (en ambos comenté lo viejo).
        }

        private void dgvPokemons_SelectionChanged(object sender, EventArgs e)
        {
            Pokemon seleccionado = (Pokemon)dgvPokemons.CurrentRow.DataBoundItem; //databoun devuelve un elemento tipo objecjt. Como sé q va a ser eso. Creo una var del tipo Pokemon y lo guardo dentro.
                                                                                  //pictureBoxPokemon.Load(seleccionado.UrlImagen); //carga la imagen  que guardé arriba en el pictureBox para que se muestr por pantalla.
                                                                                  //Pero si la dejo acá, se compllica con la actualizacion de la db, ya que no se enterará y me romperá todo. Para esto haremos un nuevo metodo privado.
            cargarImage(seleccionado.UrlImagen);




        }

        private void cargarImage(string imagen)
        {
            try
            {
                pictureBoxPokemon.Load(imagen);
            }
            catch (Exception ex)
            {

                pictureBoxPokemon.Load("data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAOEAAADhCAMAAAAJbSJIAAAAWlBMVEXv8fNod4f19vhkdIRcbX52g5KPmqX29/iYoq3l6OuCj5vd4eTr7fBfcIFaa33M0dbBx82SnKe7wchtfIt8iZejq7TU2N2Ik6CwuL/Gy9Gqsrqbpa/P1NmhqrNz0egRAAADBklEQVR4nO3c63KqMBRAYUiwwUvEete27/+ax1tVAqhwEtnprO+XM62Oyw2CGTFJAAAAAAAAAAAAAAAAAAAAAAAAAAAAAJe6Mb5vqL7jjsws/wgln/dddzBZZjocuxj2HaiWNg1JL/oO3GVBA9PUzvvdF80q7AgPQ/zot1DlOnThyFBIIYWvFtrMK3mFdj30aWzFFWZjr+/qE4mFXh+YwrehsDMK34bCzmIoVEad1nC6PbD8QpXMNwOdDvKi2xMUX2jm2h7/onU2WHcZo/RCld8WN3TWZR1CeKH6LK1tTGftE2UXqpmzPGXbLwnKLkzcT8X6s/UQRReqWWX9LWs9RNGF5qOysmFb74miC9XCDUzt6k8VJtXC9jsihW9Tu5Uuq/vhvlKokuGjc1bRhWZVLdw5MWq8mU6zfNL4wKILk/W0spW6dyvOZ61p4wKd7EIzcoZot+UQVVxeA62bEmUXJuPyIV8PnDsVtxXtpikKL1S7++1U6/IZzV1g8xSFFx4i9HWMdjksNZQCGxOlFyZq8jW1VmubpZV90PngUZ8ovvDYuNt//Wy/1ZPAhsQICo+rUMa4T70msP7tJorCun8vKofKhilGWlg7wfopxlnYMMHaKUZZ2DjBuinGWPgwsDLFCAufBLqJ8RU+DXQ21OgKXwgsTzG2wpcCj1O8nsJGVvjgMNE0xbgKX5zgeYqXxKgKX57geYrnDTWmwhYTvJtiRIUtA3/fbuIpbB14mWI0hR0Cz1OMpbBT4CkxiaOwY+BpQ42isNVhwk283hJc2HmC5Va5hf8xwTgK/UxQcKGvQLGF3gKlFvoLFFroMVBmoc9AkYWeDhNyC1Xh9aJLeYV+Jyiw0Os+KLHQe6C0Qv+BwgoDBMoqDBEoqtCECJRUOPz2e5gQV2jnYa7qllOYBvr5CEGFgVBIIYXPmJ/ghZueZ+hexOWd+w3q9ycuwg5R2377DsapDflbX7rTFah+TbajQSij/aT/wNNF26FUvoELAAAAAAAAAAAAAAAAAAAAAAAAAAAA4G/4B9L3P1vg3y4/AAAAAElFTkSuQmCC");

            }


        }

        private void dgvPokemons_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}