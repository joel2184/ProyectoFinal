using ProyectoFinal.DALs;
using ProyectoFinal.Modelo;
using System;
using System.Collections.Generic;
using System.Drawing;
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
            divNewAct.Visible = false;
            divSeeVol.Visible = false;
            if (Session["Residencia"] != null)
            {
                DALResidencia dalresi = new DALResidencia();
                residenciaIniciada = dalresi.FindById((int)Session["Residencia"]);
                if (residenciaIniciada != null)
                {
                    lblTitle.Text = "Residencia "+residenciaIniciada.Nombre;

                }
                
            }
            else
            {
                Response.Redirect("Default.aspx");
            }

            btnActForm.BackColor = Color.Gray;
            btnVoluList.BackColor = Color.Gray;
        }
        
        protected void btnActForm_Click(object sender, EventArgs e)
        {
            divNewAct.Visible = true;
            divSeeVol.Visible = false;
            btnActForm.BackColor = Color.Green;
            btnVoluList.BackColor = Color.Gray;
        }
        protected void btnVoluList_Click(object sender, EventArgs e)
        {
            divNewAct.Visible = false;
            divSeeVol.Visible = true;
            btnActForm.BackColor =  Color.Gray;
            btnVoluList.BackColor = Color.Green; 
        }
        protected void Alert(string message)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "errorAlert", "alert('" + message + "');", true);
        }
    }
}