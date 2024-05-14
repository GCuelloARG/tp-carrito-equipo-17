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
            cant -= 1;
            txtCantidad.Text = cant.ToString();

        }
    }
}