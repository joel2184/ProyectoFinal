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
    public partial class Mapa : System.Web.UI.Page
    {
        List<Residencia> listResis;
        protected void Page_Load(object sender, EventArgs e)
        {
            DALResidencia dalresi = new DALResidencia();
            listResis = dalresi.SelectAll();
            foreach (Residencia item in listResis)
            {
                
            }
        }
    }
}