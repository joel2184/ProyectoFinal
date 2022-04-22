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
        Voluntario volu;
        Actividad acti;
        protected void Page_Load(object sender, EventArgs e)
        {
            divNewAct.Visible = false;
            divListVol.Visible = false;
            divListAct.Visible = false;

                       

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
            btnActiList.BackColor = Color.Gray;
            btnRemove.BackColor = Color.Red;
        }
        
        protected void btnActForm_Click(object sender, EventArgs e)
        {
            Show("addActi");
        }
        protected void btnVoluList_Click(object sender, EventArgs e)
        {
            lbVolu.Items.Clear();
            List<int> list = new List<int>();
            Show("VoluApuntados");
            DALVoluntarioActividad dalboth = new DALVoluntarioActividad();
            DALActividad dalactividad = new DALActividad();
            DALVoluntario dalvoluntario = new DALVoluntario();
            list = dalboth.SelectAll();

            for (int i = 0; i < list.Count(); i= i+2)
            {
                volu = dalvoluntario.SelectbyID(list[i]);
                acti = dalactividad.SelectbyID(list[i + 1]);
                lbVolu.Items.Add(volu.toString() + " PARA HACER " + acti.Nombre);

            }
        }

        protected void btnActiList_Click(object sender, EventArgs e)
        {
            lbActi.Items.Clear();
            List<Actividad> list;
            Show("Actividades");
            
            DALActividad dalactividad = new DALActividad();
            list = dalactividad.SelectAll();

            foreach (Actividad item in list)
            {
                if (item.Residencia == (int)Session["Residencia"])
                {
                    lbActi.Items.Add(item.toString());
                }
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {           
            if (txtNom.Text.Length != 0 && txtHor.Value.Length != 0 && txtFecha.Value.Length != 0 && txtDesc.Value.Length != 0)
            {
                DALActividad newActivity = new DALActividad();
                newActivity.InsertActividad(new Actividad(txtNom.Text, ddTipo.SelectedValue.ToString(), TimeSpan.Parse(txtHor.Value), Convert.ToDateTime(txtFecha.Value), txtDesc.Value, (int)Session["Residencia"]));
               
            }                
            else
                Response.Redirect("Default.aspx");


        }
        protected void btnRemoveActi_Click(object sender, EventArgs e)
        {
            DALActividad dalacti = new DALActividad();
            string actividad = lbActi.SelectedItem.ToString();
            int  activida = Convert.ToInt32(actividad[0].ToString());
            dalacti.DeleteActividad(activida);
            btnActiList_Click(sender, e);            
            
            


        }
        protected void Show(String what)
        {
            switch (what)
            {
                case "VoluApuntados":                    
                    divListVol.Visible = true;
                    btnVoluList.BackColor = Color.Green;
                    break;
                case "Actividades":                    
                    divListAct.Visible = true;
                    btnActiList.BackColor = Color.Green;
                    break;
                case "addActi":
                    divNewAct.Visible = true;                    
                    btnActForm.BackColor = Color.Green;
                    
                    break;
            }
        }
        protected void Alert(string message)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "errorAlert", "alert('" + message + "');", true);
        }
    }
}