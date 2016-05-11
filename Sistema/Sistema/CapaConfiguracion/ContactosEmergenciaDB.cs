using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaLogica;
using System.Data.SqlClient;
using System.Data;
using Sistema.CapaLogicaNegocio;

namespace CapaConfiguracion
{
    public class ContactosEmergenciaDB : ControlBD
    {
        public ContactosEmergenciaDB() { }

        public bool insertar(ContEmerg objeto)
        {
            try
            {
                if (!conectar())
                {
                    return false;
                }

                SqlCommand ing = new SqlCommand("insert into TB_ContactoEmergencia(PK_Id_ContactoEmergencia, nombre, apellido1, apellido2, parentesco, telefonoResidencia, telefonoCelular, estado, FK_Id_BomberoForestal) values (@id, @nombre, @apellido1, @apellido2, @parentesco, @telefonoResidencia, @telefonoCelular, 1, @bomb)", coneccion);
                ing.Parameters.AddWithValue("id", objeto.getIdentificacion());
                ing.Parameters.AddWithValue("nombre", objeto.getNombre());
                ing.Parameters.AddWithValue("apellido1", objeto.getApellido1());
                ing.Parameters.AddWithValue("apellido2", objeto.getApellido2());
                ing.Parameters.AddWithValue("parentesco", objeto.getParentesco());
                ing.Parameters.AddWithValue("telefonoResidencia", objeto.getTelCasa());
                ing.Parameters.AddWithValue("telefonoCelular", objeto.getTelCelular());
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

        public bool actualizar(string id, ContEmerg objeto)
        {
            if (!conectar())
            {
                return false;
            }

            try
            {
                SqlCommand ing = new SqlCommand("update TB_ContactoEmergencia set nombre = @Onombre, apellido1 = @Oapellido1, apellido2 = @Oapellido2, parentesco = @Oparentesco, telefonoResidencia = @OtelefonoResidencia, telefonoCelular = @OtelefonoCelular where PK_Id_ContactoEmergencia = @id", coneccion);
                ing.Parameters.AddWithValue("Onombre", objeto.getNombre());
                ing.Parameters.AddWithValue("Oapellido1", objeto.getApellido1());
                ing.Parameters.AddWithValue("Oapellido2", objeto.getApellido2());
                ing.Parameters.AddWithValue("Oparentesco", objeto.getParentesco());
                ing.Parameters.AddWithValue("OtelefonoResidencia", objeto.getTelCasa());
                ing.Parameters.AddWithValue("OtelefonoCelular", objeto.getTelCelular());

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

        public bool inactivar(bool inactiva, string id)
        {
            if (!conectar())
            {
                return false;
            }

            try
            {
                if (inactiva)
                {
                    SqlCommand ing = new SqlCommand("update TB_ContactoEmergencia set estado = 0 where PK_Id_ContactoEmergencia = @id", coneccion);
                    ing.Parameters.AddWithValue("id", id);

                    coneccion.Open();
                    ing.ExecuteNonQuery();
                    coneccion.Close();
                    return true;
                }
                else
                {
                    SqlCommand ing = new SqlCommand("update TB_ContactoEmergencia set estado = 1 where PK_Id_ContactoEmergencia = @id", coneccion);
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
        public ContEmerg seleccionar(string id)
        {
            if (!conectar())
            {
                return null;
            }

            try
            {
                SqlCommand ing = new SqlCommand("select PK_Id_ContactoEmergencia, nombre, apellido1, apellido2, parentesco, telefonoResidencia, telefonoCelular, FK_Id_BomberoForestal from TB_ContactoEmergencia where PK_Id_ContactoEmergencia = @id", coneccion);
                ing.Parameters.AddWithValue("id", id);

                coneccion.Open();
                SqlDataReader objReader = ing.ExecuteReader();
                objReader.Read();
                ContEmerg temp = new ContEmerg(objReader.GetString(0), objReader.GetString(1), objReader.GetString(2), objReader.GetString(3), objReader.GetString(4), objReader.GetString(5), objReader.GetString(6), objReader.GetString(7));
                coneccion.Close();

                return temp;
            }
            catch
            {
                return null;
            }
        }

        // filtros doble funcion
        public DataSet seleccionar_Dataset(bool activo, string id, string columna, string operacion, string valor)
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
                        SqlDataAdapter temp1 = new SqlDataAdapter("select PK_Id_ContactoEmergencia, nombre, apellido1, apellido2, parentesco, telefonoResidencia, telefonoCelular from TB_ContactoEmergencia where estado = 1 and FK_Id_BomberoForestal = '" + id + "'", coneccion);
                        DataSet temp2 = new DataSet();
                        temp1.Fill(temp2);
                        return temp2;
                    }
                    else
                    {
                        SqlDataAdapter temp1 = new SqlDataAdapter("select PK_Id_ContactoEmergencia, nombre, apellido1, apellido2, parentesco, telefonoResidencia, telefonoCelular from TB_ContactoEmergencia where estado = 1 and FK_Id_BomberoForestal = '" + id + "' and " + columna + " " + operacion + " '" + valor + "'", coneccion);
                        DataSet temp2 = new DataSet();
                        temp1.Fill(temp2);
                        return temp2;
                    }
                }
                else
                {
                    if (columna == null || valor == null)
                    {
                        SqlDataAdapter temp1 = new SqlDataAdapter("select PK_Id_ContactoEmergencia, nombre, apellido1, apellido2, parentesco, telefonoResidencia, telefonoCelular from TB_ContactoEmergencia where estado = 0 and FK_Id_BomberoForestal = '" + id + "'", coneccion);
                        DataSet temp2 = new DataSet();
                        temp1.Fill(temp2);
                        return temp2;
                    }
                    else
                    {
                        SqlDataAdapter temp1 = new SqlDataAdapter("select PK_Id_ContactoEmergencia, nombre, apellido1, apellido2, parentesco, telefonoResidencia, telefonoCelular from TB_ContactoEmergencia where estado = 0 and FK_Id_BomberoForestal = '" + id + "' and " + columna + " " + operacion + " '" + valor + "'", coneccion);
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

        public bool getEstado(string id)
        {
            if (!conectar())
            {
                return false;
            }

            try
            {
                SqlCommand ing = new SqlCommand("select estado from TB_ContactoEmergencia where PK_Id_ContactoEmergencia = @id", coneccion);
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