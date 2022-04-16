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
                DALs.DALActividad DALActividad = new DALs.DALActividad();
                listActividades = DALActividad.SelectAll();
                string estrcuctura = @"<div class='post'>
                                        <a href='#' class='news-card__card-link'></a>
                                        <img src = 'https://images.pexels.com/photos/206660/pexels-photo-206660.jpeg?auto=compress&cs=tinysrgb&h=750&w=1260' alt = '' class='news-card__image'>
                                        <div class='news-card__text-wrapper'>
                                          <h2 class='news-card__title'>Amazing Fifth Title</h2>
                                          <div class='news-card__post-date'>Jan 29, 2018</div>
                                          <div class='news-card__details-wrapper'>
                                            <p class='news-card__excerpt'>Lorem ipsum dolor sit amet consectetur adipisicing elit.Est pariatur nemo tempore repellat? Ullam sed officia iure architecto deserunt distinctio&hellip;</p>
                                            <a href = '#' class='news-card__read-more'>Read more<i class='fas fa-long-arrow-alt-right'></i></a>
                                          </div>
                                        </div>
                                      </div>";
                StringBuilder sb = new StringBuilder();

                //Table start.
                //sb.Append(estrcuctura);

                //Adding HeaderRow.

                foreach (Actividad a in listActividades)
                {
                    estrcuctura = "<div class='post'>" +
                                        "<a href='#' class='news-card__card-link'></a>" +
                                        "<img src = 'https://images.pexels.com/photos/206660/pexels-photo-206660.jpeg?auto=compress&cs=tinysrgb&h=750&w=1260' alt = '' class='news-card__image'>" +
                                        "<div class='news-card__text-wrapper'>" +
                                          "<h2 class='news-card__title'>" + a.Nombre + "</h2>" +
                                          "<div class='news-card__post-date'>" + a.Horario.ToString() + "</div>" +
                                          "<div class='news-card__details-wrapper'>" +
                                          "<p class='news-card__excerpt'>" + a.Descripcion + "</p>" +
                                            "<a href = '#' class='news-card__read-more'>Read more<i class='fas fa-long-arrow-alt-right'></i></a>" +
                                          "</div>" +
                                        "</div>" +
                                      "</div>";
                    sb.Append(estrcuctura);
                }

                divCards.Text = sb.ToString();

            }
        }
    }
}