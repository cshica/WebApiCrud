using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.IO;
using System;

namespace WebApi.Data
{
    public class GlobalesData
    {
        public static SqlConnection CreateDatabase
        {
            get
            {
                SqlConnection con = new SqlConnection();

                try
                {
                    IConfiguration config = new ConfigurationBuilder().
                      SetBasePath(Directory.GetCurrentDirectory()).
                      AddJsonFile("appsettings.json").
                      Build();
                    string cadCon = config.GetConnectionString("conex");
                    con = new SqlConnection(cadCon);

                    return con;
                }
                catch (Exception ex)
                {
                    con.CloseAsync();
                    con.Dispose();
                    throw ex;
                }
            }
        }
    }
}
