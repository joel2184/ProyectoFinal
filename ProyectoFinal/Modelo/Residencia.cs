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
        int telefono;

        int id_Residencia;

        public Residencia()
        {
        }

        public Residencia(string nombre, string direccion, string mail, int telefono,string pass, int id_Residencia)
        {
            this.nombre = nombre;
            this.direccion = direccion;
            this.email = mail;
            this.telefono = telefono;
            this.password = pass;
            this.id_Residencia = id_Residencia;
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public int Telefono
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
    }
}