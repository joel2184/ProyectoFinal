using ProyectoFinal.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace ProyectoFinal.DALs
{
    public class DALVoluntarioActividad
    {
        
        
        DBConnect cnx;
        List<int> list = new List<int>();

        public DALVoluntarioActividad()
        {
            cnx = new DBConnect();
        }

        //Buscar actividad buscando por idActividad & idVoluntario
        public bool SelectbyIDs(int idActividad, int idVoluntario)
        {
            //list.Clear();
            try
            {
                cnx.OpenConection();

                string sql = @"
                SELECT COUNT(*) FROM Voluntario_Actividad
                WHERE fk_actividad = @pIdACT AND fk_voluntario = @pIdVOL";

                SqlCommand cmd = new SqlCommand(sql, cnx.conexion);
                SqlParameter idAct = new SqlParameter("@pIdACT", System.Data.SqlDbType.Int);
                SqlParameter idVol = new SqlParameter("@pIdVOL", System.Data.SqlDbType.Int);
                idAct.Value = idActividad;
                idVol.Value = idVoluntario;
                cmd.Parameters.Add(idAct);
                cmd.Parameters.Add(idVol);

                int registro = Convert.ToInt32(cmd.ExecuteScalar());

                if (registro == 0)
                {
                    return false;
                }
                else {
                    return true;
                }

            }
            catch (Exception ee)
            {

                Console.WriteLine("No se ha podido encontrar actividades " + ee);
                return false;
            }
        }

        //Insertar actividadVoluntario a la BD
        public void InsertActividadVoluntario(int idActividad, int idVoluntario)
        {
            try
            {
                cnx.OpenConection();

                String sql = "INSERT INTO Voluntario_Actividad  VALUES (@pIdVOL, @pIdACT)";

                SqlCommand cmd = new SqlCommand(sql, cnx.conexion);

                SqlParameter idAct = new SqlParameter("@pIdACT", System.Data.SqlDbType.Int);
                SqlParameter idVol = new SqlParameter("@pIdVOL", System.Data.SqlDbType.Int);
                idAct.Value = idActividad;
                idVol.Value = idVoluntario;
                cmd.Parameters.Add(idAct);
                cmd.Parameters.Add(idVol);

                cmd.ExecuteNonQuery();

                cnx.CloseConnection();
                
            }
            catch (Exception ee)
            {

                Console.WriteLine("No se ha podido añadir la actividad " + ee);
                
            }
        }
        //Eliminar actividadVoluntario de la BD
        public void DeleteActividadVoluntario(int idActividad, int idVoluntario)
        {
            try
            {
                cnx.OpenConection();

                String sql = "DELETE FROM Voluntario_Actividad WHERE fk_voluntario = @pIdVOL AND fk_actividad = @pIdACT;";

                SqlCommand cmd = new SqlCommand(sql, cnx.conexion);

                SqlParameter idAct = new SqlParameter("@pIdACT", System.Data.SqlDbType.Int);
                SqlParameter idVol = new SqlParameter("@pIdVOL", System.Data.SqlDbType.Int);
                idAct.Value = idActividad;
                idVol.Value = idVoluntario;
                cmd.Parameters.Add(idAct);
                cmd.Parameters.Add(idVol);

                cmd.ExecuteNonQuery();

                cnx.CloseConnection();

            }
            catch (Exception ee)
            {

                Console.WriteLine("No se ha podido añadir la actividad " + ee);

            }
        }

        //Buscar todas las actividadesVoluntario
        public List<int> SelectAll()
        {
            //list.Clear();
           
            
            try
            {
                
                cnx.OpenConection();

                string sql = @"
                SELECT * FROM Voluntario_Actividad";

                SqlCommand cmd = new SqlCommand(sql, cnx.conexion);
                
                SqlDataReader dr = cmd.ExecuteReader();


                while (dr.Read())
                {                    
                    list.Add(Convert.ToInt32(dr[0].ToString()));
                    list.Add(Convert.ToInt32(dr[1].ToString()));
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
    }
}