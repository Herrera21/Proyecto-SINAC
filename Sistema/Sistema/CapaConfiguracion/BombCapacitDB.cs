using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sistema.CapaConfiguracion
{
    public class BombCapacitDB : ControlBD
    {
        public BombCapacitDB() { }

        public bool insertar(string bombero, int capacitacion, bool aproboCap)
        {
            try
            {
                if (!conectar())
                {
                    return false;
                }

                SqlCommand ing = new SqlCommand("insert into TB_BomberoCapacitacion(FK_BomberoForestal, FK_TB_Capacitacion, aprobacion_Capacitacion, estado) values (@bombero, @capacitacion, @aproboCap, 1)", coneccion);
                ing.Parameters.AddWithValue("bombero", bombero);
                ing.Parameters.AddWithValue("capacitacion", capacitacion);
                ing.Parameters.AddWithValue("aproboCap", aproboCap);

                coneccion.Open();
                ing.ExecuteNonQuery();
                coneccion.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool activar(string bombero, int capacitacion, bool aproboCap)
        {
            if (!conectar())
            {
                return false;
            }

            try
            {
                SqlCommand ing = new SqlCommand("update TB_BomberoCapacitacion set aprobacion_Capacitacion = @aproboCap, estado = 1 where FK_BomberoForestal = @bombero and FK_TB_Capacitacion = @capacitacion", coneccion);
                ing.Parameters.AddWithValue("bombero", bombero);
                ing.Parameters.AddWithValue("capacitacion", capacitacion);
                ing.Parameters.AddWithValue("aproboCap", aproboCap);

                coneccion.Open();
                ing.ExecuteNonQuery();
                coneccion.Close();
                return true;

            }
            catch
            {
                return false;
            }
        }

        public bool inactivar(string bombero, int capacitacion)
        {
            if (!conectar())
            {
                return false;
            }

            try
            {
                SqlCommand ing = new SqlCommand("update TB_BomberoCapacitacion set estado = 0 where FK_BomberoForestal = @bombero and FK_TB_Capacitacion = @capacitacion", coneccion);
                ing.Parameters.AddWithValue("bombero", bombero);
                ing.Parameters.AddWithValue("capacitacion", capacitacion);

                coneccion.Open();
                ing.ExecuteNonQuery();
                coneccion.Close();
                return true;

            }
            catch
            {
                return false;
            }
        }

        public bool getEstado(string bombero, int capacitacion)
        {
            if (!conectar())
            {
                return false;
            }

            try
            {
                SqlCommand ing = new SqlCommand("select estado from TB_BomberoCapacitacion where FK_BomberoForestal = @bombero and FK_TB_Capacitacion = @capacitacion", coneccion);
                ing.Parameters.AddWithValue("bombero", bombero);
                ing.Parameters.AddWithValue("capacitacion", capacitacion);

                coneccion.Open();
                SqlDataReader objReader = ing.ExecuteReader();
                objReader.Read();
                bool temp = objReader.GetBoolean(0);
                coneccion.Close();

                return temp;
            }
            catch
            {
                return false;
            }
        }

        public bool existe(string bombero, int capacitacion)
        {
            if (!conectar())
            {
                return false;
            }

            try
            {
                SqlCommand ing = new SqlCommand("select PK_Id_BomberoCapacitacion from TB_BomberoCapacitacion where FK_BomberoForestal = @bombero and FK_TB_Capacitacion = @capacitacion", coneccion);
                ing.Parameters.AddWithValue("bombero", bombero);
                ing.Parameters.AddWithValue("capacitacion", capacitacion);

                coneccion.Open();
                bool temp = ing.ExecuteReader().Read();
                coneccion.Close();

                return temp;
            }
            catch
            {
                return false;
            }
        }
    }
}