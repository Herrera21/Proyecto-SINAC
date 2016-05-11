
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

        public ReseniaMedicaDB(byte v1, string text1, byte v2, string text2, byte v3, string text3, byte v4, string text4, byte v5, string text5, byte v6, string text6, string text7, string v7)
        {
        }

        public bool insertar(ReseniaMedic objeto)
        {
            try
            {
                if (!conectar())
                {
                    return false;
                }

                SqlCommand ing = new SqlCommand("insert into TB_ReseniaMedica(PK_FK_Id_BomberoForestal, internado, motivoIN, tratamientoMedico, motivoTM, lenteContacto, motivoLC, operado, motivoOP, limitacionFisica, tipoLimitFisic, checkMedic, diagnostico, tipoSangre) values (@id, @internado, @nombre, @motivoIN, @tratamientoMedico, @motivoTM, @lenteContacto, @motivoLC, @operado, @motivoOP, @limitacionFisica, @tipoLimitFisic, @checkMedic, @diagnostico, @tipoSangre)", coneccion);
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

         
    }
}