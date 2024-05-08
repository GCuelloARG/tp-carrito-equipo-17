using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> listar()
        {
            List<Categoria> lista = new List<Categoria>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select Id, Descripcion From CATEGORIAS");
                datos.ejecutarLectura();


                while (datos.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.IdCategoria = (int)datos.Lector["Id"];
                    aux.NombreCategoria = (string)datos.Lector["Descripcion"];

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

        public void agregar(Categoria nueva) 
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("insert into CATEGORIAS(Descripcion) values (@descripcion)");
                datos.setearParametro("@descripcion", nueva.NombreCategoria);
                datos.ejecutarAccion();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void eliminarCategoria(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("Delete From Categorias Where Id = @Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ModificarCategoria(Categoria categoria)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE CATEGORIAS SET Descripcion=@Descripcion WHERE Id=@Id;");

                datos.setearParametro("@Descripcion", categoria.NombreCategoria);
                datos.setearParametro("@Id", categoria.IdCategoria);

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
        public Categoria buscarCategoriaPorNombre(string busqueda)
        {
            try
            {

                foreach (Categoria item in listar())
                {
                    if (item.NombreCategoria.ToLower() == busqueda.ToLower())
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
    }
}
