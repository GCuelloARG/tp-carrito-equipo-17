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
            if (!IsPostBack)
            {
                List<Articulo> carrito = (List<Articulo>)Session["carrito"];

                repCarrito.DataSource = carrito;
                repCarrito.DataBind();
            }                       
            //generarTablaCarrito(carrito);

        }

        protected void generarTablaCarrito(List<Articulo> carrito) /*dibujar tabla con los articulos agregados*/
        {
            if(carrito != null)
            {
                foreach (Articulo art in carrito)
                {

                    int cantidad = 1;
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

                    TableCell celdaPrecio = new TableCell();
                    celdaPrecio.Text = art.Precio.ToString();
                    fila.Cells.Add(celdaPrecio);

                    TableCell celdaImagen = new TableCell();
                    celdaImagen.Text = art.Imagen.ToString();
                    fila.Cells.Add(celdaImagen);

                    TableCell celdaCantidad = new TableCell();
                    TextBox txtCantidad = new TextBox();
                    txtCantidad.Text = cantidad.ToString();
                    celdaCantidad.Controls.Add(txtCantidad);
                    fila.Cells.Add(celdaCantidad);

                    TableCell celdaEliminar = new TableCell();
                    Button btnEliminar = new Button();
                    btnEliminar.Text = "Eliminar";
                    btnEliminar.CommandArgument = art.Id.ToString();
                    btnEliminar.Command += btnEliminar_Click;
                    celdaEliminar.Controls.Add(btnEliminar);
                    fila.Cells.Add(celdaEliminar);

                    TableCarrito.Rows.Add(fila);
                }
            }
        }
                    

        protected void btnEliminar_Click(object sender, EventArgs e) 
        {
            Button button = (Button)sender;
            int idArticulo = int.Parse(button.CommandArgument);

            List<Articulo> carrito =(List<Articulo>) Session["carrito"];


            for (int i = 0; i < carrito.Count() ; i++)
            {
                if(carrito[i].Id == idArticulo)
                {
                    carrito.RemoveAt(i);
                    Session["carrito"] = carrito;
                    Response.Redirect("Carrito.aspx", false);
                    return;
                }

            }

        }

        protected void btnAumentar_Click(object sender, EventArgs e)
        {
            Button btnAumentar = (Button)sender;
            string id = btnAumentar.CommandArgument;
            List<Articulo> lista = (List<Articulo>)Session["carrito"];
            Articulo artAumentado = lista.Find(a => a.Id == int.Parse(id)); /*busco el id capturado dentro de la lista en sesion*/
            
            foreach (Articulo arti in lista)
            {
                if(arti.Id == artAumentado.Id)
                {
                    arti.Cantidad++;
                    Session["carrito"] = lista;
                    Response.Redirect("Carrito.aspx", false);
                    return;
                }
            }
        }
    }
}