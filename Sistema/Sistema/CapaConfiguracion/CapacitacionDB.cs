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
    public class CapacitacionDB : ControlBD
    {
        public CapacitacionDB() { }

        public bool insertar(Capacitacion objeto)
        {
            try
            {
                if (!conectar())
                {
                    return false;
                }

                SqlCommand ing = new SqlCommand("insert into TB_Capacitacion(nombre_Capacitacion, lugar_Capacitacion, institucion, cantHoras, fechaEmision, fechaCaducidad, estado) values (@nombre_Capacitacion, @lugar_Capacitacion, @institucion, @cantHoras, @fechaEmision, @fechaCaducidad, 1)", coneccion);
                ing.Parameters.AddWithValue("nombre_Capacitacion", objeto.getNombre());
                ing.Parameters.AddWithValue("lugar_Capacitacion", objeto.getLugarCap());
                ing.Parameters.AddWithValue("institucion", objeto.getInstitucion());
                ing.Parameters.AddWithValue("cantHoras", objeto.getCantHoras());
                ing.Parameters.AddWithValue("fechaEmision", objeto.getFechaEmision());
                ing.Parameters.AddWithValue("fechaCaducidad", objeto.getFechaCaducidad());

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

        public bool actualizar(int id, Capacitacion objeto)
        {
            if (!conectar())
            {
                return false;
            }

            try
            {
                SqlCommand ing = new SqlCommand("update TB_Capacitacion set nombre_Capacitacion = @Onombre_Capacitacion, lugar_Capacitacion = @Olugar_Capacitacion, institucion = @Oinstitucion, cantHoras = @OcantHoras, fechaEmision = @OfechaEmision, fechaCaducidad = @OfechaCaducidad  where PK_Id_Capacitacion = @id", coneccion);
                ing.Parameters.AddWithValue("Onombre_Capacitacion", objeto.getNombre());
                ing.Parameters.AddWithValue("Olugar_Capacitacion", objeto.getLugarCap());
                ing.Parameters.AddWithValue("Oinstitucion", objeto.getInstitucion());
                ing.Parameters.AddWithValue("OcantHoras", objeto.getCantHoras());
                ing.Parameters.AddWithValue("OfechaEmision", objeto.getFechaEmision());
                ing.Parameters.AddWithValue("OfechaCaducidad", objeto.getFechaCaducidad());

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
                    SqlCommand ing = new SqlCommand("update TB_Capacitacion set estado = 0 where PK_Id_Capacitacion = @id", coneccion);
                    ing.Parameters.AddWithValue("id", id);

                    coneccion.Open();
                    ing.ExecuteNonQuery();
                    coneccion.Close();
                    return true;
                }
                else
                {
                    SqlCommand ing = new SqlCommand("update TB_Capacitacion set estado = 1 where PK_Id_Capacitacion = @id", coneccion);
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
        public Capacitacion seleccionar(int id)
        {
            if (!conectar())
            {
                return null;
            }

            try
            {
                SqlCommand ing = new SqlCommand("select nombre_Capacitacion, lugar_Capacitacion, institucion, cantHoras, fechaEmision, fechaCaducidad from TB_Capacitacion where PK_Id_Capacitacion = @id", coneccion);
                ing.Parameters.AddWithValue("id", id);

                coneccion.Open();
                SqlDataReader objReader = ing.ExecuteReader();
                objReader.Read();
                Capacitacion temp = new Capacitacion(objReader.GetString(0), objReader.GetString(1), objReader.GetString(2), objReader.GetInt32(3), objReader.GetString(4), objReader.GetString(5));
                coneccion.Close();

                return temp;
            }
            catch
            {
                return null;
            }
        }

        // seccion activos
        public List<string> listaCapacitaciones()
        {
            if (!conectar())
            {
                return null;
            }

            try
            {
                SqlCommand ing = new SqlCommand("select nombre_Capacitacion from TB_Capacitacion where estado = 1", coneccion);

                coneccion.Open();
                SqlDataReader objReader = ing.ExecuteReader();
                List<string> temp = new List<string>();

                while (objReader.Read())
                {
                    temp.Add(objReader.GetString(0));
                }

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
                        SqlDataAdapter temp1 = new SqlDataAdapter("select PK_Id_Capacitacion, nombre_Capacitacion, lugar_Capacitacion, institucion, cantHoras, fechaEmision, fechaCaducidad from TB_Capacitacion where estado = 1", coneccion);
                        DataSet temp2 = new DataSet();
                        temp1.Fill(temp2);
                        return temp2;
                    }
                    else
                    {
                        SqlDataAdapter temp1 = new SqlDataAdapter("select PK_Id_Capacitacion, nombre_Capacitacion, lugar_Capacitacion, institucion, cantHoras, fechaEmision, fechaCaducidad from TB_Capacitacion WHERE estado = 1 and " + columna + " " + operacion + " '" + valor + "'", coneccion);
                        DataSet temp2 = new DataSet();
                        temp1.Fill(temp2);
                        return temp2;
                    }
                }
                else
                {
                    if (columna == null || valor == null)
                    {
                        SqlDataAdapter temp1 = new SqlDataAdapter("select PK_Id_Capacitacion, nombre_Capacitacion, lugar_Capacitacion, institucion, cantHoras, fechaEmision, fechaCaducidad from TB_Capacitacion where estado = 0", coneccion);
                        DataSet temp2 = new DataSet();
                        temp1.Fill(temp2);
                        return temp2;
                    }
                    else
                    {
                        SqlDataAdapter temp1 = new SqlDataAdapter("select PK_Id_Capacitacion, nombre_Capacitacion, lugar_Capacitacion, institucion, cantHoras, fechaEmision, fechaCaducidad from TB_Capacitacion WHERE estado = 0 and " + columna + " " + operacion + " '" + valor + "'", coneccion);
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

        public DataSet seleccionar_Dataset_AsignCapBom(string id)
        {
            if (!conectar())
            {
                return null;
            }

            try
            {
                SqlDataAdapter temp1 = new SqlDataAdapter("select PK_Id_Capacitacion, nombre_Capacitacion, lugar_Capacitacion, institucion, cantHoras, fechaEmision, fechaCaducidad, aprobacion_Capacitacion from TB_Capacitacion C join TB_BomberoCapacitacion BC on C.PK_Id_Capacitacion = BC.FK_TB_Capacitacion where C.estado = 1 and BC.estado = 1 and BC.FK_BomberoForestal = '" + id+"'", coneccion);
                DataSet temp2 = new DataSet();
                temp1.Fill(temp2);
                return temp2;

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
                SqlCommand ing = new SqlCommand("select estado from TB_Capacitacion where PK_Id_Capacitacion = @id", coneccion);
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
                SqlCommand ing = new SqlCommand("select nombre_Capacitacion from TB_Capacitacion where PK_Id_Capacitacion = @id", coneccion);
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