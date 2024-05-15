using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPCarrito_Equipo_M2
{
    public partial class Detalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"].ToString());
            List<Articulo> temporal = (List<Articulo>)Session["listaArticulos"];
            Articulo articulo = temporal.Find(x => x.Id == id);
            lblNombre.Text = articulo.Nombre;
            lblDescripcion.Text = articulo.Descripcion;
            lblMarca.Text = articulo.Marca.NombreMarca;
            lblPrecio.Text = articulo.Precio.ToString();

        }

        protected void btnAumenta_Click(object sender, EventArgs e)
        {
            int cant = int.Parse(txtCantidad.Text);
            cant += 1;
            txtCantidad.Text = cant.ToString();
        }

        protected void btnDisminuye_Click(object sender, EventArgs e)
        {
            int cant = int.Parse(txtCantidad.Text);
            if (cant > 1)
            {
                cant -= 1;
                txtCantidad.Text = cant.ToString();
            }

        }
    }
}