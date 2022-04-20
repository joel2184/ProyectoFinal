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
        string email;
        string password;
        string telefono;
        decimal latitud;
        decimal longitud;

        int id_Residencia;

        public Residencia()
        {
        }

        public Residencia(string nombre, string direccion, string mail, string telefono,string pass, int id_Residencia, decimal lat, decimal longi)
        {
            this.nombre = nombre;
            this.direccion = direccion;
            this.email = mail;
            this.telefono = telefono;
            this.password = pass;
            this.id_Residencia = id_Residencia;
            this.latitud = lat;
            this.longitud = longi;
        }

        public Residencia(string nombre, string direccion, string mail, string telefono, string pass)
        {
            this.nombre = nombre;
            this.direccion = direccion;
            this.email = mail;
            this.telefono = telefono;
            this.password = pass;           

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
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public int Id_Residencia
        {
            get { return id_Residencia; }
            set { id_Residencia = value; }
        }
        public decimal Latitud
        {
            get { return latitud; }
            set { latitud = value; }
        }
        public decimal Longitud
        {
            get { return longitud; }
            set { longitud = value; }
        }

    }
}