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
    public class BrigadaDB : ControlBD
    {
        public BrigadaDB()
        {
        }

        public bool insertar(Brigada objeto)
        {
            try
            {
                if (!conectar())
                {
                    return false;
                }

                if (objeto.getLider() == 0)
                {
                    SqlCommand ing = new SqlCommand("insert into TB_Brigada(nombre_Brigada, FK_Id_AreaConservacion, estado) values (@nombre, @idAreaConserv, 1)", coneccion);
                    ing.Parameters.AddWithValue("nombre", objeto.getNombre());
                    ing.Parameters.AddWithValue("idAreaConserv", objeto.getId_AreaConservacion());

                    coneccion.Open();
                    ing.ExecuteNonQuery();
                    coneccion.Close();
                }
                else
                {
                    SqlCommand ing = new SqlCommand("insert into TB_Brigada(nombre_Brigada, FK_Id_BomberoForestal, FK_Id_AreaConservacion, estado) values (@nombre, @liderBrig, @idAreaConserv, 1)", coneccion);
                    ing.Parameters.AddWithValue("nombre", objeto.getNombre());
                    ing.Parameters.AddWithValue("liderBrig", objeto.getLider());
                    ing.Parameters.AddWithValue("idAreaConserv", objeto.getId_AreaConservacion());

                    coneccion.Open();
                    ing.ExecuteNonQuery();
                    coneccion.Close();
                }
                
                return true;
        }
            catch
            {
                return false;
            }
        }

        public bool actualizar(string nombre, Brigada objeto)
        {
            if (!conectar())
            {
                return false;
            }

            try
            {
                if (objeto.getLider() == 0)
                {
                    SqlCommand ing = new SqlCommand("update TB_Brigada set nombre_Brigada = @Onombre, FK_Id_AreaConservacion = @Oid_AreaConservacion where nombre_Brigada = @nombre", coneccion);
                    ing.Parameters.AddWithValue("Onombre", objeto.getNombre());
                    ing.Parameters.AddWithValue("Oid_AreaConservacion", objeto.getId_AreaConservacion());
                    ing.Parameters.AddWithValue("nombre", nombre);
                    coneccion.Open();
                    ing.ExecuteNonQuery();
                    coneccion.Close();
                }
                else
                {
                    SqlCommand ing = new SqlCommand("update TB_Brigada set nombre_Brigada = @Onombre, FK_Id_BomberoForestal = @OliderBrig, FK_Id_AreaConservacion = @Oid_AreaConservacion where nombre_Brigada = @nombre", coneccion);
                    ing.Parameters.AddWithValue("Onombre", objeto.getNombre());
                    ing.Parameters.AddWithValue("Oid_AreaConservacion", objeto.getId_AreaConservacion());
                    ing.Parameters.AddWithValue("OliderBrig", objeto.getLider());
                    ing.Parameters.AddWithValue("nombre", nombre);

                    coneccion.Open();
                    ing.ExecuteNonQuery();
                    coneccion.Close();
                }
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
                    SqlCommand ing = new SqlCommand("update TB_Brigada set estado = 0 where nombre_Brigada = @nombre", coneccion);
                    ing.Parameters.AddWithValue("nombre", nombre);

                    coneccion.Open();
                    ing.ExecuteNonQuery();
                    coneccion.Close();
                    return true;
                }
                else
                {
                    SqlCommand ing = new SqlCommand("update TB_Brigada set estado = 1 where nombre_Brigada = @nombre", coneccion);
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

        public Brigada seleccionar(string nombre)
        {
            if (!conectar())
            {
                return null;
            }

            try
            {
                SqlCommand ing = new SqlCommand("select nombre_Brigada, FK_Id_BomberoForestal, FK_Id_AreaConservacion from TB_Brigada where nombre_Brigada = @nombre", coneccion);
                ing.Parameters.AddWithValue("nombre", nombre);

                coneccion.Open();
                SqlDataReader objReader = ing.ExecuteReader();
                objReader.Read();

                if (objReader.IsDBNull(1))
                {
                    Brigada temp = new Brigada(objReader.GetString(0), 0, objReader.GetInt32(2));
                    coneccion.Close();

                    return temp;
                }
                else
                {
                    Brigada temp = new Brigada(objReader.GetString(0), objReader.GetInt32(1), objReader.GetInt32(2));
                    coneccion.Close();

                    return temp;
                }

            }
            catch
            {
                return null;
            }
        }

        public DataSet seleccionar_Dataset(bool activo, string areaConserv, string columna, string operacion, string valor)
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
                        SqlDataAdapter temp1 = new SqlDataAdapter("SELECT nombre_Brigada, BF.nombre FROM TB_Brigada B Left join TB_BomberoForestal BF on FK_Id_BomberoForestal = PK_Id_Brigada inner join TB_AreasConservacion AC on AC.PK_Id_AreaConservación = FK_Id_AreaConservacion where B.estado = 1 and AC.nombre = '" + areaConserv + "'", coneccion);
                        DataSet temp2 = new DataSet();
                        temp1.Fill(temp2);
                        return temp2;
                    }
                    else
                    {
                        SqlDataAdapter temp1 = new SqlDataAdapter("SELECT nombre_Brigada, BF.nombre FROM TB_Brigada B Left join TB_BomberoForestal BF on FK_Id_BomberoForestal = PK_Id_Brigada inner join TB_AreasConservacion AC on AC.PK_Id_AreaConservación = FK_Id_AreaConservacion where B.estado = 1 and AC.nombre = '" + areaConserv + "' and " + columna + " " + operacion + " '" + valor + "'", coneccion);
                        DataSet temp2 = new DataSet();
                        temp1.Fill(temp2);
                        return temp2;
                    }
                }
                else
                {
                    if (columna == null || valor == null)
                    {
                        SqlDataAdapter temp1 = new SqlDataAdapter("SELECT nombre_Brigada, BF.nombre FROM TB_Brigada B Left join TB_BomberoForestal BF on FK_Id_BomberoForestal = PK_Id_Brigada inner join TB_AreasConservacion AC on AC.PK_Id_AreaConservación = FK_Id_AreaConservacion where B.estado = 0 and AC.nombre = '" + areaConserv + "'", coneccion);
                        DataSet temp2 = new DataSet();
                        temp1.Fill(temp2);
                        return temp2;
                    }
                    else
                    {
                        SqlDataAdapter temp1 = new SqlDataAdapter("SELECT nombre_Brigada, BF.nombre FROM TB_Brigada B Left join TB_BomberoForestal BF on FK_Id_BomberoForestal = PK_Id_Brigada inner join TB_AreasConservacion AC on AC.PK_Id_AreaConservación = FK_Id_AreaConservacion where B.estado = 0 and AC.nombre = '" + areaConserv + "' and " + columna + " " + operacion + " '" + valor + "'", coneccion);
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

        public List<string> listaBrigadas(string areaconserv)
        {
            if (!conectar())
            {
                return null;
            }

            try
            {
                SqlCommand ing = new SqlCommand("select nombre_Brigada from TB_Brigada inner join TB_AreasConservacion on TB_AreasConservacion.nombre = @areaconserv", coneccion);
                ing.Parameters.AddWithValue("areaconserv", areaconserv);

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

        public bool getEstado(string nombre)
        {
            if (!conectar())
            {
                return false;
            }

            try
            {
                SqlCommand ing = new SqlCommand("select estado FROM TB_Brigada where nombre_Brigada = @nombre", coneccion);
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
    }
}