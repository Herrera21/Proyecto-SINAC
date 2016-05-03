using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistema.CapaLogicaNegocio
{
    public class ContEmerg : PersonaAbstract2
    {
        private string telCelular;
        private string telCasa;

        public ContEmerg() { }

        public ContEmerg(string identificacion, string nombre, string apellido1, string apellido2, string parentesco, string telCelular, string telCasa)
        {
            this.identificacion = identificacion;
            this.nombre = nombre;
            this.apellido1 = apellido1;
            this.apellido2 = apellido2;
            this.parentesco = parentesco;
            this.telCelular = telCelular;
            this.telCasa = telCasa;
        }

        public void setTelCelular(string telCelular)
        {
            this.telCelular = telCelular;
        }

        public string getTelCelular()
        {
            return telCelular;
        }

        public void setTelCasa(string telCasa)
        {
            this.telCasa = telCasa;
        }

        public string getTelCasa()
        {
            return telCasa;
        }
    }
}