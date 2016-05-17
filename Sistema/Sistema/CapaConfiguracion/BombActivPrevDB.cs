using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sistema.CapaConfiguracion
{
    public class BombActivPrevDB : ControlBD
    {
        public BombActivPrevDB() { }

        public bool insertar(string bombero, int activPrevenc, int cantHorasPart)
        {
            try
            {
                if (!conectar())
                {
                    return false;
                }

                SqlCommand ing = new SqlCommand("insert into TB_BomberoActividadPrevencion(FK_TB_BomberoForestal, FK_TB_ActividadPrevencion, cantHorasPart, estado) values (@bombero, @activPrevenc, @cantHorasPart, 1)", coneccion);
                ing.Parameters.AddWithValue("bombero", bombero);
                ing.Parameters.AddWithValue("activPrevenc", activPrevenc);
                ing.Parameters.AddWithValue("cantHorasPart", cantHorasPart);

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

        public bool activar(string bombero, int activPrevenc, int cantHorasPart)
        {
            if (!conectar())
            {
                return false;
            }

            try
            {
                SqlCommand ing = new SqlCommand("update TB_BomberoActividadPrevencion set cantHorasPart = @cantHorasPart, estado = 1 where FK_TB_BomberoForestal = @bombero and FK_TB_ActividadPrevencion = @activPrevenc", coneccion);
                ing.Parameters.AddWithValue("bombero", bombero);
                ing.Parameters.AddWithValue("activPrevenc", activPrevenc);
                ing.Parameters.AddWithValue("cantHorasPart", cantHorasPart);

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

        public bool inactivar(string bombero, int activPrevenc)
        {
            if (!conectar())
            {
                return false;
            }

            try
            {
                SqlCommand ing = new SqlCommand("update TB_BomberoActividadPrevencion set estado = 0 where FK_TB_BomberoForestal = @bombero and FK_TB_ActividadPrevencion = @activPrevenc", coneccion);
                ing.Parameters.AddWithValue("bombero", bombero);
                ing.Parameters.AddWithValue("activPrevenc", activPrevenc);

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

        public bool getEstado(string bombero, int activPrevenc)
        {
            if (!conectar())
            {
                return false;
            }

            try
            {
                SqlCommand ing = new SqlCommand("select estado from TB_BomberoActividadPrevencion where FK_TB_BomberoForestal = @bombero and FK_TB_ActividadPrevencion = @activPrevenc", coneccion);
                ing.Parameters.AddWithValue("bombero", bombero);
                ing.Parameters.AddWithValue("activPrevenc", activPrevenc);

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

        public bool existe(string bombero, int activPrevenc)
        {
            if (!conectar())
            {
                return false;
            }

            try
            {
                SqlCommand ing = new SqlCommand("select PK_Id_BomberoActividadPrevencion from TB_BomberoActividadPrevencion where FK_TB_BomberoForestal = @bombero and FK_TB_ActividadPrevencion = @activPrevenc", coneccion);
                ing.Parameters.AddWithValue("bombero", bombero);
                ing.Parameters.AddWithValue("activPrevenc", activPrevenc);

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