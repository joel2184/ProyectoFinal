using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Modelo
{
    public class Residencia
    {
        string nombre;
        string direccion;
        string mail;
        string telefono;

        int id_Residencia;

        public Residencia()
        {
        }

        public Residencia(string nombre, string direccion, string mail, string telefono, int id_Residencia)
        {
            this.nombre = nombre;
            this.direccion = direccion;
            this.mail = mail;
            this.telefono = telefono;
            this.id_Residencia = id_Residencia;
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }
        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
    }
}