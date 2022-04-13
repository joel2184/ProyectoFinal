using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Modelo
{
    public class Actividad
    {
        string nombre_actividad;
        string tipo_actividad;
        string direccion;
        string descripcion;
        DateTime horario;
        int plazas_disponibles;
        Residencia residencia;
        List<Voluntario> voluntarios;

        public Actividad()
        {
            voluntarios = new List<Voluntario>();
        }

        public Actividad(string nombre_actividad, string tipo_actividad, string direccion, DateTime horario, 
            int plazas_disponibles, string descripcion, Residencia residencia, List<Voluntario> voluntarios)
        {
            this.nombre_actividad = nombre_actividad;
            this.tipo_actividad = tipo_actividad;
            this.direccion = direccion;
            this.horario = horario;
            this.plazas_disponibles = plazas_disponibles;
            this.descripcion = descripcion;
            this.residencia = residencia;
            this.voluntarios = voluntarios;
        }

        public string Nombre_actividad
        {
            get { return nombre_actividad; }
            set { nombre_actividad = value; }
        }
        public string Tipo_actividad
        {
            get { return tipo_actividad; }
            set { tipo_actividad = value; }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public DateTime Horario
        {
            get { return horario; }
            set { horario = value; }
        }

        public int Plazas_disponibles
        {
            get { return plazas_disponibles; }
            set { plazas_disponibles = value; }
        }

        public Residencia Residencia
        {
            get { return residencia; }
            set { residencia = value; }
        }
        public List<Voluntario> Voluntarios
        {
            get { return voluntarios; }
            set { voluntarios = value; }
        }

        public void addVoluntario(Voluntario v) {
            voluntarios.Add(v);
        }
    }
}