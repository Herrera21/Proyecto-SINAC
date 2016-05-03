using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaLogica;
using System.Data.SqlClient;
using System.Data;

namespace CapaConfiguracion
{
    public class AreaConservacionDB : ControlBD
    {
        public AreaConservacionDB()
        {
        }

        public bool insertar(AreaConservacion objeto)
        {
            try
            {
                if (!conectar())
                {
                    return false;
                }

                SqlCommand ing = new SqlCommand("insert into TB_AreasConservacion(nombre, abreviatura, ubicacion, estado) values (@nombre, @abreviatura, @ubicacion, 1)", coneccion);
                ing.Parameters.AddWithValue("nombre", objeto.getNombre());
                ing.Parameters.AddWithValue("abreviatura", objeto.getAbreviatura());
                ing.Parameters.AddWithValue("ubicacion", objeto.getUbicacion());

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

        public bool actualizar(string nombre, AreaConservacion objeto)
        {
            if (!conectar())
            {
                return false;
            }

            try
            {
                SqlCommand ing = new SqlCommand("update TB_AreasConservacion set nombre = @Onombre, abreviatura = @Oabreviatura, ubicacion = @Oubicacion where nombre = @nombre", coneccion);
                ing.Parameters.AddWithValue("Onombre", objeto.getNombre());
                ing.Parameters.AddWithValue("Oabreviatura", objeto.getAbreviatura());
                ing.Parameters.AddWithValue("Oubicacion", objeto.getUbicacion());

                ing.Parameters.AddWithValue("nombre", nombre);

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

        public bool inactivar(bool inactiva, string nombre)
        {
            if (!conectar())
            {
                return false;
            }

            try
            {
                if (inactiva)
                {
                    SqlCommand ing = new SqlCommand("update TB_AreasConservacion set estado = 0 where nombre = @nombre", coneccion);
                    ing.Parameters.AddWithValue("nombre", nombre);

                    coneccion.Open();
                    ing.ExecuteNonQuery();
                    coneccion.Close();
                    return true;
                }
                else
                {
                    SqlCommand ing = new SqlCommand("update TB_AreasConservacion set estado = 1 where nombre = @nombre", coneccion);
                    ing.Parameters.AddWithValue("nombre", nombre);

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
        public AreaConservacion seleccionar(string nombre)
        {
            if (!conectar())
            {
                return null;
            }

            try
            {
                SqlCommand ing = new SqlCommand("select nombre,abreviatura,ubicacion from TB_AreasConservacion where nombre = @nombre", coneccion);
                ing.Parameters.AddWithValue("nombre", nombre);

                coneccion.Open();
                SqlDataReader objReader = ing.ExecuteReader();
                objReader.Read();
                AreaConservacion temp = new AreaConservacion(objReader.GetString(0), objReader.GetString(1), objReader.GetString(2));
                coneccion.Close();

                return temp;
            }
            catch
            {
                return null;
            }
        }

        // seccion activos
        public List<string> listaAreasConserv()
        {
            if (!conectar())
            {
                return null;
            }

            try
            {
                SqlCommand ing = new SqlCommand("select nombre from TB_AreasConservacion where estado = 1", coneccion);

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
                        SqlDataAdapter temp1 = new SqlDataAdapter("select nombre, abreviatura, ubicacion from TB_AreasConservacion where estado = 1", coneccion);
                        DataSet temp2 = new DataSet();
                        temp1.Fill(temp2);
                        return temp2;
                    }
                    else
                    {
                        SqlDataAdapter temp1 = new SqlDataAdapter("select nombre, abreviatura, ubicacion from TB_AreasConservacion WHERE estado = 1 and " + columna + " " + operacion + " '" + valor + "'", coneccion);
                        DataSet temp2 = new DataSet();
                        temp1.Fill(temp2);
                        return temp2;
                    }
                }
                else
                {
                    if (columna == null || valor == null)
                    {
                        SqlDataAdapter temp1 = new SqlDataAdapter("select nombre, abreviatura, ubicacion from TB_AreasConservacion where estado = 0", coneccion);
                        DataSet temp2 = new DataSet();
                        temp1.Fill(temp2);
                        return temp2;
                    }
                    else
                    {
                        SqlDataAdapter temp1 = new SqlDataAdapter("select nombre, abreviatura, ubicacion from TB_AreasConservacion WHERE estado = 0 and " + columna + " " + operacion + " '" + valor + "'", coneccion);
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

        public int getId(string nombre)
        {
            if (!conectar())
            {
                return -1;
            }

            try
            {
                SqlCommand ing = new SqlCommand("select PK_Id_AreaConservación from TB_AreasConservacion where nombre = @nombre", coneccion);
                ing.Parameters.AddWithValue("nombre", nombre);

                coneccion.Open();
                SqlDataReader objReader = ing.ExecuteReader();
                objReader.Read();
                int temp = objReader.GetInt32(0);
                coneccion.Close();

                return temp;
            }
            catch
            {
                return -1;
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
                SqlCommand ing = new SqlCommand("select nombre from TB_AreasConservacion where PK_Id_AreaConservación = @id", coneccion);
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

        public bool getEstado(string nombre)
        {
            if (!conectar())
            {
                return false;
            }

            try
            {
                SqlCommand ing = new SqlCommand("select estado from TB_AreasConservacion where nombre = @nombre", coneccion);
                ing.Parameters.AddWithValue("nombre", nombre);

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

        public bool poseeUsers(string nombre)
        {
            if (!conectar())
            {
                return false;
            }

            try
            {
                SqlCommand ing = new SqlCommand("select PK_Id_Usuario from TB_Usuario U join TB_AreasConservacion A on U.FK_Id_AreaConservación = A.PK_Id_AreaConservación where U.estado = 1 and A.nombre = @nombre", coneccion);
                ing.Parameters.AddWithValue("nombre", nombre);

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