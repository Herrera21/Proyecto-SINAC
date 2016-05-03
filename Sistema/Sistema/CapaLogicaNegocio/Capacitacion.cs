using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistema.CapaLogicaNegocio
{
    public class Capacitacion
    {
        private string nombre;
        private string lugarCap;
        private string institucion;
        private int cantHoras;
        private string fechaEmision;
        private string fechaCaducidad;

        public Capacitacion() { }

        public Capacitacion(string nombre, string lugarCap, string institucion, int cantHoras, string fechaEmision, string fechaCaducidad)
        {
            this.nombre = nombre;
            this.lugarCap = lugarCap;
            this.institucion = institucion;
            this.cantHoras = cantHoras;
            this.fechaEmision = fechaEmision;
            this.fechaCaducidad = fechaCaducidad;
        }

        public void setNombre(string nombre)
        {
            this.nombre = nombre;
        }

        public string getNombre()
        {
            return nombre;
        }

        public void setLugarCap(string lugarCap)
        {
            this.lugarCap = lugarCap;
        }

        public string getLugarCap()
        {
            return lugarCap;
        }

        public void setInstitucion(string institucion)
        {
            this.institucion = institucion;
        }

        public string getInstitucion()
        {
            return institucion;
        }

        public void setCantHoras(int cantHoras)
        {
            this.cantHoras = cantHoras;
        }

        public int getCantHoras()
        {
            return cantHoras;
        }

        public void setFechaEmision(string fechaEmision)
        {
            this.fechaEmision = fechaEmision;
        }

        public string getFechaEmision()
        {
            return fechaEmision;
        }

        public void setFechaCaducidad(string fechaCaducidad)
        {
            this.fechaCaducidad = fechaCaducidad;
        }

        public string getFechaCaducidad()
        {
            return fechaCaducidad;
        }
    }
}