using ProyectoFinal.DALs;
using ProyectoFinal.Modelo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ProyectoFinal
{
    public partial class ResiPannel : Page
    {
        Residencia residenciaIniciada = null;
        Voluntario volu;
        Actividad acti;

        private List<int> list = new List<int>();
        private List<ActividadVoluntario> listaDatasource = new List<ActividadVoluntario>(); 
        protected void Page_Load(object sender, EventArgs e)
        {
            DALVoluntarioActividad dalboth = new DALVoluntarioActividad();
            list = dalboth.SelectAll();


            divNewAct.Visible = false;
            divListVol.Visible = false;
            divListAct.Visible = false;

                       

            if (Session["Residencia"] != null)
            {
                DALResidencia dalresi = new DALResidencia();
                residenciaIniciada = dalresi.FindById((int)Session["Residencia"]);
                if (residenciaIniciada != null)
                {
                    lblTitle.Text = "Residencia "+residenciaIniciada.Nombre;

                }
                
            }
            else
            {
                Response.Redirect("Default.aspx");
            }

            btnActForm.BackColor = Color.Gray;
            btnVoluList.BackColor = Color.Gray;
            btnActiList.BackColor = Color.Gray;
            btnRemove.BackColor = Color.Red;
        }
        // Tener en cuenta que es un método 'override'



        protected void btnActForm_Click(object sender, EventArgs e)
        {
            Show("addActi");
        }
        protected void btnVoluList_Click(object sender, EventArgs e)
        {
            //lbVolu.Items.Clear();
            List<int> list = new List<int>();
            Show("VoluApuntados");
            DALVoluntarioActividad dalboth = new DALVoluntarioActividad();
            DALActividad dalactividad = new DALActividad();
            DALVoluntario dalvoluntario = new DALVoluntario();
            list = dalboth.SelectAll();

            for (int i = 0; i < list.Count(); i= i+2)
            {
                volu = dalvoluntario.SelectbyID(list[i]);
                acti = dalactividad.SelectbyID(list[i + 1]);
                if (acti.Residencia == (int)Session["Residencia"])
                {
                    ActividadVoluntario av = new ActividadVoluntario(volu, acti);
                    listaDatasource.Add(av);
                }

                

            }
        }

        protected void btnActiList_Click(object sender, EventArgs e)
        {
            lbActi.Items.Clear();
            List<Actividad> list;
            Show("Actividades");
            
            DALActividad dalactividad = new DALActividad();
            list = dalactividad.SelectAll();

            foreach (Actividad item in list)
            {
                if (item.Residencia == (int)Session["Residencia"])
                {
                    lbActi.Items.Add(item.toString());
                }
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {           
            if (txtNom.Text.Length != 0 && txtHor.Value.Length != 0 && txtFecha.Value.Length != 0 && txtDesc.Value.Length != 0)
            {
                DALActividad newActivity = new DALActividad();
                newActivity.InsertActividad(new Actividad(txtNom.Text, ddTipo.SelectedValue.ToString(), TimeSpan.Parse(txtHor.Value), Convert.ToDateTime(txtFecha.Value), txtDesc.Value, (int)Session["Residencia"]));
               
            }                
            else
                Response.Redirect("Default.aspx");


        }
        protected void btnRemoveActi_Click(object sender, EventArgs e)
        {
            // sabiendo que los primero caracteres del item seleccionado en el listbox son el id
            // hago un bucle para que pille el id entero
            DALActividad dalacti = new DALActividad();
            string actividad = lbActi.SelectedItem.ToString();
            string charId = "";
            int i = 0;
            while (char.IsNumber(actividad,i))
            {
                charId = charId + actividad[i];
                i++;
            }
             
            dalacti.DeleteActividad(Convert.ToInt32(charId));
            btnActiList_Click(sender, e);           
        }
        protected void Show(String what)
        {
            switch (what)
            {
                case "VoluApuntados":                    
                    divListVol.Visible = true;
                    btnVoluList.BackColor = Color.Green;
          
                    break;
                case "Actividades":                    
                    divListAct.Visible = true;
                    btnActiList.BackColor = Color.Green;
                    break;
                case "addActi":
                    divNewAct.Visible = true;                    
                    btnActForm.BackColor = Color.Green;
                    
                    break;
            }
        }
        protected void TableListView_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ActividadVoluntario av = (ActividadVoluntario)e.Item.DataItem;

                ((HtmlTableCell)e.Item.FindControl("nombreActividad")).InnerText = av.Act.Nombre;
                ((HtmlTableCell)e.Item.FindControl("nombreVoluntario")).InnerText = av.Vol.Nombre;
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            TableListView.DataSource = listaDatasource;
            TableListView.DataBind();
        }


        protected void Alert(string message)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "errorAlert", "alert('" + message + "');", true);
        }


    }
}