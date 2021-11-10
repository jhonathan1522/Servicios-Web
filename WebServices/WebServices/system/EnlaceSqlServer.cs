using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebServices
{
    public class EnlaceSqlServer
    {
        private static SqlConnection conexion = null;

        public static SqlConnection Conexion {
            get { return EnlaceSqlServer.conexion; }
        }

        public static bool ConectarSqlServer() {
            bool estado = false;
            try
            {
                if (conexion == null) {
                    conexion = new SqlConnection();
                    conexion.ConnectionString = "Data Source=" + DatosEnlace.ipBaseDatos +
                        "; Initial Catalog=" + DatosEnlace.nombreBaseDatos +
                        "; User ID=" + DatosEnlace.usuarioBaseDatos +
                        "; Password=" + DatosEnlace.passwordBaseDatos +
                        "; MultipleActiveResultSets=True";
                    System.Threading.Thread.Sleep(750);
                }
                if (conexion.State == System.Data.ConnectionState.Closed) {
                    conexion.Open();
                }
                if (conexion.State == System.Data.ConnectionState.Broken)
                {
                    conexion.Close();
                    conexion.Open();
                }
                if (conexion.State == System.Data.ConnectionState.Connecting)
                {
                    while (conexion.State == System.Data.ConnectionState.Connecting)
                    {
                        System.Threading.Thread.Sleep(500);
                    }
                }

                estado = true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                // Implementar los logs para manejo de errores
                throw;
            }
            return estado;
        }
    }
}