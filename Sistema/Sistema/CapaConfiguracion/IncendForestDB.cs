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
    public class IncendForestDB : ControlBD
    {
        public IncendForestDB() { }

        public bool insertar(IncendForest objeto)
        {
            try
            {
                if (!conectar())
                {
                    return false;
                }

                SqlCommand ing = new SqlCommand("insert into TB_IncendioForestal(lugar, fechaParticipacion, estado) values (@lugar, @fechaParticipacion, 1)", coneccion);
                ing.Parameters.AddWithValue("lugar", objeto.getLugar());
                ing.Parameters.AddWithValue("fechaParticipacion", objeto.getFechaPartic());

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

        public bool actualizar(int id, IncendForest objeto)
        {
            if (!conectar())
            {
                return false;
            }

            try
            {
                SqlCommand ing = new SqlCommand("update TB_IncendioForestal set lugar = @Olugar, fechaParticipacion = @OfechaParticipacion  where PK_Id_IncendioForestal = @id", coneccion);
                ing.Parameters.AddWithValue("Olugar", objeto.getLugar());
                ing.Parameters.AddWithValue("OfechaParticipacion", objeto.getFechaPartic());

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
                    SqlCommand ing = new SqlCommand("update TB_IncendioForestal set estado = 0 where PK_Id_IncendioForestal = @id", coneccion);
                    ing.Parameters.AddWithValue("id", id);

                    coneccion.Open();
                    ing.ExecuteNonQuery();
                    coneccion.Close();
                    return true;
                }
                else
                {
                    SqlCommand ing = new SqlCommand("update TB_IncendioForestal set estado = 1 where PK_Id_IncendioForestal = @id", coneccion);
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
        public IncendForest seleccionar(int id)
        {
            if (!conectar())
            {
                return null;
            }

            try
            {
                SqlCommand ing = new SqlCommand("select lugar, fechaParticipacion from TB_IncendioForestal where PK_Id_IncendioForestal = @id", coneccion);
                ing.Parameters.AddWithValue("id", id);

                coneccion.Open();
                SqlDataReader objReader = ing.ExecuteReader();
                objReader.Read();
                IncendForest temp = new IncendForest(objReader.GetString(0), objReader.GetString(1));
                coneccion.Close();

                return temp;
            }
            catch
            {
                return null;
            }
        }

        //// seccion activos
        //public List<string> listaIncendForest()
        //{
        //    if (!conectar())
        //    {
        //        return null;
        //    }

        //    try
        //    {
        //        SqlCommand ing = new SqlCommand("select nombre_Capacitacion from TB_IncendioForestal where estado = 1", coneccion);

        //        coneccion.Open();
        //        SqlDataReader objReader = ing.ExecuteReader();
        //        List<string> temp = new List<string>();

        //        while (objReader.Read())
        //        {
        //            temp.Add(objReader.GetString(0));
        //        }

        //        coneccion.Close();

        //        return temp;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}

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
                        SqlDataAdapter temp1 = new SqlDataAdapter("select PK_Id_IncendioForestal, lugar, fechaParticipacion from TB_IncendioForestal where estado = 1", coneccion);
                        DataSet temp2 = new DataSet();
                        temp1.Fill(temp2);
                        return temp2;
                    }
                    else
                    {
                        SqlDataAdapter temp1 = new SqlDataAdapter("select PK_Id_IncendioForestal, lugar, fechaParticipacion from TB_IncendioForestal WHERE estado = 1 and " + columna + " " + operacion + " '" + valor + "'", coneccion);
                        DataSet temp2 = new DataSet();
                        temp1.Fill(temp2);
                        return temp2;
                    }
                }
                else
                {
                    if (columna == null || valor == null)
                    {
                        SqlDataAdapter temp1 = new SqlDataAdapter("select PK_Id_IncendioForestal, lugar, fechaParticipacion from TB_IncendioForestal where estado = 0", coneccion);
                        DataSet temp2 = new DataSet();
                        temp1.Fill(temp2);
                        return temp2;
                    }
                    else
                    {
                        SqlDataAdapter temp1 = new SqlDataAdapter("select PK_Id_IncendioForestal, lugar, fechaParticipacion from TB_IncendioForestal WHERE estado = 0 and " + columna + " " + operacion + " '" + valor + "'", coneccion);
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
                SqlCommand ing = new SqlCommand("select estado from TB_IncendioForestal where PK_Id_IncendioForestal = @id", coneccion);
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


        public string getLugar(int id)
        {
            if (!conectar())
            {
                return null;
            }

            try
            {
                SqlCommand ing = new SqlCommand("select lugar from TB_IncendioForestal where PK_Id_IncendioForestal = @id", coneccion);
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