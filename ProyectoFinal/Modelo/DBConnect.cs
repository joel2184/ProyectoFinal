using System.Data.SqlClient;

namespace ProyectoFinal.DALs
{
    internal class DBConnect
    {
        
        public SqlConnection conexion;
        public const string str = "Data Source=217.71.207.123,54321 ;Initial Catalog=Jose_residencia;" +
            "Persist Security Info= True; User ID= sa;Password=123456789";

        public void OpenConection()
            {
                conexion = new SqlConnection(str);
                conexion.Open();

            }


            public void CloseConnection()
            {
                conexion.Close();
            }
        
    }
}