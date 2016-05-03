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
    public class PolizaDB : ControlBD
    {
        public PolizaDB()
        {
        }

        public bool insertar(Poliza objeto)
        {
            try
            {
                if (!conectar())
                {
                    return false;
                }

                SqlCommand ing = new SqlCommand("insert into TB_Poliza(PK_Id_Poliza, nombre_Poliza, inicioPeriodo, finPeriodo, observaciones,estado) values (@numero, @nombre, @inicioPeriodo, @finPeriodo, @observaciones, 1)", coneccion);
                ing.Parameters.AddWithValue("nombre", objeto.getNombre());
                ing.Parameters.AddWithValue("numero", objeto.getNumero());
                ing.Parameters.AddWithValue("inicioPeriodo", objeto.getInicioPeriodo());
                ing.Parameters.AddWithValue("finPeriodo", objeto.getFinPeriodo());
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

        public bool actualizar(Poliza objeto)
        {
            if (!conectar())
            {
                return false;
            }

            try
            {
                SqlCommand ing = new SqlCommand("update TB_Poliza set nombre_Poliza = @Onombre, inicioPeriodo = @OinicioPeriodo, finPeriodo = @OfinPeriodo, observaciones = @Oobservaciones where PK_Id_Poliza = @numero", coneccion);
                ing.Parameters.AddWithValue("Onombre", objeto.getNombre());
                ing.Parameters.AddWithValue("OinicioPeriodo", objeto.getInicioPeriodo());
                ing.Parameters.AddWithValue("OfinPeriodo", objeto.getFinPeriodo());
                ing.Parameters.AddWithValue("Oobservaciones", objeto.getObservaciones());

                ing.Parameters.AddWithValue("numero", objeto.getNumero());


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
                    SqlCommand ing = new SqlCommand("update TB_Poliza set estado = 0 where PK_Id_Poliza = @id", coneccion);
                    ing.Parameters.AddWithValue("id", id);

                    coneccion.Open();
                    ing.ExecuteNonQuery();
                    coneccion.Close();
                    return true;
                }
                else
                {
                    SqlCommand ing = new SqlCommand("update TB_Poliza set estado = 1 where PK_Id_Poliza = @id", coneccion);
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

        public Poliza seleccionar(int numero)
        {
            if (!conectar())
            {
                return null;
            }

            try
            {
                SqlCommand ing = new SqlCommand("select nombre_Poliza,PK_Id_Poliza,inicioPeriodo,finPeriodo,observaciones from TB_poliza where PK_Id_Poliza = @numero", coneccion);
                ing.Parameters.AddWithValue("numero", numero);

                coneccion.Open();
                SqlDataReader objReader = ing.ExecuteReader();
                objReader.Read();
                Poliza temp = new Poliza(objReader.GetString(0), objReader.GetInt32(1), objReader.GetString(2), objReader.GetString(3), objReader.GetString(4));
                coneccion.Close();

                return temp;
            }
            catch
            {
                return null;
            }
        }

        public List<string> listaBrigadas()
        {
            if (!conectar())
            {
                return null;
            }

            try
            {
                SqlCommand ing = new SqlCommand("select nombre_Poliza from TB_poliza", coneccion);

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
                        SqlDataAdapter temp1 = new SqlDataAdapter("select PK_Id_Poliza, nombre_Poliza, inicioPeriodo, finPeriodo from TB_Poliza where estado = 1", coneccion);
                        DataSet temp2 = new DataSet();
                        temp1.Fill(temp2);
                        return temp2;
                    }
                    else
                    {
                        SqlDataAdapter temp1 = new SqlDataAdapter("select PK_Id_Poliza, nombre_Poliza, inicioPeriodo, finPeriodo from TB_Poliza WHERE estado = 1 and " + columna + " " + operacion + " '" + valor + "'", coneccion);
                        DataSet temp2 = new DataSet();
                        temp1.Fill(temp2);
                        return temp2;
                    }
                }
                else
                {
                    if (columna == null || valor == null)
                    {
                        SqlDataAdapter temp1 = new SqlDataAdapter("select PK_Id_Poliza, nombre_Poliza, inicioPeriodo, finPeriodo from TB_Poliza where estado = 0", coneccion);
                        DataSet temp2 = new DataSet();
                        temp1.Fill(temp2);
                        return temp2;
                    }
                    else
                    {
                        SqlDataAdapter temp1 = new SqlDataAdapter("select PK_Id_Poliza, nombre_Poliza, inicioPeriodo, finPeriodo from TB_Poliza WHERE estado = 0 and " + columna + " " + operacion + " '" + valor + "'", coneccion);
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
                SqlCommand ing = new SqlCommand("select estado from TB_Poliza where PK_Id_Poliza = @id", coneccion);
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
