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
        private string lugarActiv;
        private string observaciones;

        public ActivPrevencion() { }

        public ActivPrevencion(string nombreActiv, string fechaActiv, string lugarActiv, string observaciones)
        {
            this.nombreActiv = nombreActiv;
            this.fechaActiv = fechaActiv;            
            this.lugarActiv = lugarActiv;
            this.observaciones = observaciones;
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

        public void setLugarActiv(string lugarActiv)
        {
            this.lugarActiv = lugarActiv;
        }

        public string getLugarActiv()
        {
            return lugarActiv;
        }

        public void setObservaciones(string observaciones)
        {
            this.observaciones = observaciones;
        }

        public string getObservaciones()
        {
            return observaciones;
        }
    }
}