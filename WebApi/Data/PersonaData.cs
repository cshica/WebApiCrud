using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Data
{
    public class PersonaData
    {
        public static async Task<DataTable> ListarPersonas()
        {
            DataTable table = new DataTable();
            SqlConnection con = GlobalesData.CreateDatabase;
            await con.OpenAsync();
            try
            {
                string consulta = "dbo.ListarPersonas";//nombre del procedimiento almacenado 
                using (SqlCommand cmd = new SqlCommand(consulta, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                     
                    da.Fill(table);
                    da.Dispose();
                    await con.CloseAsync();
                    
                }
                return table;
            }
            catch (Exception ex)
            {
                table= new DataTable(); 
                await con.CloseAsync();
                return table;
            }
        }

        public static async Task<string> RegistrarPersona(Persona ent)
        {
            string res = string.Empty;
            SqlConnection con = GlobalesData.CreateDatabase;
            await con.OpenAsync();
            try
            {
                string consulta = "dbo.RegistrarPersona";//nombre del procedimiento almacenado 
                using (SqlCommand cmd = new SqlCommand(consulta, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre",ent.Nombre);
                    cmd.Parameters.AddWithValue("@Direccion",ent.Direccion);
                    
                    await cmd.ExecuteNonQueryAsync();
                    await con.CloseAsync();
                    res = "Registro Correcto";
                }
               return res;
            }
            catch (Exception ex)
            {
                res =ex.Message.ToString();
                return res;
            }
        }
    }
}
