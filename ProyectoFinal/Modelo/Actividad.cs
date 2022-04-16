using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Modelo
{
    public class Actividad
    {
        string nombre;
        string tipo;
        int horario;
        string descripcion;
        int residencia;
        int id_actividad;
        

        public Actividad()
        {            
        }

        public Actividad(string nom, string tipo, int horario, string descripcion, int residencia, int id_act)
        {
            this.nombre = nom;
            this.tipo = tipo;
            this.horario = horario;
            this.descripcion = descripcion;
            this.residencia = residencia;
            this.id_actividad = id_act;
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public int Horario
        {
            get { return horario; }
            set { horario = value; }
        }       

        public int Residencia
        {
            get { return residencia; }
            set { residencia = value; }
        }
    }
}