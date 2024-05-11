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
            ArticuloNegocio negocioArticulo = new ArticuloNegocio();
            List<Articulo> lista=negocioArticulo.listar();

            dgvArticulos.DataSource = lista; //origen de datos de dgvArticulos
            dgvArticulos.DataBind(); //dibujar la tabla


        }

    }
}