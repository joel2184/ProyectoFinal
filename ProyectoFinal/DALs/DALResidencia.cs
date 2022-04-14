﻿using ProyectoFinal.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProyectoFinal.DALs
{
    public class DALResidencia
    {
        Residencia temp;
        DBConnect cnx;

        public DALResidencia()
        {
            cnx = new DBConnect();
        }

        public Residencia FindUser(string email, string password)
        {
            try
            {
                cnx.OpenConection();

                string sql = @"
                SELECT * FROM Residencia WHERE email = @mail AND contrasena = @pass";

                SqlCommand cmd = new SqlCommand(sql, cnx.conexion);
                SqlParameter mail = new SqlParameter("@mail", System.Data.SqlDbType.NVarChar, 50);
                mail.Value = email;
                cmd.Parameters.Add(mail);
                SqlParameter pass = new SqlParameter("@pass", System.Data.SqlDbType.NVarChar, 50);
                pass.Value = password;
                cmd.Parameters.Add(pass);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    temp = new Residencia(Convert.ToString(dr[0]), Convert.ToString(dr[1]), Convert.ToString(dr[2]), Convert.ToInt32(dr[3]), Convert.ToString(dr[4]), Convert.ToInt32(dr[3]));

                }



                dr.Close();
                cnx.CloseConnection();
                return temp;
            }
            catch (Exception ee)
            {

                Console.WriteLine("No se ha podido encontrar la Residencia " + ee);
                return null;
            }
        }
        public Residencia InsertUser(Residencia r)
        {
            try
            {
                cnx.OpenConection();

                String sql = "INSERT INTO Residencia (nombre,direccion,email,telefono,password) VALUES (@nom,@dir,@mail, @tel, @pass)";

                SqlCommand cmd = new SqlCommand(sql, cnx.conexion);

                SqlParameter nombre = new SqlParameter("@nom", System.Data.SqlDbType.NVarChar, 50);
                nombre.Value = r.Nombre;
                cmd.Parameters.Add(nombre);

                SqlParameter direccion = new SqlParameter("@dir", System.Data.SqlDbType.NVarChar, 50);
                direccion.Value = r.Direccion;
                cmd.Parameters.Add(direccion);

                SqlParameter email = new SqlParameter("@mail", System.Data.SqlDbType.NVarChar, 50);
                email.Value = r.Email;
                cmd.Parameters.Add(email);

                SqlParameter telefono = new SqlParameter("@tel", r.Telefono);                
                cmd.Parameters.Add(telefono);

                SqlParameter pass = new SqlParameter("@pass", System.Data.SqlDbType.NVarChar, 50);
                pass.Value = r.Password;
                cmd.Parameters.Add(pass);
                SqlDataReader dr = cmd.ExecuteReader();

                cmd.ExecuteNonQuery();
                
                cnx.CloseConnection();
                return temp;
            }
            catch (Exception ee)
            {

                Console.WriteLine("No se ha podido añadir la residencia " + ee);
                return null;
            }
        }
    }
}