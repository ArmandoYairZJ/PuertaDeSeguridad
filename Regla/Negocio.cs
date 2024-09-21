using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Regla
{
    public class SQLServerClass
    {

        public String sLastError = String.Empty;

        public Boolean SiHayConexion(String NombreTab)
        {
            bool bAllok = false;
            try
            {
                String sConexionDB = ConexionEstatica();
                using (SqlConnection conn = new SqlConnection(sConexionDB))
                {
                    conn.Open();
                    conn.Close();
                }

                bAllok = true;
            }
            catch (Exception ex)
            {
                sLastError = ex.Message;
                bAllok = false;
            }
            return bAllok;
        }

        public string ConexionEstatica()
        {
            string SSQL = "ARMANDOZAMBRANO\\SQLEXPRESS";
            string INT = "Proyecto";
            string USQL = "sa";
            string CSQL = "1234";
            return $"Data Source={SSQL};Initial Catalog={INT};User ID={USQL};Password={CSQL};";
        }


        public bool BuscarAlumno(long credencial)
        {
            try
            {
                string sConexionDB = ConexionEstatica();

                using (SqlConnection conn = new SqlConnection(sConexionDB))
                {
                    conn.Open();

                    string query = "select COUNT(*) from Identi where credencial = @credencial";

                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@credencial", credencial);

                    int count = (int)command.ExecuteScalar();

                    conn.Close();

                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                sLastError = ex.Message;
                return false;
            }
        }



    }

}
