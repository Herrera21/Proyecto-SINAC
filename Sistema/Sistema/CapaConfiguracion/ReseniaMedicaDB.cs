
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
        private string text1;
        private string text2;
        private string text3;
        private string text4;
        private string text5;
        private string text6;
        private string text7;
        private byte v1;
        private byte v2;
        private byte v3;
        private byte v4;
        private byte v5;
        private byte v6;
        private string v7;

        public ReseniaMedicaDB() { }

        public ReseniaMedicaDB(byte v1, string text1, byte v2, string text2, byte v3, string text3, byte v4, string text4, byte v5, string text5, byte v6, string text6, string text7, string v7)
        {
            this.v1 = v1;
            this.text1 = text1;
            this.v2 = v2;
            this.text2 = text2;
            this.v3 = v3;
            this.text3 = text3;
            this.v4 = v4;
            this.text4 = text4;
            this.v5 = v5;
            this.text5 = text5;
            this.v6 = v6;
            this.text6 = text6;
            this.text7 = text7;
            this.v7 = v7;
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