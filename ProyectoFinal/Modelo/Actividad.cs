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
        TimeSpan horario;
        DateTime fecha;
        string descripcion;
        int residencia;
        int id_actividad;
        

        public Actividad()
        {            
        }

        public Actividad(string nom, string tipo, TimeSpan horario,DateTime fecha, string descripcion, int residencia, int id_act)
        {
            this.nombre = nom;
            this.tipo = tipo;
            this.horario = horario;
            this.fecha = fecha;
            this.descripcion = descripcion;
            this.residencia = residencia;
            this.id_actividad = id_act;
        }

        public Actividad(string nom, string tipo, TimeSpan horario, DateTime fecha, string descripcion, int residencia)
        {
            this.nombre = nom;
            this.tipo = tipo;
            this.horario = horario;
            this.fecha = fecha;
            this.descripcion = descripcion;
            this.residencia = residencia;
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

        public TimeSpan Horario
        {
            get { return horario; }
            set { horario = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public int Residencia
        {
            get { return residencia; }
            set { residencia = value; }
        }
        public int Id_actividad
        {
            get { return id_actividad; }
            set { id_actividad = value; }
        }

        public String toString()
        {
            return  nombre + " el dia " + String.Format("{0:d/M/yyyy}", fecha) + " a las " + horario;
        }
    }
}