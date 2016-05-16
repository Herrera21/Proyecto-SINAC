using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sistema.CapaConfiguracion
{
    public class BombPolizaDB : ControlBD
    {
        public BombPolizaDB(){}

        public bool insertar(string bombero, int poliza)
        {
            try
            {
                if (!conectar())
                {
                    return false;
                }

                SqlCommand ing = new SqlCommand("insert into TB_BomberoPoliza(FK_TB_BomberoForestal, FK_TB_Poliza, estado) values (@bombero, @poliza, 1)", coneccion);
                ing.Parameters.AddWithValue("bombero", bombero);
                ing.Parameters.AddWithValue("poliza", poliza);

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

        public bool inactivar(bool inactiva, string bombero, int poliza)
        {
            if (!conectar())
            {
                return false;
            }

            try
            {
                if (inactiva)
                {
                    SqlCommand ing = new SqlCommand("update TB_BomberoPoliza set estado = 0 where FK_TB_BomberoForestal = @bombero and FK_TB_Poliza = @poliza", coneccion);
                    ing.Parameters.AddWithValue("bombero", bombero);
                    ing.Parameters.AddWithValue("poliza", poliza);

                    coneccion.Open();
                    ing.ExecuteNonQuery();
                    coneccion.Close();
                    return true;
                }
                else
                {
                    SqlCommand ing = new SqlCommand("update TB_BomberoPoliza set estado = 1 where FK_TB_BomberoForestal = @bombero and FK_TB_Poliza = @poliza", coneccion);
                    ing.Parameters.AddWithValue("bombero", bombero);
                    ing.Parameters.AddWithValue("poliza", poliza);

                    coneccion.Open();
                    ing.ExecuteNonQuery();
                    coneccion.Close();
                    return true;
                }

            }
            catch
            {
                return false;
            }
        }

        public bool getEstado(string bombero, int poliza)
        {
            if (!conectar())
            {
                return false;
            }

            try
            {
                SqlCommand ing = new SqlCommand("select estado from TB_BomberoPoliza where FK_TB_BomberoForestal = @bombero and FK_TB_Poliza = @poliza", coneccion);
                ing.Parameters.AddWithValue("bombero", bombero);
                ing.Parameters.AddWithValue("poliza", poliza);

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

        public bool existe(string bombero, int poliza)
        {
            if (!conectar())
            {
                return false;
            }

            try
            {
                SqlCommand ing = new SqlCommand("select PK_Id_BomberoPoliza from TB_BomberoPoliza where FK_TB_BomberoForestal = @bombero and FK_TB_Poliza = @poliza", coneccion);
                ing.Parameters.AddWithValue("bombero", bombero);
                ing.Parameters.AddWithValue("poliza", poliza);

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