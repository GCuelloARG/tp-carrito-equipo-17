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
    public partial class Default : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["listaArticulos"] == null) 
            {
                ArticuloNegocio negocioArticulo = new ArticuloNegocio();

                Session.Add("listaArticulos", negocioArticulo.listar()); /* guardo la lista en sesion*/
            }

            dgvArticulos.DataSource = Session["listaArticulos"]; //origen de datos de dgvArticulos
            dgvArticulos.DataBind(); //dibujar la tabla

        }


        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id= dgvArticulos.SelectedDataKey.Value.ToString();


            if(id != null)
            {
                List<Articulo> listaTemporal = (List<Articulo>)Session["listaArticulos"];

                Articulo artAgregado = listaTemporal.Find(a => a.Id == int.Parse(id)); /*busco el id capturado dentro de la lista en sesion*/

                List<Articulo> carrito = new List<Articulo>();
                if (Session["carrito"] == null) /*si no existe la session del carrito, creo una lista nueva*/
                {
                    carrito = new List<Articulo>();
                }
                else /* si no la llamo*/
                {
                    carrito = (List<Articulo>)Session["carrito"];
                }
                carrito.Add(artAgregado);

                Session["carrito"] = carrito; /*vuelvo a sobrescribir la sesion con el articulo nuevo*/


                Response.Redirect("Carrito.aspx",false);

            }
        }
    }
}