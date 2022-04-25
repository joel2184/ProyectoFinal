using ProyectoFinal.Modelo;
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

        //Método para buscar todas las residencias
        public List<Residencia> SelectAll()
        {
            //list.Clear();
            try
            {
                cnx.OpenConection();

                string sql = @"
                SELECT * FROM Residencia";

                SqlCommand cmd = new SqlCommand(sql, cnx.conexion);

                SqlDataReader dr = cmd.ExecuteReader();

                List<Residencia> list = new List<Residencia>();


                while (dr.Read())
                {
                    temp = new Residencia(Convert.ToString(dr[0]), Convert.ToString(dr[1]), Convert.ToString(dr[2]), Convert.ToString(dr[3]), Convert.ToString(dr[4]), Convert.ToInt32(dr[5]), Convert.ToDecimal(dr[6]), Convert.ToDecimal(dr[7]));

                    list.Add(temp);
                }



                dr.Close();
                cnx.CloseConnection();
                return list;
            }
            catch (Exception ee)
            {

                Console.WriteLine("No se ha podido encontrar residencias " + ee);
                return null;
            }
        }

        //Método para encontar usuario residencia
        public Residencia FindUser(string email, string password)
        {
            try
            {
                cnx.OpenConection();

                string sql = @"
                SELECT * FROM Residencia WHERE email = @mail AND password = @pass";

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
                    temp = new Residencia(Convert.ToString(dr[0]), Convert.ToString(dr[1]), Convert.ToString(dr[2]), Convert.ToString(dr[3]), Convert.ToString(dr[4]), Convert.ToInt32(dr[5]), Convert.ToDecimal(dr[6]), Convert.ToDecimal(dr[7]));

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

        //Método para buscar residencia por id_residencia
        public Residencia FindById(int id)
        {
            try
            {
                cnx.OpenConection();

                string sql = @"
                SELECT * FROM Residencia WHERE Id_residencia = @pId";

                SqlCommand cmd = new SqlCommand(sql, cnx.conexion);
                SqlParameter ID = new SqlParameter("@pId", System.Data.SqlDbType.Int);
                ID.Value = id;
                cmd.Parameters.Add(ID);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    temp = new Residencia(Convert.ToString(dr[0]), Convert.ToString(dr[1]), Convert.ToString(dr[2]), Convert.ToString(dr[3]), Convert.ToString(dr[4]), Convert.ToInt32(dr[5]), Convert.ToDecimal(dr[6]), Convert.ToDecimal(dr[7]));

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

        //Insertar usuario residencia
        public Residencia InsertUser(Residencia r)
        {
            try
            {
                cnx.OpenConection();

                String sql = "INSERT INTO Residencia (nombre,direccion,email,telefono,password,latitiud,longitud) VALUES (@nom,@dir,@mail, @tel, @pass, @lat, @lon)";

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

                SqlParameter telefono = new SqlParameter("@tel", System.Data.SqlDbType.NVarChar, 50);
                telefono.Value = r.Telefono;
                cmd.Parameters.Add(telefono);

                SqlParameter pass = new SqlParameter("@pass", System.Data.SqlDbType.NVarChar, 50);
                pass.Value = r.Password;
                cmd.Parameters.Add(pass);

                SqlParameter lat = new SqlParameter("@lat", System.Data.SqlDbType.Decimal, 50);
                pass.Value = r.Latitud;
                cmd.Parameters.Add(lat);

                SqlParameter lon = new SqlParameter("@lon", System.Data.SqlDbType.Decimal, 50);
                pass.Value = r.Longitud;
                cmd.Parameters.Add(lon);

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