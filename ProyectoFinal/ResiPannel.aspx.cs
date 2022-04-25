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
        private List<Actividad> listaDatasource2 = new List<Actividad>();
        protected void Page_Load(object sender, EventArgs e)
        {
            DALVoluntarioActividad dalboth = new DALVoluntarioActividad();
            list = dalboth.SelectAll();


            divNewAct.Visible = false;
            divListVol.Visible = false;
            divListAct.Visible = false;

            if (Session["Residencia"] != null)
            {
                //Buscamos la residencia que es y mostramos info
                DALResidencia dalresi = new DALResidencia();
                residenciaIniciada = dalresi.FindById((int)Session["Residencia"]);
                if (residenciaIniciada != null)
                {
                    lblTitle.Text = "Residencia "+residenciaIniciada.Nombre;

                }
                
            }
            else
            {
                //En caso de no haber iniciado sesion com residecia te redirige
                Response.Redirect("Default.aspx");
            }

            btnActForm.BackColor = Color.Gray;
            btnVoluList.BackColor = Color.Gray;
            btnActiList.BackColor = Color.Gray;
            
        }


        //Click en añadir actividad
        protected void btnActForm_Click(object sender, EventArgs e)
        {
            Show("addActi");
        }

        //Click en ver voluntarios de cada actividad
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

        //Click en mostar actividades
        protected void btnActiList_Click(object sender, EventArgs e)
        {

            
            List<Actividad> list;
            Show("Actividades");
            
            DALActividad dalactividad = new DALActividad();
            list = dalactividad.SelectAll();

            foreach (Actividad item in list)
            {
                if (item.Residencia == (int)Session["Residencia"])
                {
                    listaDatasource2.Add(item);
                    
                }
            }
        }

        //Click en submit (añadir actividad)
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


            LinkButton b = (LinkButton)sender;
            Console.WriteLine(b.ID);
            string eliminar = b.Attributes["key"].ToString();
            
            
            DALActividad dalacti = new DALActividad();
            
             
            dalacti.DeleteActividad(Convert.ToInt32(eliminar));
            btnActiList_Click(sender, e);    
            
        }

        //Metodo para mostar el panel correspondiente
        protected void Show(String what)
        {
            switch (what)
            {
                case "VoluApuntados":                    
                    divListVol.Visible = true;
                    btnVoluList.BackColor = Color.FromArgb(37, 150, 190);
          
                    break;
                case "Actividades":                    
                    divListAct.Visible = true;
                    btnActiList.BackColor = Color.FromArgb(37, 150, 190);
                    break;
                case "addActi":
                    divNewAct.Visible = true;                    
                    btnActForm.BackColor = Color.FromArgb(37, 150, 190);
                    
                    break;
            }
        }

        //Método para cargar datos de ListView
        protected void TableListView_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ActividadVoluntario av = (ActividadVoluntario)e.Item.DataItem;

                ((HtmlTableCell)e.Item.FindControl("nombreActividad")).InnerText = av.Act.Nombre;
                ((HtmlTableCell)e.Item.FindControl("nombreVoluntario")).InnerText = av.Vol.Nombre;

            }
        }
        protected void TableListView2_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                Actividad a = (Actividad)e.Item.DataItem;

                ((HtmlTableCell)e.Item.FindControl("nombreA")).InnerText = a.Nombre;
                ((HtmlTableCell)e.Item.FindControl("tipoA")).InnerText = a.Tipo;
                ((HtmlTableCell)e.Item.FindControl("fechaA")).InnerText = String.Format("{0:d/M/yyyy}", a.Fecha);
                ((HtmlTableCell)e.Item.FindControl("horaA")).InnerText = a.Horario.ToString();
                ((LinkButton)e.Item.FindControl("btnEliminar")).Attributes.Add("key", a.Id_actividad.ToString());
                //((Button)e.Item.FindControl("Button1"))
                /*
                 Button b = ((Button)e.Item.FindControl("btnEliminar"));
                 b.ID = a.Id_actividad.ToString();
                b.Click+= new EventHandler(btnRemoveActi_Click);
                */
            }
        }

        //Método para cargar datos de ListView
        protected override void OnPreRender(EventArgs e)
        {
            
            base.OnPreRender(e);
            TableListView.DataSource = listaDatasource;
            TableListView.DataBind();

            ListView2.DataSource = listaDatasource2;
            ListView2.DataBind();
        }

        //Generar alertas
        protected void Alert(string message)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "errorAlert", "alert('" + message + "');", true);
        }


    }
}