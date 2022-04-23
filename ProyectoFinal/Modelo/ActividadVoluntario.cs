using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Modelo
{
    public class ActividadVoluntario
    {
        Voluntario vol;
        Actividad act;

        public ActividadVoluntario(Voluntario vol, Actividad act)
        {
            this.vol = vol;
            this.act = act;
        }

        public Voluntario Vol {
            get { return vol; }
            set { vol = value; }
        }
        public Actividad Act
        {
            get { return act; }
            set { act = value; }
        }
    }
}