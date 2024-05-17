using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace TPCarrito_Equipo_M2
{
    public partial class MiMaster : System.Web.UI.MasterPage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            lblCantidadCarrito.Text = contarArticulosEnCarrito().ToString(); /*cargar la cantidad de articulos para que se muestre en el icono*/  
        }

        protected int contarArticulosEnCarrito()
        {
            if (Session["carrito"] != null)
            {
                List<Articulo> carrito = (List<Articulo>)Session["carrito"];
                int cantTotalArticulos = 0;

                foreach (Articulo art in carrito)
                {
                    cantTotalArticulos += art.Cantidad;
                }
                return cantTotalArticulos;

            }
            else
            {
                return 0;
            }

        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e) /* FILTRO DE ARTICULOS*/
        {
            ArticuloNegocio artNegocio = new ArticuloNegocio();
            List<Articulo> listaArticulosFiltrados = artNegocio.buscarArticulo(txtBuscar.Text);

            if(txtBuscar.Text.Length >= 2) /*filtra a partir de 2 letras*/
            {
                Session.Add("filtro", listaArticulosFiltrados);
                Response.Redirect("Default.aspx?filtroActivo=true"); /* si se produjo una busqueda, se manda un true al index para cargar la pagina con el filtro*/

            }
            else
            {
                
                Response.Redirect("Default.aspx",false);
            }



        }
    }
}