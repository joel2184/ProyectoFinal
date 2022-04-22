using System;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoFinal
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        DataTable tabla;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection conexionSQL = new SqlConnection("Data Source =");
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "SELECT direccion,latitud,longitud FROM Residencia";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conexionSQL;
                conexionSQL.Open();

                tabla = new DataTable();
                tabla.Load(cmd.ExecuteReader());
                Repeater1.DataSource = tabla;
                Repeater1.DataBind();
                conexionSQL.Close();


            }
        }
    }
}