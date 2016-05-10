using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaLogica
{
    public class EquipoProtecPerson
    {
        private string nombre;
        private int cantEntre;
        private string fechaEntre;
        private string estadoHerram;
        private string observaciones;
        private string id_Bombero;

        public EquipoProtecPerson() { }

        public EquipoProtecPerson(string nombre, int cantEntre, string fechaEntre, string estadoHerram, string observaciones, string id_Bombero)
        {
            this.nombre = nombre;
            this.cantEntre = cantEntre;
            this.fechaEntre = fechaEntre;
            this.estadoHerram = estadoHerram;
            this.observaciones = observaciones;
            this.id_Bombero = id_Bombero;
        }

        public void setNombre(string nombre)
        {
            this.nombre = nombre;
        }

        public string getNombre()
        {
            return this.nombre;
        }

        public void setCantEntre(int cantEntre)
        {
            this.cantEntre = cantEntre;
        }

        public int getCantEntre()
        {
            return this.cantEntre;
        }

        public void setFechaEntre(string fechaEntre)
        {
            this.fechaEntre = fechaEntre;
        }

        public string getFechaEntre()
        {
            return this.fechaEntre;
        }

        public void setEstadoHerram(string estadoHerram)
        {
            this.estadoHerram = estadoHerram;
        }

        public string getEstadoHerram()
        {
            return this.estadoHerram;
        }

        public void setObservaciones(string observaciones)
        {
            this.observaciones = observaciones;
        }

        public string getObservaciones()
        {
            return this.observaciones;
        }

        public void setId_Bombero(string id_Bombero)
        {
            this.id_Bombero = id_Bombero;
        }

        public string getId_Bombero()
        {
            return this.id_Bombero;
        }
    }
}