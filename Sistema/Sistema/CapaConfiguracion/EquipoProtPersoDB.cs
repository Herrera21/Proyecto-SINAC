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
    public class EquipoProtPersoDB : ControlBD
    {
        public EquipoProtPersoDB() { }

        public bool insertar(EquipoProtecPerson objeto)
        {
            try
            {
                if (!conectar())
                {
                    return false;
                }

                SqlCommand ing = new SqlCommand("insert into TB_EquipoProtecPersonal(nombre, cantEntreg, fechaEntrega, estadoHerram, observaciones, estado, FK_Id_BomberoForestal) values (@nombre, @cantEntreg, @fechaEntrega, @estadoHerram, @observaciones, 1, @bomb)", coneccion);
                ing.Parameters.AddWithValue("nombre", objeto.getNombre());
                ing.Parameters.AddWithValue("cantEntreg", objeto.getCantEntre());
                ing.Parameters.AddWithValue("fechaEntrega", objeto.getFechaEntre());
                ing.Parameters.AddWithValue("estadoHerram", objeto.getEstadoHerram());
                ing.Parameters.AddWithValue("observaciones", objeto.getObservaciones());
                ing.Parameters.AddWithValue("bomb", objeto.getId_Bombero());

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

        public bool actualizar(int id, EquipoProtecPerson objeto)
        {
            if (!conectar())
            {
                return false;
            }

            try
            {
                SqlCommand ing = new SqlCommand("update TB_EquipoProtecPersonal set nombre = @Onombre, cantEntreg = @OcantEntreg, fechaEntrega = @OfechaEntrega, estadoHerram = @OestadoHerram, observaciones = @Oobservaciones where PK_Id_EquipoProtecPersonal = @id", coneccion);
                ing.Parameters.AddWithValue("Onombre", objeto.getNombre());
                ing.Parameters.AddWithValue("OcantEntreg", objeto.getCantEntre());
                ing.Parameters.AddWithValue("OfechaEntrega", objeto.getFechaEntre());
                ing.Parameters.AddWithValue("OestadoHerram", objeto.getEstadoHerram());
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
                    SqlCommand ing = new SqlCommand("update TB_EquipoProtecPersonal set estado = 0 where PK_Id_EquipoProtecPersonal = @id", coneccion);
                    ing.Parameters.AddWithValue("id", id);

                    coneccion.Open();
                    ing.ExecuteNonQuery();
                    coneccion.Close();
                    return true;
                }
                else
                {
                    SqlCommand ing = new SqlCommand("update TB_EquipoProtecPersonal set estado = 1 where PK_Id_EquipoProtecPersonal = @id", coneccion);
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
        public EquipoProtecPerson seleccionar(int id)
        {
            if (!conectar())
            {
                return null;
            }

            try
            {
                SqlCommand ing = new SqlCommand("select nombre, cantEntreg, fechaEntrega, estadoHerram, observaciones, FK_Id_BomberoForestal from TB_EquipoProtecPersonal where PK_Id_EquipoProtecPersonal = @id", coneccion);
                ing.Parameters.AddWithValue("id", id);

                coneccion.Open();
                SqlDataReader objReader = ing.ExecuteReader();
                objReader.Read();
                EquipoProtecPerson temp = new EquipoProtecPerson(objReader.GetString(0), objReader.GetInt32(1), objReader.GetString(2), objReader.GetString(3), objReader.GetString(4), objReader.GetString(5));
                coneccion.Close();

                return temp;
            }
            catch
            {
                return null;
            }
        }

        // filtros doble funcion
        public DataSet seleccionar_Dataset(bool activo, string bombero, string columna, string operacion, string valor)
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
                        SqlDataAdapter temp1 = new SqlDataAdapter("select PK_Id_EquipoProtecPersonal, nombre, cantEntreg, fechaEntrega, estadoHerram, observaciones from TB_EquipoProtecPersonal where estado = 1 and FK_Id_BomberoForestal = '" + bombero + "'", coneccion);
                        DataSet temp2 = new DataSet();
                        temp1.Fill(temp2);
                        return temp2;
                    }
                    else
                    {
                        SqlDataAdapter temp1 = new SqlDataAdapter("select PK_Id_EquipoProtecPersonal, nombre, cantEntreg, fechaEntrega, estadoHerram, observaciones from TB_EquipoProtecPersonal where estado = 1 and FK_Id_BomberoForestal = '" + bombero + "' and " + columna + " " + operacion + " '" + valor + "'", coneccion);
                        DataSet temp2 = new DataSet();
                        temp1.Fill(temp2);
                        return temp2;
                    }
                }
                else
                {
                    if (columna == null || valor == null)
                    {
                        SqlDataAdapter temp1 = new SqlDataAdapter("select PK_Id_EquipoProtecPersonal, nombre, cantEntreg, fechaEntrega, estadoHerram, observaciones from TB_EquipoProtecPersonal where estado = 0 and FK_Id_BomberoForestal = '" + bombero + "'", coneccion);
                        DataSet temp2 = new DataSet();
                        temp1.Fill(temp2);
                        return temp2;
                    }
                    else
                    {
                        SqlDataAdapter temp1 = new SqlDataAdapter("select PK_Id_EquipoProtecPersonal, nombre, cantEntreg, fechaEntrega, estadoHerram, observaciones from TB_EquipoProtecPersonal where estado = 0 and FK_Id_BomberoForestal = '" + bombero + "' and " + columna + " " + operacion + " '" + valor + "'", coneccion);
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
                SqlCommand ing = new SqlCommand("select estado from TB_EquipoProtecPersonal where PK_Id_EquipoProtecPersonal = @id", coneccion);
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
    }
}