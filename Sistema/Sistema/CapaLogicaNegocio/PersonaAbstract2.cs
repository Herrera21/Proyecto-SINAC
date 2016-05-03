using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistema.CapaLogicaNegocio
{
    public class PersonaAbstract2 : PersonaAbstract
    {
        protected string parentesco;

        public PersonaAbstract2() { }

        public PersonaAbstract2(string identificacion, string nombre, string apellido1, string apellido2, string parentesco)
        {
            this.identificacion = identificacion;
            this.nombre = nombre;
            this.apellido1 = apellido1;
            this.apellido2 = apellido2;
            this.parentesco = parentesco;
        }

        public void setParentesco(string parentesco)
        {
            this.parentesco = parentesco;
        }

        public string getParentesco()
        {
            return parentesco;
        }
    }
}