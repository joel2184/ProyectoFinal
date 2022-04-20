using ProyectoFinal.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProyectoFinal.DALs
{
    public class DALActividad
    {
        Actividad temp;
        DBConnect cnx;
        //List<Actividad> list;

        public DALActividad()
        {
            cnx = new DBConnect();
        }
        public List<Actividad> SelectAll ()
        {
            //list.Clear();
            try
            {
                cnx.OpenConection();

                string sql = @"
                SELECT * FROM Actividades";

                SqlCommand cmd = new SqlCommand(sql, cnx.conexion);
                
                SqlDataReader dr = cmd.ExecuteReader();

                List<Actividad> list = new List<Actividad>();


                while (dr.Read())
                {
                    int id = Convert.ToInt32(dr["id_actividad"].ToString());
                    string nombre = dr["nombre"].ToString();
                    string tipo = dr["tipo"].ToString();
                    TimeSpan horario = TimeSpan.Parse(dr["horario"].ToString());
                    DateTime fecha = Convert.ToDateTime(dr["fecha"].ToString());
                    
                    int rseidencia = Convert.ToInt32(dr["fk_residencia"].ToString());
                    string desccripcion = dr["descripcion"].ToString();
                    temp = new Actividad(nombre,tipo,horario,fecha.Date,desccripcion,rseidencia,id);
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

        public List<Actividad> SelectTipo(string tipoActividad)
        {
            //list.Clear();
            try
            {
                cnx.OpenConection();

                SqlParameter pTipo = new SqlParameter("@pTipoActividad", System.Data.SqlDbType.VarChar, 50);
                pTipo.Value = tipoActividad;
                string sql = @"
                SELECT * FROM Actividades
                WHERE tipo = @pTipoActividad";

                SqlCommand cmd = new SqlCommand(sql, cnx.conexion);
                cmd.Parameters.Add(pTipo);

                SqlDataReader dr = cmd.ExecuteReader();

                List<Actividad> list = new List<Actividad>();


                while (dr.Read())
                {
                    int id = Convert.ToInt32(dr["id_actividad"].ToString());
                    string nombre = dr["nombre"].ToString();
                    string tipo = dr["tipo"].ToString();
                    TimeSpan horario = TimeSpan.Parse(dr["horario"].ToString());
                    DateTime fecha = Convert.ToDateTime(dr["fecha"].ToString());

                    int rseidencia = Convert.ToInt32(dr["fk_residencia"].ToString());
                    string desccripcion = dr["descripcion"].ToString();
                    temp = new Actividad(nombre, tipo, horario, fecha.Date, desccripcion, rseidencia, id);
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

        public Actividad SelectbyID(int id)
        {
            //list.Clear();
            try
            {
                cnx.OpenConection();

                string sql = @"
                SELECT * FROM Actividades
                WHERE id_actividad = @pId";

                SqlCommand cmd = new SqlCommand(sql, cnx.conexion);
                SqlParameter ID = new SqlParameter("@pId", System.Data.SqlDbType.Int);
                ID.Value = id;
                cmd.Parameters.Add(ID);
                SqlDataReader dr = cmd.ExecuteReader();

                Actividad a = new Actividad();

                while (dr.Read())
                {
                     a = new Actividad(Convert.ToString(dr[0]), Convert.ToString(dr[1]), TimeSpan.Parse(Convert.ToString(dr[2])), Convert.ToDateTime(dr[3]), Convert.ToString(dr[4]), Convert.ToInt32(dr[5]), Convert.ToInt32(dr[6]));
                }



                dr.Close();
                cnx.CloseConnection();
                return a;
            }
            catch (Exception ee)
            {

                Console.WriteLine("No se ha podido encontrar actividades " + ee);
                return null;
            }
        }
        public Actividad InsertActividad(Actividad r)
        {
            
            try
            {
                cnx.OpenConection();

                String sql = "INSERT INTO Actividades (nombre,tipo,horario,descripcion,residencia) VALUES (@nom, @tipo , @hor, @desc, @res)";

                SqlCommand cmd = new SqlCommand(sql, cnx.conexion);

                SqlParameter nombre = new SqlParameter("@nom", System.Data.SqlDbType.NVarChar, 50);
                nombre.Value = r.Nombre;
                cmd.Parameters.Add(nombre);

                SqlParameter tipo = new SqlParameter("@tipo", System.Data.SqlDbType.NVarChar);
                tipo.Value = r.Tipo;
                cmd.Parameters.Add(tipo);

                SqlParameter horario = new SqlParameter("@hor", System.Data.SqlDbType.NVarChar, 50);
                horario.Value = r.Horario;
                cmd.Parameters.Add(horario);

                SqlParameter descripcion = new SqlParameter("@desc", System.Data.SqlDbType.NVarChar, 50);
                descripcion.Value = r.Descripcion;
                cmd.Parameters.Add(descripcion);

                SqlParameter residencia = new SqlParameter("@res", r.Residencia);                
                cmd.Parameters.Add(residencia);
               
                cmd.ExecuteNonQuery();

                cnx.CloseConnection();
                return temp;
            }
            catch (Exception ee)
            {

                Console.WriteLine("No se ha podido añadir la actividad " + ee);
                return null;
            }
        }
    }
}