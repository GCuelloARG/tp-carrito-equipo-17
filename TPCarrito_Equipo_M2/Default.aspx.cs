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
        public List<Articulo> ListaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["listaArticulos"] == null)
            {
                ArticuloNegocio negocioArticulo = new ArticuloNegocio();

                Session.Add("listaArticulos", negocioArticulo.listar()); /* guardo la lista en sesion*/
            }

            if (!IsPostBack)
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                ListaArticulos = negocio.listar();

                repArticulo.DataSource = ListaArticulos;
                repArticulo.DataBind();
            }

            //dgvArticulos.DataSource = Session["listaArticulos"]; //origen de datos de dgvArticulos
            //dgvArticulos.DataBind(); //dibujar la tabla
        }


        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Button btnAgregar = (Button)sender;

            string id = btnAgregar.CommandArgument;


            if (id != null)
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

                bool articuloExistente = false;

                foreach (Articulo art in carrito)
                {
                    if (artAgregado.Id == art.Id)
                    {
                        articuloExistente = true;
                        artAgregado.Cantidad++;
                        
                        break;                        
                    }
                }
                if (!articuloExistente) /*si el articulo ya existe no lo vuelve a agregar*/
                {
                    artAgregado.Cantidad = 1;
                    carrito.Add(artAgregado);
                }

                Session["carrito"] = carrito; /*vuelvo a sobrescribir la sesion con el articulo nuevo*/


                Response.Redirect("Carrito.aspx", false);

            }
        }
    }
}