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
        protected void Page_Load(object sender, EventArgs e)
        {
            
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

                mostrarActividad(actividadActual);
            }






        }
        public void mostrarActividad(Actividad a)
        {

              StringBuilder sb = new StringBuilder();

              Residencia r = new Residencia();
              DALResidencia dalR = new DALResidencia();
              r = dalR.FindById(a.Residencia);
              string estrcuctura = "";

              estrcuctura = "<div class='container'>" +
                                    "<div class='row'>" +
                                    "<div class='col-md-6'><h1 id ='titleActividad'>"+a.Nombre+"</h1></div>" +
                                    "<div class='col-md-6'><h1 id ='nombreResi'>"+r.Nombre+"</h1></div>" +
                                      "</div>" +
                                      "<div class='row'>" +
                                      "<div class='col-md-6'><p id='tipo'>"+"Tìpo de actividad: "+a.Tipo+"</p></div>" +
                                      "<div class='col-md-6'><p id='direccion'>"+r.Direccion+"</p></div>" +
                                      "</div>" +
                                      "<div class='row'>" +
                                      "<div class='col-md-6'><p id='fecha'>" + String.Format("{0:d/M/yyyy}", a.Fecha) + "," + a.Horario.ToString() + "</p></div>" +
                                    "<div class='col-md-6'><p id='tel'>"+r.Telefono+"</p></div>" +
                                  "</div>" +
                                   "<div class='row'>" +
                                      "<div class='col-md-6'><p id='descripcion'>"+a.Descripcion+"</p></div>" +
                                      "<div class='col-md-6'><p id='mail'>"+r.Email+"</p></div>" +
                                      "</div>"+
                                      "</div>"+
                                      "<button type='button' class='btn'>APUNTARSE</button>";
                sb.Append(estrcuctura);
            

            divActividad.Text = sb.ToString();

        }
        protected void Alert(string message)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "errorAlert", "alert('" + message + "');", true);
        }

    }
}