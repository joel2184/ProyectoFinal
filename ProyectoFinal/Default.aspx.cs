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
    public partial class _Default : Page
    {
        
        List<Actividad> listActividades;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //Búsqueda de todas las actividades
                buscarActividades();
            }
            
            
            //En caso de algún tipo de error
            if (Session["Error"].ToString() == "True")
            {
                Alert("ALGO HA IDO MAL || Asegúrate de no dejar campos en blanco");
                Session["Error"] = false;
            }
        }

        //Métodos que se ejecutan cuando se cambia la opción de filtro
        protected void RadioButtonTodas_CheckedChanged(object sender, EventArgs e)
        {
            OpcionFiltro();
        }
        protected void RadioButtonOcio_CheckedChanged(object sender, EventArgs e)
        {
            OpcionFiltro();
        }
        protected void RadioButtonPaseo_CheckedChanged(object sender, EventArgs e)
        {
            OpcionFiltro();
        }
        protected void RadioButtonTaller_CheckedChanged(object sender, EventArgs e)
        {
            OpcionFiltro();
        }
        protected void RadioButtonEducativa_CheckedChanged(object sender, EventArgs e)
        {
            OpcionFiltro();
        }
        protected void RadioButtonCine_CheckedChanged(object sender, EventArgs e)
        {
            OpcionFiltro();
        }

        //Filtar por tipo de actividad y cambiar estilos de algunos controles
        protected void OpcionFiltro()
        {
            if (TODAS.Checked)
            {
                buscarActividades();
                lblTODAS.Attributes.CssStyle.Add("background", "#46a2fd");
                lblTODAS.Attributes.CssStyle.Add("color", "#fff");

                lblPASEO.Attributes.CssStyle.Clear();
                lblOCIO.Attributes.CssStyle.Clear();
                lblTALLER.Attributes.CssStyle.Clear();
                lblEDUCATIVA.Attributes.CssStyle.Clear();
                lblCINE.Attributes.CssStyle.Clear();
            }
            else if (OCIO.Checked)
            {
                buscarActividades("Ocio");
                lblOCIO.Attributes.CssStyle.Add("background", "#46a2fd");
                lblOCIO.Attributes.CssStyle.Add("color", "#fff");

                lblPASEO.Attributes.CssStyle.Clear();
                lblTODAS.Attributes.CssStyle.Clear();
                lblTALLER.Attributes.CssStyle.Clear();
                lblEDUCATIVA.Attributes.CssStyle.Clear();
                lblCINE.Attributes.CssStyle.Clear();

            }
            else if (PASEO.Checked)
            {
                buscarActividades("Paseo");

                lblPASEO.Attributes.CssStyle.Add("background", "#46a2fd");
                lblPASEO.Attributes.CssStyle.Add("color", "#fff");

                lblTODAS.Attributes.CssStyle.Clear();
                lblOCIO.Attributes.CssStyle.Clear();
                lblTALLER.Attributes.CssStyle.Clear();
                lblEDUCATIVA.Attributes.CssStyle.Clear();
                lblCINE.Attributes.CssStyle.Clear();
            }
            else if (TALLER.Checked)
            {
                buscarActividades("Taller");
                lblTALLER.Attributes.CssStyle.Add("background", "#46a2fd");
                lblTALLER.Attributes.CssStyle.Add("color", "#fff");

                lblPASEO.Attributes.CssStyle.Clear();
                lblOCIO.Attributes.CssStyle.Clear();
                lblTODAS.Attributes.CssStyle.Clear();
                lblEDUCATIVA.Attributes.CssStyle.Clear();
                lblCINE.Attributes.CssStyle.Clear();
            }
            else if (EDUCATIVA.Checked)
            {
                buscarActividades("Educativa");
                lblEDUCATIVA.Attributes.CssStyle.Add("background", "#46a2fd");
                lblEDUCATIVA.Attributes.CssStyle.Add("color", "#fff");

                lblPASEO.Attributes.CssStyle.Clear();
                lblOCIO.Attributes.CssStyle.Clear();
                lblTODAS.Attributes.CssStyle.Clear();
                lblTALLER.Attributes.CssStyle.Clear();
                lblCINE.Attributes.CssStyle.Clear();
            }
            else if (CINE.Checked)
            {
                buscarActividades("Cine");
                lblCINE.Attributes.CssStyle.Add("background", "#46a2fd");
                lblCINE .Attributes.CssStyle.Add("color", "#fff");

                lblPASEO.Attributes.CssStyle.Clear();
                lblOCIO.Attributes.CssStyle.Clear();
                lblTODAS.Attributes.CssStyle.Clear();
                lblTALLER.Attributes.CssStyle.Clear();
                lblEDUCATIVA.Attributes.CssStyle.Clear();

            }
        }

        //Método que muestra todas las actividades
        public void buscarActividades()
        {
            DALActividad DALActividad = new DALActividad();
            listActividades = DALActividad.SelectAll();
            StringBuilder sb = new StringBuilder();
            string estrcuctura = "";

            //En caso de no haber iniciado sesion no tienes acceso a las activiadades
            if (Session["Voluntario"] == null)
            {

                foreach (Actividad a in listActividades)
                {
                    Residencia r = new Residencia();
                    DALResidencia dalR = new DALResidencia();
                    r = dalR.FindById(a.Residencia);
                    string img = "Images/" + a.Tipo.ToString() + ".jpg";
                    estrcuctura = "<div class='news-card'>" +
                                        "<a data-bs-toggle='modal' data-bs-target='#signUpModal' data-bs-whatever='@mdo' class='news-card__card-link'></a>" +
                                        "<img src='" + img + "' alt='' class='news-card__image'>" +
                                        "<div class='news-card__text-wrapper'>" +
                                          "<h2 class='news-card__title'>" + a.Nombre + "</h2>" +
                                          "<div class='news-card__post-date'>" + String.Format("{0:d/M/yyyy}", a.Fecha) + "," + a.Horario.ToString() + "</div>" +
                                          "<div class='news-card__post-date'>" + r.Direccion + "</div>" +
                                          "<div class='news-card__details-wrapper'>" +
                                          "<p class='news-card__excerpt'>" + a.Descripcion + "</p>" +
                                            "<a style='text-decoration:none' href = '#'   data-bs-toggle='modal' data-bs-target='#loginModal' data-bs-whatever='@mdo' class='btn2'>Apúnate<i class='fas fa-long-arrow-alt-right'></i></a>" +
                                          "</div>" +
                                        "</div>" +
                                      "</div>";
                    sb.Append(estrcuctura);
                }

            }
            else {

                foreach (Actividad a in listActividades)
                {
                    Residencia r = new Residencia();
                    DALResidencia dalR = new DALResidencia();
                    r = dalR.FindById(a.Residencia);
                    string img = "Images/" + a.Tipo.ToString() + ".jpg";
                    estrcuctura = "<div class='news-card'>" +
                                        "<a href='Contact.aspx?id=" + a.Id_actividad + "' class='news-card__card-link'></a>" +
                                        "<img src='" + img + "' alt='' class='news-card__image'>" +
                                        "<div class='news-card__text-wrapper'>" +
                                          "<h2 class='news-card__title'>" + a.Nombre + "</h2>" +
                                          "<div class='news-card__post-date'>" + String.Format("{0:d/M/yyyy}", a.Fecha) + "," + a.Horario.ToString() + "</div>" +
                                          "<div class='news-card__post-date'>" + r.Direccion + "</div>" +
                                          "<div class='news-card__details-wrapper'>" +
                                          "<p class='news-card__excerpt'>" + a.Descripcion + "</p>" +
                                            "<a style='text-decoration:none' href = '#' class='btn2'>Apúnate<i class='fas fa-long-arrow-alt-right'></i></a>" +
                                          "</div>" +
                                        "</div>" +
                                      "</div>";
                    sb.Append(estrcuctura);
                }

            }
            divCards.Text = sb.ToString();
        }

        //Método que muestra actividades filtradas por el tipo
        public void buscarActividades(string tipoActividad)
        {
            DALs.DALActividad DALActividad = new DALs.DALActividad();
            listActividades = DALActividad.SelectTipo(tipoActividad);
            StringBuilder sb = new StringBuilder();
            string estrcuctura = "";

            //En caso de no haber iniciado sesion no tienes acceso a las activiadades
            if (Session["Voluntario"] == null)
            {

                foreach (Actividad a in listActividades)
                {
                    Residencia r = new Residencia();
                    DALResidencia dalR = new DALResidencia();
                    r = dalR.FindById(a.Residencia);
                    string img = "Images/" + a.Tipo.ToString() + ".jpg";
                    estrcuctura = "<div class='news-card'>" +
                                        "<a data-bs-toggle='modal' data-bs-target='#signUpModal' data-bs-whatever='@mdo' class='news-card__card-link'></a>" +
                                        "<img src='" + img + "' alt='' class='news-card__image'>" +
                                        "<div class='news-card__text-wrapper'>" +
                                          "<h2 class='news-card__title'>" + a.Nombre + "</h2>" +
                                          "<div class='news-card__post-date'>" + String.Format("{0:d/M/yyyy}", a.Fecha) + "," + a.Horario.ToString() + "</div>" +
                                          "<div class='news-card__post-date'>" + r.Direccion + "</div>" +
                                          "<div class='news-card__details-wrapper'>" +
                                          "<p class='news-card__excerpt'>" + a.Descripcion + "</p>" +
                                            "<a style='text-decoration:none' href = '#'   data-bs-toggle='modal' data-bs-target='#loginModal' data-bs-whatever='@mdo' class='btn2'>Apúnate<i class='fas fa-long-arrow-alt-right'></i></a>" +
                                          "</div>" +
                                        "</div>" +
                                      "</div>";
                    sb.Append(estrcuctura);
                }

            }
            else
            {
                foreach (Actividad a in listActividades)
                {
                    Residencia r = new Residencia();
                    DALResidencia dalR = new DALResidencia();
                    r = dalR.FindById(a.Residencia);
                    string img = "Images/" + a.Tipo.ToString() + ".jpg";
                    estrcuctura = "<div class='news-card'>" +
                                        "<a href='Contact.aspx?id=" + a.Id_actividad + "' class='news-card__card-link'></a>" +
                                        "<img src='" + img + "' alt='' class='news-card__image'>" +
                                        "<div class='news-card__text-wrapper'>" +
                                          "<h2 class='news-card__title'>" + a.Nombre + "</h2>" +
                                          "<div class='news-card__post-date'>" + String.Format("{0:d/M/yyyy}", a.Fecha) + "," + a.Horario.ToString() + "</div>" +
                                          "<div class='news-card__post-date'>" + r.Direccion + "</div>" +
                                          "<div class='news-card__details-wrapper'>" +
                                          "<p class='news-card__excerpt'>" + a.Descripcion + "</p>" +
                                            "<a style='text-decoration:none' href = '#' class='btn2'>Apúnate<i class='fas fa-long-arrow-alt-right'></i></a>" +
                                          "</div>" +
                                        "</div>" +
                                      "</div>";
                    sb.Append(estrcuctura);
                }

            }
            divCards.Text = sb.ToString();

        }

        //Método para generar alerta
        protected void Alert(string message)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "errorAlert", "alert('" + message + "');", true);

        }

    }
}