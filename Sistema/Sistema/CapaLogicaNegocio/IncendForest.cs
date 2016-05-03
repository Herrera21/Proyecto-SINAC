using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistema.CapaLogicaNegocio
{
    public class IncendForest
    {
        private string lugar;
        private string fechaPartic;

        public IncendForest() { }

        public IncendForest(string lugar, string fechaPartic)
        {
            this.lugar = lugar;
            this.fechaPartic = fechaPartic;
        }

        public void setLugar(string lugar)
        {
            this.lugar = lugar;
        }

        public string getLugar()
        {
            return lugar;
        }

        public void setFechaPartic(string fechaPartic)
        {
            this.fechaPartic = fechaPartic;
        }

        public string getFechaPartic()
        {
            return fechaPartic;
        }
    }
}