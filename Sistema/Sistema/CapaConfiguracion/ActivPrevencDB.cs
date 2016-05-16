using CapaDatos;
using Sistema.CapaLogicaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sistema.CapaConfiguracion
{
    public class ActivPrevencDB : ControlBD
    {
        public ActivPrevencDB() { }

        public bool insertar(ActivPrevencion objeto)
        {
            try
            {
                if (!conectar())
                {
                    return false;
                }

                SqlCommand ing = new SqlCommand("insert into TB_ActividadPrevencion(nombre, fecha, lugar, observaciones, estado) values (@nombre, @fecha, @lugar, @observaciones, 1)", coneccion);
                ing.Parameters.AddWithValue("nombre", objeto.getNombreActiv());
                ing.Parameters.AddWithValue("fecha", objeto.getFechaActiv());
                ing.Parameters.AddWithValue("lugar", objeto.getLugarActiv());
                ing.Parameters.AddWithValue("observaciones", objeto.getObservaciones());


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

        public bool actualizar(int id, ActivPrevencion objeto)
        {
            if (!conectar())
            {
                return false;
            }

            try
            {
                SqlCommand ing = new SqlCommand("update TB_ActividadPrevencion set nombre = @Onombre, fecha = @Ofecha, lugar = @Olugar, observaciones = @Oobservaciones where PK_Id_ActividadPrevencion = @id", coneccion);
                ing.Parameters.AddWithValue("Onombre", objeto.getNombreActiv());
                ing.Parameters.AddWithValue("Ofecha", objeto.getFechaActiv());
                ing.Parameters.AddWithValue("Olugar", objeto.getLugarActiv());
                ing.Parameters.AddWithValue("Oobservaciones", objeto.getObservaciones());

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

        public bool inactivar(bool inactiva, int id)
        {
            if (!conectar())
            {
                return false;
            }

            try
            {
                if (inactiva)
                {
                    SqlCommand ing = new SqlCommand("update TB_ActividadPrevencion set estado = 0 where PK_Id_ActividadPrevencion = @id", coneccion);
                    ing.Parameters.AddWithValue("id", id);

                    coneccion.Open();
                    ing.ExecuteNonQuery();
                    coneccion.Close();
                    return true;
                }
                else
                {
                    SqlCommand ing = new SqlCommand("update TB_ActividadPrevencion set estado = 1 where PK_Id_ActividadPrevencion = @id", coneccion);
                    ing.Parameters.AddWithValue("id", id);

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

        // selecciones sin  filtrar activo inactivo
        public ActivPrevencion seleccionar(int id)
        {
            if (!conectar())
            {
                return null;
            }

            try
            {
                SqlCommand ing = new SqlCommand("select nombre, fecha, lugar, observaciones from TB_ActividadPrevencion where PK_Id_ActividadPrevencion = @id", coneccion);
                ing.Parameters.AddWithValue("id", id);

                coneccion.Open();
                SqlDataReader objReader = ing.ExecuteReader();
                objReader.Read();
                ActivPrevencion temp = new ActivPrevencion(objReader.GetString(0), objReader.GetString(1), objReader.GetString(2), objReader.GetString(3));
                coneccion.Close();

                return temp;
            }
            catch
            {
                return null;
            }
        }

        // filtros doble funcion
        public DataSet seleccionar_Dataset(bool activo, string columna, string operacion, string valor)
        {
            if (!conectar())
            {
                return null;
            }

            try
            {
                if (activo)
                {
                    if (columna == null || valor == null)
                    {
                        SqlDataAdapter temp1 = new SqlDataAdapter("select PK_Id_ActividadPrevencion, nombre, fecha, lugar, observaciones from TB_ActividadPrevencion where estado = 1", coneccion);
                        DataSet temp2 = new DataSet();
                        temp1.Fill(temp2);
                        return temp2;
                    }
                    else
                    {
                        SqlDataAdapter temp1 = new SqlDataAdapter("select PK_Id_ActividadPrevencion, nombre, fecha, lugar, observaciones from TB_ActividadPrevencion WHERE estado = 1 and " + columna + " " + operacion + " '" + valor + "'", coneccion);
                        DataSet temp2 = new DataSet();
                        temp1.Fill(temp2);
                        return temp2;
                    }
                }
                else
                {
                    if (columna == null || valor == null)
                    {
                        SqlDataAdapter temp1 = new SqlDataAdapter("select PK_Id_ActividadPrevencion, nombre, fecha, lugar, observaciones from TB_ActividadPrevencion where estado = 0", coneccion);
                        DataSet temp2 = new DataSet();
                        temp1.Fill(temp2);
                        return temp2;
                    }
                    else
                    {
                        SqlDataAdapter temp1 = new SqlDataAdapter("select PK_Id_ActividadPrevencion, nombre, fecha, lugar, observaciones from TB_ActividadPrevencion WHERE estado = 0 and " + columna + " " + operacion + " '" + valor + "'", coneccion);
                        DataSet temp2 = new DataSet();
                        temp1.Fill(temp2);
                        return temp2;
                    }
                }

            }
            catch
            {
                return null;
            }
        }

        public bool getEstado(int id)
        {
            if (!conectar())
            {
                return false;
            }

            try
            {
                SqlCommand ing = new SqlCommand("select estado from TB_ActividadPrevencion where PK_Id_ActividadPrevencion = @id", coneccion);
                ing.Parameters.AddWithValue("id", id);

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

        public string getNombre(int id)
        {
            if (!conectar())
            {
                return null;
            }

            try
            {
                SqlCommand ing = new SqlCommand("select nombre from TB_ActividadPrevencion where PK_Id_ActividadPrevencion = @id", coneccion);
                ing.Parameters.AddWithValue("id", id);

                coneccion.Open();
                SqlDataReader objReader = ing.ExecuteReader();
                objReader.Read();
                string temp = objReader.GetString(0);
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