using ProyectoFinal.DALs;
using ProyectoFinal.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinal
{
    public partial class Contact : Page
    {
        public Actividad actividadActual;
        static int idActividad;
        protected void Page_Load(object sender, EventArgs e)
        {
            btnCancelar.Visible = false;
            if (Session["Voluntario"] == null)
            {
                //Alert("dcede");
                Response.Redirect("Default.aspx");

            }
            

            if (!this.IsPostBack)
            {
                //cargar actividad seleccionada
                int id = Convert.ToInt32(Request.QueryString["id"]);


                DALActividad dalA = new DALActividad();
                actividadActual = dalA.SelectbyID(id);
                idActividad = id;
                mostrarActividad(actividadActual);
            }



            


        }

        public void mostrarActividad(Actividad a)
        {
            DALVoluntarioActividad dalVolAct = new DALVoluntarioActividad();

            if (dalVolAct.SelectbyIDs(a.Id_actividad, (int)Session["Voluntario"]) == false)
            {
                StringBuilder sb = new StringBuilder();

                Residencia r = new Residencia();
                DALResidencia dalR = new DALResidencia();
                r = dalR.FindById(a.Residencia);
                string estrcuctura = "";
                string img = "Images/" + a.Tipo.ToString() + ".jpg";
                estrcuctura = "<div class='container'>" +
                                       "<img src='" + img + "' alt='' style='height: 208px; width: 350px; float: right'>" +
                                      "<div class='row'>" +
                                      "<div class='col-md-6'><h1 id ='titleActividad'>" + a.Nombre + "</h1></div>" +
                                      "<div class='col-md-6'><h1 id ='nombreResi'>" + r.Nombre + "</h1></div>" +
                                        "</div>" +
                                        "<div class='row'>" +
                                        "<div class='col-md-6'><p id='tipo'>" + "Tìpo de actividad: " + a.Tipo + "</p></div>" +
                                        "<div class='col-md-6'><p id='direccion'>" + r.Direccion + "</p></div>" +
                                        "</div>" +
                                        "<div class='row'>" +
                                        "<div class='col-md-6'><p id='fecha'>" + String.Format("{0:d/M/yyyy}", a.Fecha) + "," + a.Horario.ToString() + "</p></div>" +
                                      "<div class='col-md-6'><p id='tel'>" + r.Telefono + "</p></div>" +
                                    "</div>" +
                                     "<div class='row'>" +
                                        "<div class='col-md-6'><p id='descripcion'>" + a.Descripcion + "</p></div>" +
                                        "<div class='col-md-6'><p id='mail'>" + r.Email + "</p></div>" +
                                        "</div>" +
                                        "</div>";
                sb.Append(estrcuctura);
                btnApuntarse.Visible = true;
                Apuntado.Visible = false;
                btnCancelar.Visible = false;
                divActividad.Text = sb.ToString();

            }
            else
            {
                StringBuilder sb = new StringBuilder();

                Residencia r = new Residencia();
                DALResidencia dalR = new DALResidencia();
                r = dalR.FindById(a.Residencia);
                string estrcuctura = "";
                string img = "Images/" + a.Tipo.ToString() + ".jpg";
                estrcuctura = "<div class='container'>" +
                              "<img src='" + img + "' alt=''style='height: 208px; width: 350px; float: right'>" +
                                      "<div class='row'>" +
                                      "<div class='col-md-6'><h1 id ='titleActividad'>" + a.Nombre + "</h1></div>" +
                                      "<div class='col-md-6'><h1 id ='nombreResi'>" + r.Nombre + "</h1></div>" +
                                        "</div>" +
                                        "<div class='row'>" +
                                        "<div class='col-md-6'><p id='tipo'>" + "Tìpo de actividad: " + a.Tipo + "</p></div>" +
                                        "<div class='col-md-6'><p id='direccion'>" + r.Direccion + "</p></div>" +
                                        "</div>" +
                                        "<div class='row'>" +
                                        "<div class='col-md-6'><p id='fecha'>" + String.Format("{0:d/M/yyyy}", a.Fecha) + "," + a.Horario.ToString() + "</p></div>" +
                                      "<div class='col-md-6'><p id='tel'>" + r.Telefono + "</p></div>" +
                                    "</div>" +
                                     "<div class='row'>" +
                                        "<div class='col-md-6'><p id='descripcion'>" + a.Descripcion + "</p></div>" +
                                        "<div class='col-md-6'><p id='mail'>" + r.Email + "</p></div>" +
                                        "</div>" +
                                        "</div>" ;
                sb.Append(estrcuctura);
                btnApuntarse.Visible = false;
                Apuntado.Visible = true;
                btnCancelar.Visible = true;
                divActividad.Text = sb.ToString();

            }


            


        }
        public void btnApuntarse_Click(object sender, EventArgs e)
        {
            
            DALVoluntarioActividad dalVolAct = new DALVoluntarioActividad();
            dalVolAct.InsertActividadVoluntario(idActividad, (int)Session["Voluntario"]);
            Response.Redirect(Request.RawUrl);
        }
        public void btnCancelar_Click(object sender, EventArgs e)
        {

            DALVoluntarioActividad dalVolAct = new DALVoluntarioActividad();
            dalVolAct.DeleteActividadVoluntario(idActividad, (int)Session["Voluntario"]);
            
            Response.Redirect(Request.RawUrl);
            //Apuntado.Text = "Has cancelado el voluntariado de forma exitosa";
        }
        

    }
}