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
    public partial class SiteMaster : MasterPage
    {
        Voluntario tempv = null;
        Residencia tempr = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            divResi.Visible = false;
            btnVolu.Enabled = false;
        }
        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            DALVoluntario dalV = new DALVoluntario();
            DALResidencia dalR = new DALResidencia();
            

            tempv = dalV.FindUser(txtMail.Text, txtPassword.Text);
            tempr = dalR.FindUser(txtMail.Text, txtPassword.Text);

            if (tempv != null || tempr != null)
            {
                if (tempv != null)
                    Global.vSigned = tempv;
                else
                    Global.rSigned = tempr;

                Response.Redirect("About.aspx");


            }
            else
            {
                Console.WriteLine("No encontrado");
                Response.Redirect("#!");

            }
            
        }

        protected void btnVolu_Click(object sender, EventArgs e)
        {
            divVolu.Visible = true;
            divResi.Visible = false;
            btnVolu.Enabled = false;
            btnResi.Enabled = true;
        }


        protected void btnResi_Click(object sender, EventArgs e)
        {
            divVolu.Visible = false;
            divResi.Visible = true;
            btnVolu.Enabled = true;
            btnResi.Enabled = false;
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            if (btnResi.Enabled == false)
            {
                Residencia r = new Residencia(txtNomR.Text, txtDireR.Text, txtEmailR.Text, txtTelR.Text, txtPassR.Text);
                DALResidencia dalr = new DALResidencia();
                tempr = dalr.InsertUser(r);
                if (tempr != null)
                {
                    Response.Redirect("About.aspx");
                }
            }
            else if (btnVolu.Enabled == false)
            {
                Voluntario v = new Voluntario(txtDni.Text, txtNomV.Text, txtTelV.Text, txtEmailV.Text, dlHor.SelectedValue.ToString(), txtPassV.Text);
                DALVoluntario dalv = new DALVoluntario();
                tempv = dalv.InsertUser(v);
                if (tempv != null)
                {
                    Response.Redirect("About.aspx");
                }
            }
        }
    }
}