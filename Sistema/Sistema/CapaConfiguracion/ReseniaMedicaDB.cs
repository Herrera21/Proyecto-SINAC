
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
    public class ReseniaMedicaDB : ControlBD
    {
        public ReseniaMedicaDB() { }

        public bool insertar(ReseniaMedic objeto)
        {
            try
            {
                if (!conectar())
                {
                    return false;
                }

                SqlCommand ing = new SqlCommand("insert into TB_ReseniaMedica(PK_FK_Id_BomberoForestal, internado, motivoIN, tratamientoMedico, motivoTM, lenteContacto, motivoLC, operado, motivoOP, limitacionFisica, tipoLimitFisic, checkMedic, diagnostico, tipoSangre) values (@id_Bombero, @internado, @motivoIN, @tratamientoMedico, @motivoTM, @lenteContacto, @motivoLC, @operado, @motivoOP, @limitacionFisica, @tipoLimitFisic, @checkMedic, @diagnostico, @tipoSangre)", coneccion);
                ing.Parameters.AddWithValue("id_Bombero", objeto.getId_Bombero());
                ing.Parameters.AddWithValue("internado", objeto.getInternado());
                ing.Parameters.AddWithValue("motivoIN", objeto.getMotivoIN());
                ing.Parameters.AddWithValue("tratamientoMedico", objeto.getTratMedic());
                ing.Parameters.AddWithValue("motivoTM", objeto.getMotivoTM());
                ing.Parameters.AddWithValue("lenteContacto", objeto.getLentCont());
                ing.Parameters.AddWithValue("motivoLC", objeto.getMotivoLC());
                ing.Parameters.AddWithValue("operado", objeto.getOperado());
                ing.Parameters.AddWithValue("motivoOP", objeto.getMotivoOP());
                ing.Parameters.AddWithValue("limitacionFisica", objeto.getLimitFisic());
                ing.Parameters.AddWithValue("tipoLimitFisic", objeto.getLimitFisic());
                ing.Parameters.AddWithValue("checkMedic", objeto.getCheckMedic());
                ing.Parameters.AddWithValue("diagnostico", objeto.getDiagnostico());
                ing.Parameters.AddWithValue("tipoSangre", objeto.getTipoSangre());


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

        public bool actualizar(string id, ReseniaMedic objeto)
        {
            if (!conectar())
            {
                return false;
            }

            try
            {
                SqlCommand ing = new SqlCommand("update TB_ReseniaMedica set internado = @Ointernado, motivoIN = @OmotivoIN, tratamientoMedico = @OtratamientoMedico, motivoTM = @OmotivoTM, lenteContacto = @OlenteContacto, motivoLC = @OmotivoLC, operado = @Ooperado, motivoOP = @OmotivoOP, limitacionFisica = @OlimitacionFisica, tipoLimitFisic = @OtipoLimitFisic, checkMedic = @OcheckMedic, diagnostico = @Odiagnostico, tipoSangre = @OtipoSangre where PK_FK_Id_BomberoForestal = @id", coneccion);
                ing.Parameters.AddWithValue("Ointernado", objeto.getInternado());
                ing.Parameters.AddWithValue("OmotivoIN", objeto.getMotivoIN());
                ing.Parameters.AddWithValue("OtratamientoMedico", objeto.getTratMedic());
                ing.Parameters.AddWithValue("OmotivoTM", objeto.getMotivoTM());
                ing.Parameters.AddWithValue("OlenteContacto", objeto.getLentCont());
                ing.Parameters.AddWithValue("OmotivoLC", objeto.getMotivoLC());
                ing.Parameters.AddWithValue("Ooperado", objeto.getOperado());
                ing.Parameters.AddWithValue("OmotivoOP", objeto.getMotivoOP());
                ing.Parameters.AddWithValue("OlimitacionFisica", objeto.getLimitFisic());
                ing.Parameters.AddWithValue("OtipoLimitFisic", objeto.getLimitFisic());
                ing.Parameters.AddWithValue("OcheckMedic", objeto.getCheckMedic());
                ing.Parameters.AddWithValue("Odiagnostico", objeto.getDiagnostico());
                ing.Parameters.AddWithValue("OtipoSangre", objeto.getTipoSangre());

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

        public ReseniaMedic seleccionar(string id)
        {
            if (!conectar())
            {
                return null;
            }

            try
            {
                SqlCommand ing = new SqlCommand("select internado, motivoIN, tratamientoMedico, motivoTM, lenteContacto, motivoLC, operado, motivoOP, limitacionFisica, tipoLimitFisic, checkMedic, diagnostico, tipoSangre, PK_FK_Id_BomberoForestal from TB_ReseniaMedica where PK_FK_Id_BomberoForestal = @id", coneccion);
                ing.Parameters.AddWithValue("id", id);

                coneccion.Open();
                SqlDataReader objReader = ing.ExecuteReader();
                objReader.Read();
                ReseniaMedic temp = new ReseniaMedic(objReader.GetBoolean(0), objReader.GetString(1), objReader.GetBoolean(2), objReader.GetString(3), objReader.GetBoolean(4), objReader.GetString(5), objReader.GetBoolean(6), objReader.GetString(7), objReader.GetBoolean(8), objReader.GetString(9), objReader.GetBoolean(10), objReader.GetString(11), objReader.GetString(12), objReader.GetString(13));
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