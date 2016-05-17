using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sistema.CapaConfiguracion
{
    public class BombIncendForest : ControlBD
    {
        public BombIncendForest() { }

        public bool insertar(string bombero, int eventoInc, int cantHoras) //agrego la cantidad de horas
        {
            try
            {
                if (!conectar())
                {
                    return false;
                }

                SqlCommand ing = new SqlCommand("insert into TB_BomberoIncendioForestal(FK_BomberoForestal, FK_TB_IncendioForestal, cantHoras, estado) values (@bombero, @eventoInc, @cantHoras, 1)", coneccion);
                ing.Parameters.AddWithValue("bombero", bombero);
                ing.Parameters.AddWithValue("eventoInc", eventoInc);
                ing.Parameters.AddWithValue("cantHoras", cantHoras);

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

        //CREO QUE FALTA EL ACTIVAR

        public bool inactivar(string bombero, int eventIncend)
        {
            if (!conectar())
            {
                return false;
            }

            try
            {
                SqlCommand ing = new SqlCommand("update TB_BomberoIncendioForestal set estado = 0 where FK_BomberoForestal = @bombero and FK_TB_IncendioForestal = @ eventIncend", coneccion);
                ing.Parameters.AddWithValue("bombero", bombero);
                ing.Parameters.AddWithValue(" eventIncend", eventIncend);

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

        public bool getEstado(string bombero, int eventIncend)
        {
            if (!conectar())
            {
                return false;
            }

            try
            {
                SqlCommand ing = new SqlCommand("select estado from TB_BomberoIncendioForestal where FK_BomberoForestal = @bombero and FK_TB_IncendioForestal = @eventIncend", coneccion);
                ing.Parameters.AddWithValue("bombero", bombero);
                ing.Parameters.AddWithValue("eventIncend", eventIncend);

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

        public bool existe(string bombero, int eventIncend)
        {
            if (!conectar())
            {
                return false;
            }

            try
            {                                   //select PK_Id_BomberoCapacitacion from TB_BomberoCapacitacion where FK_BomberoForestal = @bombero and FK_TB_Capacitacion = @capacitacion", coneccion
                SqlCommand ing = new SqlCommand("select PK_Id_BomberoIncendioForestal from TB_BomberoIncendioForestal where FK_BomberoForestal = @bombero and FK_TB_IncendioForestal = @eventIncend", coneccion);
                ing.Parameters.AddWithValue("bombero", bombero);
                ing.Parameters.AddWithValue("eventIncend", eventIncend);

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