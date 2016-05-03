using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class Poliza
    {
        private string nombre;
        private int numero;
        private string inicioPeriodo;
        private string finPeriodo;
        private string observaciones;

        public Poliza()
        {
        }

        public Poliza(string nombre, int numero, string inicioPeriodo, string finPeriodo, string observaciones)
        {
            this.nombre = nombre;
            this.numero = numero;
            this.inicioPeriodo = inicioPeriodo;
            this.finPeriodo = finPeriodo;
            this.observaciones = observaciones;


        }

        public void setNombre(string nombre)
        {
            this.nombre = nombre;
        }

        public string getNombre()
        {
            return nombre;
        }

        public void setTipo(int tipo)
        {
            this.numero = tipo;
        }

        public int getNumero()
        {
            return numero;
        }

        public void setObservaciones(string observaciones)
        {
            this.observaciones = observaciones;
        }

        public string getObservaciones()
        {
            return observaciones;
        }

        public void setInicioPeriodo(string inicioPeriodo)
        {
            this.inicioPeriodo = inicioPeriodo;
        }

        public string getInicioPeriodo()
        {
            return inicioPeriodo;
        }

        public void setFinPeriodo(string finPeriodo)
        {
            this.finPeriodo = finPeriodo;
        }

        public string getFinPeriodo()
        {
            return finPeriodo;
        }


    }
}
