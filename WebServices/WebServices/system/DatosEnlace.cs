﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WebServices
{
    public class DatosEnlace
    {
        public static string ipBaseDatos = ConfigurationManager.AppSettings["ipBaseDatos"];
        public static string nombreBaseDatos = ConfigurationManager.AppSettings["nombreBaseDatos"];
        public static string usuarioBaseDatos = ConfigurationManager.AppSettings["usuarioBaseDatos"];
        public static string passwordBaseDatos = ConfigurationManager.AppSettings["passwordBaseDatos"];
        public static int timeOutSqlServer = int.Parse(ConfigurationManager.AppSettings["timeOutSqlServer"]); 
    }
}