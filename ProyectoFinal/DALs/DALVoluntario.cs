using ProyectoFinal.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProyectoFinal.DALs
{
    public class DALVoluntario
    {
        Voluntario temp;
        DBConnect cnx;

        public DALVoluntario()
        {
            cnx = new DBConnect();
        }

        //Método para buscar usuario voluntario
        public Voluntario FindUser(string mail, string password)
        {

            try
            {
                cnx.OpenConection();

                string sql = "SELECT * FROM Voluntario WHERE email = @mail AND contrasena = @pass";

                SqlCommand cmd = new SqlCommand(sql, cnx.conexion);
                SqlParameter email = new SqlParameter("@mail", System.Data.SqlDbType.NVarChar, 50);
                email.Value = mail;
                cmd.Parameters.Add(email);

                SqlParameter pass = new SqlParameter("@pass", System.Data.SqlDbType.NVarChar, 50);
                pass.Value = password;
                cmd.Parameters.Add(pass);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    temp = new Voluntario(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), Convert.ToInt32(dr[6]));

                }



                dr.Close();
                cnx.CloseConnection();
                return temp;
            }
            catch (Exception ee)
            {

                Console.WriteLine("No se ha podido encontrar el Voluntario " + ee);
                return null;
            }
        }
        //Insertar usuario voluntario
        public Voluntario InsertUser(Voluntario r)
        {
            try
            {
                cnx.OpenConection();

                String sql = "INSERT INTO Voluntario (dni,nombre,telefono,email,horario,contrasena) VALUES (@dni, @nom , @tel, @mail, @hor, @pass)";

                SqlCommand cmd = new SqlCommand(sql, cnx.conexion);

                SqlParameter dni = new SqlParameter("@dni", System.Data.SqlDbType.NVarChar, 50);
                dni.Value = r.Dni;
                cmd.Parameters.Add(dni);

                SqlParameter nombre = new SqlParameter("@nom", System.Data.SqlDbType.NVarChar, 50);
                nombre.Value = r.Nombre;
                cmd.Parameters.Add(nombre);

                SqlParameter telefono = new SqlParameter("@tel", System.Data.SqlDbType.NVarChar, 50);
                telefono.Value = r.Telefono;
                cmd.Parameters.Add(telefono);

                SqlParameter email = new SqlParameter("@mail", System.Data.SqlDbType.NVarChar, 50);
                email.Value = r.Email;
                cmd.Parameters.Add(email);

                SqlParameter horario = new SqlParameter("@hor", System.Data.SqlDbType.NVarChar, 50);
                horario.Value = r.Horario;
                cmd.Parameters.Add(horario);

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

                Console.WriteLine("No se ha podido añadir el voluntario " + ee);
                return null;
            }
        }

        //Buscarr todos los voluntarios
        public List<Voluntario> SelectAll()
        {
            //list.Clear();
            try
            {
                cnx.OpenConection();

                string sql = @"
                SELECT * FROM Voluntario";

                SqlCommand cmd = new SqlCommand(sql, cnx.conexion);

                SqlDataReader dr = cmd.ExecuteReader();

                List<Voluntario> list = new List<Voluntario>();


                while (dr.Read())
                {
                    
                    temp = new Voluntario(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), Convert.ToInt32(dr[6]));
                    list.Add(temp);
                }



                dr.Close();
                cnx.CloseConnection();
                return list;
            }
            catch (Exception ee)
            {

                Console.WriteLine("No se ha podido encontrar actividades " + ee);
                return null;
            }
        }
        //Buscar voluntario por id_voluntario
        public Voluntario SelectbyID(int id)
        {
            //list.Clear();
            try
            {
                cnx.OpenConection();

                string sql = @"
                SELECT * FROM Voluntario
                WHERE Id_voluntario = @pId";

                SqlCommand cmd = new SqlCommand(sql, cnx.conexion);
                SqlParameter ID = new SqlParameter("@pId", System.Data.SqlDbType.Int);
                ID.Value = id;
                cmd.Parameters.Add(ID);
                SqlDataReader dr = cmd.ExecuteReader();


                while (dr.Read())
                {
                    temp = new Voluntario(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), Convert.ToInt32(dr[6]));
                }



                dr.Close();
                cnx.CloseConnection();
                return temp;
            }
            catch (Exception ee)
            {

                Console.WriteLine("No se ha podido encontrar actividades " + ee);
                return null;
            }
        }
    }
}