﻿using ProyectoFinal.DALs;
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
            divListVol.Visible = false;
            

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
            divListVol.Visible = false;
            btnActForm.BackColor = Color.Green;
            btnVoluList.BackColor = Color.Gray;
        }
        protected void btnVoluList_Click(object sender, EventArgs e)
        {
            divNewAct.Visible = false;
            divListVol.Visible = true;
            btnActForm.BackColor =  Color.Gray;
            btnVoluList.BackColor = Color.Green; 
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Alert("Ha de rellenar todos los campos");
            if (txtNom.Text != null && ddTipo.SelectedValue.ToString() != null && txtHor.Value != null && txtFecha.Value != null && txtDesc.Value != null)
            {
                DALActividad newActivity = new DALActividad();
                newActivity.InsertActividad(new Actividad(txtNom.Text, ddTipo.SelectedValue.ToString(), TimeSpan.Parse(txtHor.Value), Convert.ToDateTime(txtFecha.Value), txtDesc.Value, (int)Session["Residencia"]));
               
            }                
            else
                Response.Redirect("Default.aspx");


        }
        protected void Alert(string message)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "errorAlert", "alert('" + message + "');", true);
        }
    }
}