using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServices
{
    public class Producto
    {

        public int idProducto { get; set; }
        public string nombre { get; set; }
        public float precio { get; set; }
        public int stock { get; set; }
    }
}