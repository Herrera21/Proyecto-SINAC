using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistema.CapaLogicaNegocio
{
    public class PersonaAbstract
    {
        protected String identificacion;
        protected String nombre;
        protected String apellido1;
        protected String apellido2;

        public PersonaAbstract() { }

        public PersonaAbstract(String identificacion, String nombre, String apellido1, String apellido2)
        {
            this.identificacion = identificacion;
            this.nombre = nombre;
            this.apellido1 = apellido1;
            this.apellido2 = apellido2;
        }

        public void setIdentificacion(string identificacion)
        {
            this.identificacion = identificacion;
        }

        public string getIdentificacion()
        {
            return identificacion;
        }

        public void setNombre(string nombre)
        {
            this.nombre = nombre;
        }

        public string getNombre()
        {
            return nombre;
        }

        public void setApellido1(string apellido1)
        {
            this.apellido1 = apellido1;
        }

        public string getApellido1()
        {
            return apellido1;
        }

        public void setApellido2(string apellido2)
        {
            this.apellido2 = apellido2;
        }

        public string getApellido2()
        {
            return apellido2;
        }
    }
}