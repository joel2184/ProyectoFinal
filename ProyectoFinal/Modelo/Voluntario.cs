using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Modelo
{
    public class Voluntario
    {
        string nombre;
        string telefono;
        string mail;
        string preferencias;
        string disponibilidad;

        int id_Voluntario;

        public Voluntario() { }

        public Voluntario(string nombre, string telefono, string mail, string preferencias, string disponibilidad, int id_Voluntario)
        {
            this.nombre = nombre;
            this.telefono = telefono;
            this.mail = mail;
            this.preferencias = preferencias;
            this.disponibilidad = disponibilidad;
            this.id_Voluntario = id_Voluntario;
        }

        public string Nombre {
            get { return nombre; } 
            set { nombre = value; }  
        }
    }
}