using System.Data.SqlClient;

namespace ProyectoFinal.DALs
{
    internal class DBConnect
    {
        
        public SqlConnection conexion;

        //Abrir conexión
        public void OpenConection()
        {
            conexion = new SqlConnection(Properties.Settings.Default.connStr);
            conexion.Open();

        }

        //Cerrar conexión
        public void CloseConnection()
            {
                conexion.Close();
            }
        
    }
}