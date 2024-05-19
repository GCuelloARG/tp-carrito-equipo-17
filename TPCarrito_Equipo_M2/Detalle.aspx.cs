using Dominio;
using Negocio;
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
        public List<Imagen> ListaImagenesID { get; set; }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"].ToString());
            List<Articulo> temporal = (List<Articulo>)Session["listaArticulos"];
            Articulo articulo = temporal.Find(x => x.Id == id);

            lblNombre.Text = articulo.Nombre;
            lblDescripcion.Text = articulo.Descripcion;
            lblMarca.Text = articulo.Marca.NombreMarca;
            lblPrecio.Text = articulo.Precio.ToString();

            List<Imagen> listaImagenes = new List<Imagen>();
            ImagenNegocio imagenNegocio = new ImagenNegocio();
            List<Imagen> img = new List<Imagen>();

            listaImagenes = imagenNegocio.listar();

            foreach (Imagen foto in listaImagenes)
            {
                if (foto.IdArtciulo == articulo.Id)
                {
                    img.Add(foto);
                }
            }

            ListaImagenesID = img;
            
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

        protected void btnAgregarCarrito_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"].ToString());
            List<Articulo> listaTemporal = (List<Articulo>)Session["listaArticulos"];
            Articulo artAgregado = listaTemporal.Find(a => a.Id == id);

            List<Articulo> carrito = new List<Articulo>();

            if (Session["carrito"] == null)
            {
                carrito = new List<Articulo>();
            }
            else
            {
                carrito = (List<Articulo>)Session["carrito"];
            }

            bool articuloExistente = false;

            foreach (Articulo arti in carrito)
            {
                if (artAgregado.Id == arti.Id)
                {
                    articuloExistente = true;
                    artAgregado.Cantidad += int.Parse(txtCantidad.Text);
                    break;
                }
            }
            if (!articuloExistente)
            {
                artAgregado.Cantidad += int.Parse(txtCantidad.Text);
                carrito.Add(artAgregado);
            }

            Session["carrito"] = carrito;

            Response.Redirect("Carrito.aspx", false);

        }
    }
}