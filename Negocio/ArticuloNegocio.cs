using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;
using System.Net;
using System.Data;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                //corregir consulta
                datos.setearConsulta("SELECT A.Id, Codigo, Nombre, A.Descripcion, M.Descripcion AS Marca, C.Descripcion AS Categoria, Precio, MIN(ImagenUrl) AS ImagenUrl, A.IdCategoria, A.IdMarca FROM ARTICULOS A JOIN MARCAS M ON A.IdMarca = M.Id JOIN CATEGORIAS C ON A.IdCategoria = C.Id JOIN IMAGENES I ON A.Id = I.IdArticulo GROUP BY A.Id, Codigo, Nombre, A.Descripcion, M.Descripcion, C.Descripcion, Precio, A.IdCategoria, A.IdMarca");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    //if(aux.Id = (int)datos.Lector["Id"] != id actual)
                    Articulo aux = new Articulo();
                    //Marca marca = new Marca(); 
                    //Imagen imagen = new Imagen();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.CodigoArticulo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new Marca();
                    aux.Marca.IdMarca = (int)datos.Lector["IdMarca"];
                    aux.Marca.NombreMarca = (string)datos.Lector["Marca"];
                    aux.Cat = new Categoria();
                    aux.Cat.IdCategoria = (int)datos.Lector["IdCategoria"];
                    aux.Cat.NombreCategoria = (string)datos.Lector["Categoria"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.Imagen = new Imagen();
                    aux.Imagen.IdArtciulo = (int)datos.Lector["Id"];
                    aux.Imagen.UrlImagen = (string)datos.Lector["ImagenUrl"];

                    //id actual
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }

            finally 
            {
                datos.cerrarConexion();
            }
        }

        public Articulo buscarArticuloPorCodigo(string busqueda)
        {
            try
            {

                foreach (Articulo item in listar())
                {
                    if(item.CodigoArticulo.ToLower() == busqueda.ToLower())
                    {
                        return item;
                    }
                }
                return null;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void agregar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) values (@Codigo,@Nombre,@Descripcion,@IdMarca,@IdCategoria,@Precio)");
                datos.setearParametro("@Codigo", nuevo.CodigoArticulo);
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.setearParametro("@IdMarca", nuevo.Marca.IdMarca);
                datos.setearParametro("@IdCategoria", nuevo.Cat.IdCategoria);
                datos.setearParametro("@Precio", nuevo.Precio);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally 
            { 
                datos.cerrarConexion();
            }

        }

        public int buscarId(Articulo art)
        {
            AccesoDatos datos = new AccesoDatos();
            int Id;
            string codigo = art.CodigoArticulo.ToString();
            datos.setearConsulta("select id from ARTICULOS where Codigo = '"+codigo+"'");
            
            datos.ejecutarLectura();

            datos.Lector.Read();
            Id = (int)datos.Lector["id"];
                
            

            return Id;
        }

        public void eliminarArticulo(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("Delete From Articulos Where Id = @Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool buscarIdCategoria(int idCategoria)
        {
            List<int> lista = new List<int>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select IdCategoria from ARTICULOS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    int valor;

                    valor = (int)datos.Lector["IdCategoria"];
                    lista.Add(valor);
                }

                foreach (int item in lista)
                {
                    if(item == idCategoria)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


        public List<Articulo> filtroAvanzado(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "select A.Id, Codigo, Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Categoria, Precio, ImagenUrl, A.IdCategoria, A.IdMarca from ARTICULOS A, MARCAS M, CATEGORIAS C, IMAGENES I where A.IdMarca = M.Id and A.IdCategoria = C.Id and A.Id = I.IdArticulo And ";
               
                switch (campo)
                {
                    case "Precio":
                        switch (criterio)
                        {
                            case "Mayor a":
                                consulta += "Precio > "+filtro;
                                break;
                            case "Menor a":
                                consulta += "Precio < "+filtro;
                                break;
                            default:
                                consulta += "Precio = "+filtro;
                                break;
                        }
                        break;

                    case "Marca":
                        consulta += "M.Descripcion like '%" + filtro + "%'";
                        break;

                    case "Categoria":
                        consulta += "C.Descripcion like '%" + filtro + "%'";
                        break;

                    default:
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += campo+" like '" + filtro + "%' ";
                                break;
                            case "Termina con":
                                consulta += campo+" like '%" + filtro + "' ";
                                break;
                            default:
                                consulta += campo+" like '%" + filtro + "%'";
                                break;
                        }
                        break;
                }
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.CodigoArticulo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new Marca();
                    aux.Marca.IdMarca = (int)datos.Lector["IdMarca"];
                    aux.Marca.NombreMarca = (string)datos.Lector["Marca"];
                    aux.Cat = new Categoria();
                    aux.Cat.IdCategoria = (int)datos.Lector["IdCategoria"];
                    aux.Cat.NombreCategoria = (string)datos.Lector["Categoria"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.Imagen = new Imagen();
                    aux.Imagen.IdArtciulo = (int)datos.Lector["Id"];
                    aux.Imagen.UrlImagen = (string)datos.Lector["ImagenUrl"];


                    lista.Add(aux);
                }


                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public bool buscarIdMarca(int IdMarca)
        {
            List<int> lista = new List<int>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select IdMarca from ARTICULOS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    int valor;

                    valor = (int)datos.Lector["IdMarca"];
                    lista.Add(valor);
                }

                foreach (int item in lista)
                {
                    if(item == IdMarca)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Articulo> buscarArticulo(string busqueda)
        {
            List<Articulo> listaBusqueda = new List<Articulo>();            

            foreach (Articulo item in listar())
            {
                if(item.Nombre.ToLower().Contains( busqueda.ToLower()) || item.CodigoArticulo.ToLower() == busqueda.ToLower())
                {
                    listaBusqueda.Add(item);
                }
            }
            return listaBusqueda;
        }

        public void ModificarArticulo(Articulo art)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE ARTICULOS SET Codigo=@Codigo, Nombre=@Nombre, Descripcion=@Descripcion, IdMarca=@IdMarca, IdCategoria=@IdCategoria, Precio=@Precio WHERE Id=@Id");

                datos.setearParametro("@Codigo", art.CodigoArticulo);
                datos.setearParametro("@Nombre", art.Nombre);
                datos.setearParametro("@Descripcion", art.Descripcion);
                datos.setearParametro("@IdMarca", art.Marca.IdMarca);
                datos.setearParametro("@IdCategoria", art.Cat.IdCategoria);
                datos.setearParametro("@Precio", art.Precio);
                datos.setearParametro("@Id", art.Id);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }
    }
}
