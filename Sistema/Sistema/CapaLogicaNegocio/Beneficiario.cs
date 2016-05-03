using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistema.CapaLogicaNegocio
{
    public class Beneficiario : PersonaAbstract2
    {
        private int porcentaje;

        public Beneficiario() { }

        public Beneficiario(string identificacion, string nombre, string apellido1, string apellido2, string parentesco, int porcentaje)
        {
            this.identificacion = identificacion;
            this.nombre = nombre;
            this.apellido1 = apellido1;
            this.apellido2 = apellido2;
            this.parentesco = parentesco;
            this.porcentaje = porcentaje;
        }

        public void setPorcentaje(int porcentaje)
        {
            this.porcentaje = porcentaje;
        }

        public int getPorcentaje()
        {
            return porcentaje;
        }


    }
}