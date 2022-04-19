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
            btnLogOut.Visible = false;
            if (Session["Voluntario"] != null || Session["Residencia"] != null)
            {
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
                    Session["Voluntario"] = tempv;
                else
                    Session["Residencia"] = tempr;

                if (rememberme.Checked == true)
                    addCookie(tempv, tempr);

                Response.Redirect("About.aspx");

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