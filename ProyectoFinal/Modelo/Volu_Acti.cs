using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Modelo
{
    public class Volu_Acti
    {
        Voluntario voluntario;
        Actividad actividad;

        public Volu_Acti(Voluntario volu, Actividad acti)
        {
            voluntario = volu;
            actividad = acti;
        }

        public Voluntario Voluntario
        {
            get { return voluntario; }
            set { voluntario = value; }
        }

        public Actividad Actividad
        {
            get { return actividad; }
            set { actividad = value; }
        }

        public String toString()
        {
            return voluntario.Dni + " " + voluntario.Nombre + " || " + actividad.Id_actividad + " "
                + actividad.Nombre ;
        }
    }
}