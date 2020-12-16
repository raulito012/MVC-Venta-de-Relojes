using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace Catalog.Models
{
    public class DBCommon
    {
        private static string conn = @"Data Source=PC-PC\SQLEXPRESS;Initial Catalog=Reloj;Integrated Security=True";

        public static IDbConnection conexion()
        {
            return new SqlConnection(conn);

        }
    }
}