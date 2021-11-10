using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumo
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.ServicioSoapClient client = new ServiceReference1.ServicioSoapClient();

            //string result = client.HelloWorld();
            //Console.WriteLine(result);

            // 2 
            //string result = client.Saludar("Jhonathan");
            //Console.WriteLine(result);

            // 3 consume clase equipos
            //ServiceReference1.Equipos[] equipos = client.ObtenerEquipos();

            //foreach (var equipo in equipos)
            //{
            //    Console.WriteLine(equipo.Nombre + "  -  " + equipo.Pais);
            //}


            // Consumo de la tabla productos desde bd

            string result = client.ObtenerProductos();

            dynamic productos = JsonConvert.DeserializeObject(result);
            foreach (dynamic producto in productos) {
                Console.WriteLine(producto);
            }



            Console.ReadKey();
        }
    }
}
