using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPCarrito_Equipo_M2
{
    public partial class Carrito : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["id"] != null) /* si el id del request de la pag Default no esta vacio*/
            //{
            //    int id = int.Parse(Session["id"].ToString());/*capturo el id que recibo de Default.aspx*/
            //    List<Articulo> listaTemporal = (List<Articulo>)Session["listaArticulos"];

            //    Articulo artAgregado = listaTemporal.Find(a => a.Id == id); /*busco el id capturado dentro de la lista en sesion*/
            //    listaArticulos.Add(artAgregado);

            //    Session.Add("listaCarrito", listaArticulos);
            //}


            //dgvCarrito.DataSource = Session["listaCarrito"]; /*cargo el dgvCarrito con los articulos agregados*/
            //dgvCarrito.DataBind();

            if (!IsPostBack)
            {
                List<Articulo> carrito = (List<Articulo>)Session["carrito"];
                generarTablaCarrito(carrito);
            }


        }

        private void generarTablaCarrito(List<Articulo> carrito) /*dibujar tabla con los articulos agregados*/
        {
            if(carrito != null)
            {
                foreach (Articulo art in carrito)
                {
                    TableRow fila = new TableRow();

                    TableCell celdaNombre = new TableCell();
                    celdaNombre.Text = art.Nombre;
                    fila.Cells.Add(celdaNombre);

                    TableCell celdaDescripcion = new TableCell();
                    celdaDescripcion.Text = art.Descripcion.ToString();
                    fila.Cells.Add(celdaDescripcion);

                    TableCell celdaMarca = new TableCell();
                    celdaMarca.Text = art.Marca.ToString();
                    fila.Cells.Add(celdaMarca);

                    TableCell celdaCategoria = new TableCell();
                    celdaCategoria.Text = art.Cat.ToString();
                    fila.Cells.Add(celdaCategoria);

                    TableCell celdaPrecio = new TableCell();
                    celdaPrecio.Text = art.Precio.ToString();
                    fila.Cells.Add(celdaPrecio);

                    TableCell celdaImagen = new TableCell();
                    celdaImagen.Text = art.Imagen.ToString();
                    fila.Cells.Add(celdaImagen);

                    TableCarrito.Rows.Add(fila);
                }
            }
        }

    }
}