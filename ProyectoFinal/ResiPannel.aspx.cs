using ProyectoFinal.DALs;
using ProyectoFinal.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinal
{
    public partial class ResiPannel : Page
    {
        Residencia residenciaIniciada = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Residencia"] != null)
            {
                DALResidencia dalresi = new DALResidencia();
                residenciaIniciada = dalresi.FindById((int)Session["Residencia"]);
                if (residenciaIniciada != null)
                {
                    lblTitle.Text = residenciaIniciada.Nombre;

                }
                else
                {
                    Alert(Session["Residencia"].ToString());
                }
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
            
        }
        protected void Alert(string message)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "errorAlert", "alert('" + message + "');", true);
        }
    }
}