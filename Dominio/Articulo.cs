using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Articulo
    {
        //Los datos mínimos con los que deberá contar el artículo son los siguientes:

        public int Id { get; set; }
        [DisplayName("Código")]
        public string CodigoArticulo { get; set; }
        public string Nombre { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        public Marca Marca { get; set; }
        [DisplayName("Categoría")]
        public Categoria Cat { get; set; }
        public Imagen Imagen { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
    }
}
