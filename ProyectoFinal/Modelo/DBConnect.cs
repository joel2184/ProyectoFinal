using System.Data.SqlClient;

namespace ProyectoFinal.DALs
{
    internal class DBConnect
    {
        
            public SqlConnection conexion;

            public void OpenConection()
            {
                conexion = new SqlConnection(Properties.Settings.Default.connStr);
                conexion.Open();

            }


            public void CloseConnection()
            {
                conexion.Close();
            }
        
    }
}