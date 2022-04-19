using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinal
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Voluntario"] == null && Session["Residencia"] == null)
            {
                //Alert("dcede");
                Response.Redirect("Default.aspx");
                
            }
        }
        protected void Alert(string message)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "errorAlert", "alert('" + message + "');", true);
        }

    }
}