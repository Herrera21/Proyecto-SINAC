using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistema.CapaLogicaNegocio
{
    public class EquipoProtecPerson
    {
        private string equipo;
        private int cantEntre;
        private string ubicacion;
        private string fechaEntre;
        private bool estado;
        private string motivoEstMal;

        public EquipoProtecPerson() { }

        public EquipoProtecPerson(string equipo, int cantEntre, string ubicacion, string fechaEntre, bool estado, string motivoEstMal)
        {
            this.equipo = equipo;
            this.cantEntre = cantEntre;
            this.ubicacion = ubicacion;
            this.fechaEntre = fechaEntre;
            this.estado = estado;
            this.motivoEstMal = motivoEstMal;
        }

        public void setEquipo(string equipo)
        {
            this.equipo = equipo;
        }

        public string getEquipo()
        {
            return this.equipo;
        }

        public void setCantEntre(int cantEntre)
        {
            this.cantEntre = cantEntre;
        }

        public int getCantEntre()
        {
            return this.cantEntre;
        }

        public void setUbicacion(string ubicacion)
        {
            this.ubicacion = ubicacion;
        }

        public string getUbicacion()
        {
            return this.ubicacion;
        }

        public void setFechaEntre(string fechaEntre)
        {
            this.fechaEntre = fechaEntre;
        }

        public string getFechaEntre()
        {
            return this.fechaEntre;
        }

        public void setEstado(bool estado)
        {
            this.estado = estado;
        }

        public bool getEstado()
        {
            return this.estado;
        }

        public void setMotivoEstMal(string motivoEstMal)
        {
            this.motivoEstMal = motivoEstMal;
        }

        public string getMotivoEstMal()
        {
            return this.motivoEstMal;
        }
    }
}