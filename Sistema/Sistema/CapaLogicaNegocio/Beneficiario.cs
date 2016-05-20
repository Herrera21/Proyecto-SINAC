using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistema.CapaLogicaNegocio
{
    public class Beneficiario : PersonaAbstract2
    {
        private int porcentaje;
        private int id_BomPoliza;

        public Beneficiario() { }

        public Beneficiario(string identificacion, string nombre, string apellido1, string apellido2, string parentesco, int porcentaje, int id_BomPoliza)
        {
            this.identificacion = identificacion;
            this.nombre = nombre;
            this.apellido1 = apellido1;
            this.apellido2 = apellido2;
            this.parentesco = parentesco;
            this.porcentaje = porcentaje;
            this.id_BomPoliza = id_BomPoliza;
        }

        public void setPorcentaje(int porcentaje)
        {
            this.porcentaje = porcentaje;
        }

        public int getPorcentaje()
        {
            return porcentaje;
        }

        public void setId_BomPoliza(int id_BomPoliza)
        {
            this.id_BomPoliza = id_BomPoliza;
        }

        public int getId_BomPoliza()
        {
            return id_BomPoliza;
        }
    }
}