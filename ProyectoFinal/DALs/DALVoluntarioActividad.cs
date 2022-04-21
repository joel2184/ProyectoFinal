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
        int id_volu;
        int id_act;
        Volu_Acti temp;
        Voluntario voluTemp;
        Actividad actTemp;
        DBConnect cnx;
        List<Volu_Acti> list;

        public DALVoluntarioActividad()
        {
            cnx = new DBConnect();
        }

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
        public List<Volu_Acti> SelectWhereIdResi(int id)
        {
            //list.Clear();
           
            DALActividad dalactividad = new DALActividad();
            DALVoluntario dalvolu = new DALVoluntario();
            try
            {
                
                cnx.OpenConection();

                string sql = @"
                SELECT * FROM Voluntario_Actividad WHERE fk_Actividad in (SELECT id_actividad FROM Actividades WHERE fk_residencia = @id)";

                SqlCommand cmd = new SqlCommand(sql, cnx.conexion);
                SqlParameter residencia = new SqlParameter("@res", id);
                cmd.Parameters.Add(residencia);
                SqlDataReader dr = cmd.ExecuteReader();


                while (dr.Read())
                {
                    id_volu = Convert.ToInt32(dr[0].ToString());
                    id_act = Convert.ToInt32(dr[1].ToString());
                    
                    list.Add(temp);
                }                
                dr.Close();                
                cnx.CloseConnection();
                voluTemp = dalvolu.SelectbyID(id_volu);
                actTemp = dalactividad.SelectbyID(id_act);
                temp = new Volu_Acti(voluTemp, actTemp);
                
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