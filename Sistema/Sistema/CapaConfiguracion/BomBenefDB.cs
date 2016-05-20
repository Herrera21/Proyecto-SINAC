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
    public class BomBenefDB : ControlBD
    {
        public BomBenefDB() { }

        public bool insertar(Beneficiario objeto)
        {
            try
            {
                if (!conectar())
                {
                    return false;
                }

                SqlCommand ing = new SqlCommand("insert into TB_Beneficiarios(identificacion, nombre, apellido1, apellido2, parentesco, porcentajePoliza, estado, FK_Id_BomberoPoliza) values (@identificacion, @nombre, @apellido1, @apellido2, @parentesco, @porcentajePoliza, 1, @id_BomPoliza)", coneccion);
                ing.Parameters.AddWithValue("identificacion", objeto.getIdentificacion());
                ing.Parameters.AddWithValue("nombre", objeto.getNombre());
                ing.Parameters.AddWithValue("apellido1", objeto.getApellido1());
                ing.Parameters.AddWithValue("apellido2", objeto.getApellido2());
                ing.Parameters.AddWithValue("parentesco", objeto.getParentesco());
                ing.Parameters.AddWithValue("porcentajePoliza", objeto.getPorcentaje());
                ing.Parameters.AddWithValue("id_BomPoliza", objeto.getId_BomPoliza());


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

        public bool actualizar(int id, Beneficiario objeto)
        {
            if (!conectar())
            {
                return false;
            }

            try
            {
                SqlCommand ing = new SqlCommand("update TB_Beneficiarios set nombre = @Onombre, apellido1 = @Oapellido1, apellido2 = @Oapellido2, parentesco = @Oparentesco, porcentajePoliza = @OporcentajePoliza where PK_Id_Beneficiario = @id", coneccion);
                ing.Parameters.AddWithValue("Onombre", objeto.getNombre());
                ing.Parameters.AddWithValue("Oapellido1", objeto.getApellido1());
                ing.Parameters.AddWithValue("Oapellido2", objeto.getApellido2());
                ing.Parameters.AddWithValue("Oparentesco", objeto.getParentesco());
                ing.Parameters.AddWithValue("OporcentajePoliza", objeto.getPorcentaje());

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
                    SqlCommand ing = new SqlCommand("update TB_Beneficiarios set estado = 0 where PK_Id_Beneficiario = @id", coneccion);
                    ing.Parameters.AddWithValue("id", id);

                    coneccion.Open();
                    ing.ExecuteNonQuery();
                    coneccion.Close();
                    return true;
                }
                else
                {
                    SqlCommand ing = new SqlCommand("update TB_Beneficiarios set estado = 1 where PK_Id_Beneficiario = @id", coneccion);
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

        public Beneficiario seleccionar(int id)
        {
            if (!conectar())
            {
                return null;
            }

            try
            {
                SqlCommand ing = new SqlCommand("select identificacion, nombre, apellido1, apellido2, parentesco, porcentajePoliza, FK_Id_BomberoPoliza from TB_Beneficiarios where PK_Id_Beneficiario = @id", coneccion);
                ing.Parameters.AddWithValue("id", id);

                coneccion.Open();
                SqlDataReader objReader = ing.ExecuteReader();
                objReader.Read();
                Beneficiario temp = new Beneficiario(objReader.GetString(0), objReader.GetString(1), objReader.GetString(2), objReader.GetString(3), objReader.GetString(4), objReader.GetInt32(5), objReader.GetInt32(6));
                coneccion.Close();

                return temp;
            }
            catch
            {
                return null;
            }
        }

        public DataSet seleccionar_Dataset(bool activo, int IdBomPoliza, string columna, string operacion, string valor)
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
                        SqlDataAdapter temp1 = new SqlDataAdapter("select PK_Id_Beneficiario, identificacion, nombre, apellido1, apellido2, parentesco, porcentajePoliza from TB_Beneficiarios where FK_Id_BomberoPoliza = " + IdBomPoliza + " and estado = 1", coneccion);
                        DataSet temp2 = new DataSet();
                        temp1.Fill(temp2);
                        return temp2;
                    }
                    else
                    {
                        SqlDataAdapter temp1 = new SqlDataAdapter("select PK_Id_Beneficiario, identificacion, nombre, apellido1, apellido2, parentesco, porcentajePoliza from TB_Beneficiarios where FK_Id_BomberoPoliza = " + IdBomPoliza + " and  estado = 1 and " + columna + " " + operacion + " '" + valor + "'", coneccion);
                        DataSet temp2 = new DataSet();
                        temp1.Fill(temp2);
                        return temp2;
                    }
                }
                else
                {
                    if (columna == null || valor == null)
                    {
                        SqlDataAdapter temp1 = new SqlDataAdapter("select PK_Id_Beneficiario, identificacion, nombre, apellido1, apellido2, parentesco, porcentajePoliza from TB_Beneficiarios where FK_Id_BomberoPoliza = " + IdBomPoliza + " and  estado = 0", coneccion);
                        DataSet temp2 = new DataSet();
                        temp1.Fill(temp2);
                        return temp2;
                    }
                    else
                    {
                        SqlDataAdapter temp1 = new SqlDataAdapter("select PK_Id_Beneficiario, identificacion, nombre, apellido1, apellido2, parentesco, porcentajePoliza from TB_Beneficiarios where FK_Id_BomberoPoliza = " + IdBomPoliza + " and  estado = 0 and " + columna + " " + operacion + " '" + valor + "'", coneccion);
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
                SqlCommand ing = new SqlCommand("select estado from TB_Beneficiarios where PK_Id_Beneficiario = @id", coneccion);
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
        //public string getNombre(int id)
        //{
        //    if (!conectar())
        //    {
        //        return null;
        //    }

        //    try
        //    {
        //        SqlCommand ing = new SqlCommand("select nombre_Poliza from TB_Beneficiarios where PK_Id_Beneficiario = @id", coneccion);
        //        ing.Parameters.AddWithValue("id", id);

        //        coneccion.Open();
        //        SqlDataReader objReader = ing.ExecuteReader();
        //        objReader.Read();
        //        string temp = objReader.GetString(0);
        //        coneccion.Close();

        //        return temp;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}
    }
}