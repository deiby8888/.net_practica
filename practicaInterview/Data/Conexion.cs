﻿using System.Data.SqlClient;

namespace practicaInterview.Data
{
    public class Conexion
    {
        private string cadenaSQL = string.Empty;
        public Conexion()
        {

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            cadenaSQL = builder.GetSection("ConnectionStrings:cadenaSQL").Value;
        }

        public string getCadenaSql()
        {
            return cadenaSQL;
        }
    }
}
