using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistema.CapaLogicaNegocio
{
    public class ActivPrevencion
    {
        private string nombreActiv;
        private string fechaActiv;
        private int cantHorasPart;
        private string lugarActiv;

        public ActivPrevencion() { }

        public ActivPrevencion(string nombreActiv, string fechaActiv, int cantHorasPart, string lugarActiv)
        {
            this.nombreActiv = nombreActiv;
            this.fechaActiv = fechaActiv;
            this.cantHorasPart = cantHorasPart;
            this.lugarActiv = lugarActiv;
        }

        public void setNombreActiv(string nombreActiv)
        {
            this.nombreActiv = nombreActiv;
        }

        public string getNombreActiv()
        {
            return nombreActiv;
        }

        public void setFechaActiv(string fechaActiv)
        {
            this.fechaActiv = fechaActiv;
        }

        public string getFechaActiv()
        {
            return fechaActiv;
        }

        public void setCantHorasPart(int cantHorasPart)
        {
            this.cantHorasPart = cantHorasPart;
        }

        public int getCantHorasPart()
        {
            return cantHorasPart;
        }

        public void setLugarActiv(string lugarActiv)
        {
            this.lugarActiv = lugarActiv;
        }

        public string getLugarActiv()
        {
            return lugarActiv;
        }
    }
}