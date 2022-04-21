using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Modelo
{
    public class Voluntario
    {
        string dni;
        string nombre;
        string telefono;
        string email;
        string horario;
        string password;

        int id_Voluntario;

        public Voluntario() { }

        public Voluntario(string dn,  string nom, string tel, string mail, string horari,string pass, int id_Voluntario)
        {
            this.dni = dn;
            this.nombre = nom;
            this.telefono = tel;
            this.email = mail;
            this.horario = horari;
            this.password = pass;
            this.id_Voluntario = id_Voluntario;
        }

        public Voluntario(string dn, string nom, string tel, string mail, string horari, string pass)
        {
            this.dni = dn;
            this.nombre = nom;
            this.telefono = tel;
            this.email = mail;
            this.horario = horari;
            this.password = pass;

        }

        public string Dni
        {
            get { return dni; }
            set { dni = value; }
        }
        public string Nombre {
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

        public string Horario
        {
            get { return horario; }
            set { horario = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public int Id_Voluntario
        {
            get { return id_Voluntario; }
            set { id_Voluntario = value; }
        }

        public String toString()
        {
            return "APUNTADO "+dni +" "+ nombre;
        }
    }
}