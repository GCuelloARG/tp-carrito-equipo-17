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
            //if(Session["carrito"] != null)
            //{
            //    List<Articulo> carrito = (List<Articulo>)Session["carrito"];
            //    lblCantidadCarrito.Text = carrito.Count().ToString();

            //}
            lblCantidadCarrito.Text = contarArticulosEnCarrito().ToString();
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

    }
}