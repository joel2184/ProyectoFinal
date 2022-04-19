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
                buscarActividades();

            }
        }
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
        protected void RadioButtonEntretenimiento_CheckedChanged(object sender, EventArgs e)
        {
            OpcionFiltro();
        }
        protected void RadioButtonEducativa_CheckedChanged(object sender, EventArgs e)
        {
            OpcionFiltro();
        }

        protected void OpcionFiltro()
        {
            if (TODAS.Checked)
            {
                buscarActividades();
            }
            else if (OCIO.Checked)
            {
                buscarActividades("Ocio");
            }
            else if (PASEO.Checked)
            {
                buscarActividades("Paseo");
            }
            else if (ENTRETENIMIENTO.Checked)
            {
                buscarActividades("Entretenimiento");

            }
            else if (EDUCATIVA.Checked)
            {
                buscarActividades("Educativa");
            }
        }

        public void buscarActividades()
        {

            DALs.DALActividad DALActividad = new DALs.DALActividad();
            listActividades = DALActividad.SelectAll();
            StringBuilder sb = new StringBuilder();
            string estrcuctura = "";


            foreach (Actividad a in listActividades)
            {
                estrcuctura = "<div class='news-card'>" +
                                    "<a href='#' class='news-card__card-link'></a>" +
                                    "<img src='https://images.pexels.com/photos/127513/pexels-photo-127513.jpeg?auto=compress&cs=tinysrgb&h=750&w=1260' alt='' class='news-card__image'>" +
                                    "<div class='news-card__text-wrapper'>" +
                                      "<h2 class='news-card__title'>" + a.Nombre + "</h2>" +
                                      "<div class='news-card__post-date'>" + String.Format("{0:d/M/yyyy}", a.Fecha) + "," + a.Horario.ToString() + "</div>" +
                                      "<div class='news-card__details-wrapper'>" +
                                      "<p class='news-card__excerpt'>" + a.Descripcion + "</p>" +
                                        "<a href = '#' class='btn'>Apúnate<i class='fas fa-long-arrow-alt-right'></i></a>" +
                                      "</div>" +
                                    "</div>" +
                                  "</div>";
                sb.Append(estrcuctura);
            }

            divCards.Text = sb.ToString();

        }
        public void buscarActividades(string tipoActividad)
        {
            DALs.DALActividad DALActividad = new DALs.DALActividad();
            listActividades = DALActividad.SelectTipo(tipoActividad);
            StringBuilder sb = new StringBuilder();
            string estrcuctura = "";


            foreach (Actividad a in listActividades)
            {
                estrcuctura = "<div class='news-card'>" +
                                    "<a href='#' class='news-card__card-link'></a>" +
                                    "<img src='https://images.pexels.com/photos/127513/pexels-photo-127513.jpeg?auto=compress&cs=tinysrgb&h=750&w=1260' alt='' class='news-card__image'>" +
                                    "<div class='news-card__text-wrapper'>" +
                                      "<h2 class='news-card__title'>" + a.Nombre + "</h2>" +
                                      "<div class='news-card__post-date'>" + String.Format("{0:d/M/yyyy}", a.Fecha) + "," + a.Horario.ToString() + "</div>" +
                                      "<div class='news-card__details-wrapper'>" +
                                      "<p class='news-card__excerpt'>" + a.Descripcion + "</p>" +
                                        "<a href = '#' class='btn'>Apúnate<i class='fas fa-long-arrow-alt-right'></i></a>" +
                                      "</div>" +
                                    "</div>" +
                                  "</div>";
                sb.Append(estrcuctura);
            }

            divCards.Text = sb.ToString();

        }
    }
}