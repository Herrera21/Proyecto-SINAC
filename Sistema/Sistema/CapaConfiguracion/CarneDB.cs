
using Sistema.CapaLogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CapaDatos;
using CapaLogica;
using System.Data.SqlClient;
using System.Data;

namespace Sistema.CapaConfiguracion
{
    public class CarneDB : ControlBD
    {
        public CarneDB() { }
    

    public bool insertar(Carnet objeto)
    {
        try
        {
            if (!conectar())
            {
                return false;
            }

            SqlCommand ing = new SqlCommand("insert into TB_Carnet(PK_FK_Id_BomberoForestal, emision, fechaVencimient, anioCarnet) values (@id_Bombero, @emision, @fechaVencimient, @anioCarnet)", coneccion);
            ing.Parameters.AddWithValue("id_Bombero", objeto.getId_Bombero());
            ing.Parameters.AddWithValue("emision", objeto.getEmisionCarnet());
            ing.Parameters.AddWithValue("fechaVencimient", objeto.getFechaVencimiento());
            ing.Parameters.AddWithValue("anioCarnet", objeto.getAnioCarnet());

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
        public bool actualizar(string id, Carnet objeto)
        {
            if (!conectar())
            {
                return false;
            }

            try
            {
                SqlCommand ing = new SqlCommand("update TB_Carnet set emision = @emision, fechaVencimient = @fechaVencimient, anioCarnet = @anioCarnet where PK_FK_Id_BomberoForestal = @id", coneccion);
             
                ing.Parameters.AddWithValue("emision", objeto.getEmisionCarnet());
                ing.Parameters.AddWithValue("fechaVencimient", objeto.getFechaVencimiento());
                ing.Parameters.AddWithValue("anioCarnet", objeto.getAnioCarnet());

                ing.Parameters.AddWithValue("id", id);

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

        public Carnet seleccionar(string id)
        {
            if (!conectar())
            {
                return null;
            }

            try
            {
                SqlCommand ing = new SqlCommand("select emision, fechaVencimient, anioCarnet, PK_FK_Id_BomberoForestal from TB_Carnet where PK_FK_Id_BomberoForestal = @id", coneccion);
                ing.Parameters.AddWithValue("id", id);

                coneccion.Open();
                SqlDataReader objReader = ing.ExecuteReader();
                objReader.Read();
                Carnet temp = new Carnet(objReader.GetInt32(0), objReader.GetString(1), objReader.GetString(2), objReader.GetString(3));
                coneccion.Close();

                return temp;
            }
            catch
            {
                return null;
            }
        }
    }
}