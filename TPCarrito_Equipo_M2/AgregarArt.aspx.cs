using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPCarrito_Equipo_M2
{
    public partial class AgregarArt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //cboCatArt.DataSource = categoriaNegocio.listar();
            //cboCatArt.ValueMember = "IdCategoria";
            //cboCatArt.DisplayMember = "NombreCategoria";

            MarcaNegocio marca = new MarcaNegocio();
            ddlMarca.DataSource = marca.listar();
            ddlMarca.DataBind();

            CategoriaNegocio categoria = new CategoriaNegocio();
            ddlCategoria.DataSource = categoria.listar();
            ddlCategoria.DataBind();    

        }

        protected void btnAgregarImagen_Click(object sender, EventArgs e)
        {

        }
    }
}