using ProyectoFinal.DALs;
using ProyectoFinal.Modelo;
using System;
using System.Text;
using System.Web.UI;

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
                //Si no has hecho logIn con un voluntario te redirige
                Response.Redirect("Default.aspx");

            }


            if (!this.IsPostBack)
            {
                //Cargar actividad seleccionada
                int id = Convert.ToInt32(Request.QueryString["id"]);


                DALActividad dalA = new DALActividad();
                actividadActual = dalA.SelectbyID(id);
                idActividad = id;
                mostrarActividad(actividadActual);
            }
        }

        //Método para mostarar la actividad seleccionada
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
                estrcuctura = "<div class='container'><div class='row g-3'><div class='col-md-6 col-lg-4 col-xl-3'><h2>" + a.Nombre + "</h2><p>" + String.Format("{0:d/M/yyyy}", a.Fecha) + ", " + a.Horario.ToString() + "</p><p>" + a.Descripcion + "</p></div><div class='col-md-6 col-lg-4 col-xl-3'><h2>" + r.Nombre +
                    "</h2><p>" + r.Direccion + "</p><p>" + r.Email + "</p><p>" + r.Telefono + "</p></div><div class='col'><img src ='" + img + "' alt = 'Italian Trulli' style = 'height: 100%; width:100%'>" +
                    "</div></div></div>";


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
                estrcuctura = "<div class='container'><div class='row g-3'><div class='col-md-6 col-lg-4 col-xl-3'><h2>" + a.Nombre + "</h2><p>" + String.Format("{0:d/M/yyyy}", a.Fecha) + ", " + a.Horario.ToString() + "</p><p>" + a.Descripcion + "</p></div><div class='col-md-6 col-lg-4 col-xl-3'><h2>" + r.Nombre +
                    "</h2><p>" + r.Direccion + "</p><p>" + r.Email + "</p><p>" + r.Telefono + "</p></div><div class='col'><img src ='" + img + "' alt = 'Italian Trulli' style = 'height: 100%; width:100%'>" +
                    "</div></div></div>";
                sb.Append(estrcuctura);
                btnApuntarse.Visible = false;
                Apuntado.Visible = true;
                btnCancelar.Visible = true;
                divActividad.Text = sb.ToString();

            }

        }

        //Método para apuntarse a la actividad
        public void btnApuntarse_Click(object sender, EventArgs e)
        {

            DALVoluntarioActividad dalVolAct = new DALVoluntarioActividad();
            dalVolAct.InsertActividadVoluntario(idActividad, (int)Session["Voluntario"]);
            Response.Redirect(Request.RawUrl);
        }
        public void btnCancelar_Click(object sender, EventArgs e)
        {
            //Método para cancelar el voluntariado
            DALVoluntarioActividad dalVolAct = new DALVoluntarioActividad();
            dalVolAct.DeleteActividadVoluntario(idActividad, (int)Session["Voluntario"]);
            Response.Redirect(Request.RawUrl);

        }


    }
}