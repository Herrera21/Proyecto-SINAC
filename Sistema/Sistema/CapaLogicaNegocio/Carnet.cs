using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistema.CapaLogicaNegocio
{
    public class Carnet
    {
        private int anioCarnet;
        private string emisionCarnet;
        private string fechaVencimiento;
        private string id_Bombero;

        public Carnet() { }

        public Carnet(int anioCarnet, string emisionCarnet, string fechaVencimiento, string id_Bombero)
        {
            this.anioCarnet = anioCarnet;
            this.emisionCarnet = emisionCarnet;
            this.fechaVencimiento = fechaVencimiento;
            this.id_Bombero = id_Bombero;
        }

        public void setAnioCarnet(int anioCarnet)
        {
            this.anioCarnet = anioCarnet;
        }

        public int getAnioCarnet()
        {
            return anioCarnet;
        }

        public void setEmisionCarnet(string emisionCarnet)
        {
            this.emisionCarnet = emisionCarnet;
        }

        public string getEmisionCarnet()
        {
            return emisionCarnet;
        }

        public void setFechaVencimiento(string fechaVencimiento)
        {
            this.fechaVencimiento = fechaVencimiento;
        }

        public string getFechaVencimiento()
        {
            return fechaVencimiento;
        }

        public void setId_Bombero(string id_Bombero)
        {
            this.id_Bombero = id_Bombero;
        }

        public string getId_Bombero()
        {
            return id_Bombero;
        }
    }
}