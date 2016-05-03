﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class Brigada
    {
        private string nombre;
        private int lider;
        private int id_AreaConservacion;

        public Brigada()
        {
        }

        public Brigada(string nombre, int lider, int id_AreaConservacion)
        {
            this.nombre = nombre;
            this.id_AreaConservacion = id_AreaConservacion;
            this.lider = lider;
        }

        public void setId_AreaConservacion(int id_AreaConservacion)
        {
            this.id_AreaConservacion = id_AreaConservacion;
        }

        public int getId_AreaConservacion()
        {
            return id_AreaConservacion;
        }

        public void setNombre(string nombre)
        {
            this.nombre = nombre;
        }

        public string getNombre()
        {
            return nombre;
        }

        public void setLider(int lider)
        {
            this.lider = lider;
        }

        public int getLider()
        {
            return lider;
        }
    }
}