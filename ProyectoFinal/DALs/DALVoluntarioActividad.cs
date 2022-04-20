﻿using ProyectoFinal.Modelo;
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
        Actividad actividad;
        Voluntario voluntario;
        DBConnect cnx;
        //List<Actividad> list;

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
    }
}