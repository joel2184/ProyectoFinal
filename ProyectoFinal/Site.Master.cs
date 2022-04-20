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
    public partial class SiteMaster : MasterPage
    {
        Voluntario tempv = null;
        Residencia tempr = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            btnLogOut.Visible = false;
            btnResiPannel.Visible = false;
            btnCurrentRegister.Text = "REGISTRANDO COMO VOLUNTARIO";


            if (Session["Voluntario"] != null || Session["Residencia"] != null)
            {
                if (Session["Residencia"] != null)
                {
                    btnResiPannel.Visible = true;
                }
                idInicio.Visible = false;
                idRegistro.Visible = false;
                btnLogOut.Visible = true;
                
            }
            if (Request.Cookies["email"] != null && Request.Cookies["password"] != null)
            {
                txtMail.Text = this.Request.Cookies["email"].Value;
                txtPassword.Text = this.Request.Cookies["password"].Value;
            }

            divResi.Visible = false;
            btnVolu.BackColor = Color.Green;
            btnResi.BackColor = Color.Gray;
        }
        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            DALVoluntario dalV = new DALVoluntario();
            DALResidencia dalR = new DALResidencia();


            tempv = dalV.FindUser(txtMail.Text, txtPassword.Text);
            tempr = dalR.FindUser(txtMail.Text, txtPassword.Text);

            if (tempv != null || tempr != null)
            {
                if (rememberme.Checked == true)
                    addCookie(tempv, tempr);

                if (tempv != null)
                    Session["Voluntario"] = tempv.Id_Voluntario;
                else
                {
                    Session["Residencia"] = tempr.Id_Residencia;
                    Response.Redirect("ResiPannel.aspx");
                }
                                  

            }
            else
            {
                Console.WriteLine("No encontrado");
                Response.Redirect("#!");

            }

        }
        public void btnLogOut_Click(object sender, EventArgs e)
        {
            if (Session["Residencia"] != null || Session["Voluntario"] != null)
            {
                Session["Residencia"] = null;
                Session["Voluntario"] = null;

                Response.Redirect("Default.aspx");


            }
        }

        public void btnResiPannel_Click(object sender, EventArgs e)
        {
            if (Session["Residencia"] != null)
            {             
                Response.Redirect("ResiPannel.aspx");
            }
              
        }

        protected void btnVolu_Click(object sender, EventArgs e)
        {
            divVolu.Visible = true;
            divResi.Visible = false;
            btnVolu.BackColor = Color.Green;
            btnResi.BackColor = Color.Gray;
            btnCurrentRegister.Text = "REGISTRANDO COMO VOLUNTARIO";
        }


        protected void btnResi_Click(object sender, EventArgs e)
        {
            divVolu.Visible = false;
            divResi.Visible = true;
            btnVolu.BackColor = Color.Gray;
            btnResi.BackColor = Color.Green;
            btnCurrentRegister.Text = "REGISTRANDO COMO RESIDENCIA";
           

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

        protected void addCookie(Voluntario v, Residencia r)
        {
            if (v != null)
            {
                HttpCookie cookie1 = new HttpCookie("email", v.Email);
                HttpCookie cookie2 = new HttpCookie("password", v.Password);
                cookie1.Expires = new DateTime(2022, 4, 30);
                cookie2.Expires = new DateTime(2022, 4, 30);

                Response.Cookies.Add(cookie1);
                Response.Cookies.Add(cookie2);
            }
            else if (r != null)
            {
                HttpCookie cookie1 = new HttpCookie("email", r.Email);
                HttpCookie cookie2 = new HttpCookie("password", r.Password);
                cookie1.Expires = new DateTime(2022, 4, 30);
                cookie2.Expires = new DateTime(2022, 4, 30);
                Response.Cookies.Add(cookie1);
                Response.Cookies.Add(cookie2);
            }

        }
        
    }
}