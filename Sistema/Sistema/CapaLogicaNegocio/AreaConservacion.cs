using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class AreaConservacion
    {
        private string nombre;
        private string abreviatura;
        private string ubicacion;

        public AreaConservacion()
        {
        }

        public AreaConservacion(string nombre, string abreviatura, string ubicacion)
        {
            this.nombre = nombre;
            this.abreviatura = abreviatura;
            this.ubicacion = ubicacion;
        }

        public void setNombre(string nombre)
        {
            this.nombre = nombre;
        }

        public string getNombre()
        {
            return nombre;
        }

        public void setAbreviatura(string abreviatura)
        {
            this.abreviatura = abreviatura;
        }

        public string getAbreviatura()
        {
            return abreviatura;
        }

        public void setUbicacion(string ubicacion)
        {
            this.ubicacion = ubicacion;
        }

        public string getUbicacion()
        {
            return ubicacion;
        }
    }
}
