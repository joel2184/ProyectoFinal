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
        Voluntario tempv;
        Residencia tempr;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Manejo de estilos y uso de cookies
            btnLogOut.Visible = false;
            btnResiPannel.Visible = false;
            tempv = null;
            tempr = null;
            btnCurrentRegister.Text = "REGISTRANDO COMO VOLUNTARIO";


            if (!Page.IsPostBack && Request.Cookies["email"] != null && Request.Cookies["password"] != null)
            {
                txtMail.Text = this.Request.Cookies["email"].Value;
                txtPassword.Text = this.Request.Cookies["password"].Value;
            }



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

            divResi.Visible = false;

        }
        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            //Buscar usuario y validacion login
            DALVoluntario dalV = new DALVoluntario();
            DALResidencia dalR = new DALResidencia();


            tempv = dalV.FindUser(txtMail.Text, txtPassword.Text);
            tempr = dalR.FindUser(txtMail.Text, txtPassword.Text);

            if (tempv != null || tempr != null)
            {
                if (rememberme.Checked == true)
                    addCookie(tempv, tempr);

                if (tempv != null)
                {
                    Session["Voluntario"] = tempv.Id_Voluntario;
                    Response.Redirect("Default.aspx");
                }                    
                else if (tempr != null)
                {
                    Session["Residencia"] = tempr.Id_Residencia;
                    Response.Redirect("ResiPannel.aspx");
                }

            }
            else
            {
                Console.WriteLine("No encontrado");
                Session["Error"] = true;
                Response.Redirect("Default.aspx");
            }

        }
        public void btnLogOut_Click(object sender, EventArgs e)
        {
            //Método para cerrar sesion
            if (Session["Residencia"] != null || Session["Voluntario"] != null)
            {
                Session["Residencia"] = null;
                Session["Voluntario"] = null;
                tempr = null;
                tempv = null;

                Response.Redirect("Default.aspx");


            }
        }

        public void btnResiPannel_Click(object sender, EventArgs e)
        {
            //Click en panel de control
            if (Session["Residencia"] != null)
            {
                Response.Redirect("ResiPannel.aspx");
            }

        }

        protected void btnVolu_Click(object sender, EventArgs e)
        {
            //Cambio de texto cuando estas en un regsitro
            divVolu.Visible = true;
            divResi.Visible = false;

            btnCurrentRegister.Text = "REGISTRANDO COMO VOLUNTARIO";
        }


        protected void btnResi_Click(object sender, EventArgs e)
        {
            //Cambio de texto cuando estas en un regsitro
            divVolu.Visible = false;
            divResi.Visible = true;


            btnCurrentRegister.Text = "REGISTRANDO COMO RESIDENCIA";


        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            //Validaciones
            if (txtDni.Text.Length != 0 && txtNomV.Text.Length != 0 && txtTelV.Text.Length != 0 && txtEmailV.Text.Length !=0 && txtPassV.Text.Length!= 0)
            {
                Voluntario v = new Voluntario(txtDni.Text, txtNomV.Text, txtTelV.Text, txtEmailV.Text, dlHor.SelectedValue.ToString(), txtPassV.Text);
                DALVoluntario dalv = new DALVoluntario();
                tempv = dalv.InsertUser(v);
                Response.Redirect("About.aspx");
            }
            else if (txtNomR.Text.Length != 0 && txtDireR.Text.Length != 0 && txtEmailR.Text.Length != 0 && txtTelR.Text.Length != 0 && txtPassR.Text.Length != 0)
            {
                Residencia r = new Residencia(txtNomR.Text, txtDireR.Text, txtEmailR.Text, txtTelR.Text, txtPassR.Text);
                DALResidencia dalr = new DALResidencia();
                tempr = dalr.InsertUser(r);
                Response.Redirect("About.aspx");
            }            
            else
            {
                Session["Error"] = true;
                Response.Redirect("Default.aspx");
            }
        }

        protected void addCookie(Voluntario v, Residencia r)
        {
            //Gestion de cookies
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
        protected void vaciarCampos()
        {
            txtMail.Text = "";
            txtPassword.Text = "";
            txtNomV.Text = "";
            txtNomR.Text = "";
        }
    }
}