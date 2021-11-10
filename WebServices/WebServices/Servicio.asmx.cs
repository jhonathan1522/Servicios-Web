using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebServices
{
    /// <summary>
    /// Descripción breve de Servicio
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Servicio : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }


        [WebMethod(Description ="Saluda a la persona")]
        public string Saludar(string nombre)
        {
            return "Hola " + nombre;
        }

        [WebMethod]
        public List<Equipos> ObtenerEquipos()
        {
            List<Equipos> equipos = new List<Equipos>();
            equipos.Add(new Equipos { Nombre = "Mila", Pais = "Italia" });
            equipos.Add(new Equipos { Nombre = "Real Madrid", Pais = "España" });
            return equipos;
        }


        [WebMethod]
        public String GuardarLog(string mensaje)
        {
            Funciones.Logs("LogServicio",mensaje);
            return "ok";
        }


        // Desde la base de datos 
        [WebMethod]
        public string ObtenerProductos()
        {
            List<Dictionary<string,string>> json = new List<Dictionary<string, string>>();
            if (!EnlaceSqlServer.ConectarSqlServer()) {
                return "";
            }
            try
            {
                SqlCommand com = new SqlCommand("Select * from productos", EnlaceSqlServer.Conexion);
                com.CommandType = CommandType.Text;
                com.CommandTimeout = DatosEnlace.timeOutSqlServer;

                SqlDataReader record = com.ExecuteReader();
                if (record.HasRows) {
                    Dictionary<string, string> row;
                    while (record.Read()) {
                        row = new Dictionary<string, string>();
                        for (int i = 0; i < record.FieldCount; i++)
                        {
                            row.Add(record.GetName(i), record.GetValue(i).ToString());
                        }
                        json.Add(row);
                    }
                }
                record.Close();
                record.Dispose();
                record = null;
                com.Dispose();
            }

            
            catch (Exception e)
            {
                Funciones.Logs("Obtener Productos", e.Message);
                Funciones.Logs("Obtener Productos_debugg", e.StackTrace);
            }
            return JsonConvert.SerializeObject(json);
        }




        [WebMethod]
        public Producto ObtenerProducto(string mensaje)
        {
            Producto producto = new Producto();
            producto.idProducto = 0;
            producto.nombre = "";
            producto.precio = 0;
            producto.stock = 0;

            if (!EnlaceSqlServer.ConectarSqlServer()) {
                return producto;
            }

            try
            {

            }
            catch (Exception e)
            {
                Funciones.Logs("ObtenerProducto", e.Message);
                Funciones.Logs("ObtenerProducto_DEBUGG", e.StackTrace);
            }

            return producto;

        }
    }
}
