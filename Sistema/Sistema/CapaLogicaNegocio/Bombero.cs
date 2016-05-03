using Sistema.CapaLogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class Bombero : PersonaAbstract
    {
        private String provincia;
        private String canton;
        private String residencia;
        private String nacionalidad;
        private String fechaNac;
        private String telResidencia;
        private String telCelular;
        private String ocupacion;
        private String correo;
        private int aniosEnBriga;
        private int tipoBombe;
        private Byte[] imgPerfil;
        private Byte[] imgCed;
        private int id_Brigada;

        public Bombero()
        {
        }

        public Bombero(String identificacion, String nombre,
            String apellido1, String apellido2, int tipoBombe, String provincia, String canton, String residencia, String nacionalidad, String fechaNac,
            String telResidencia, String telCelular, String ocupacion, String correo, int aniosEnBriga, Byte[] imgPerfil, Byte[] imgCed, int id_Brigada)
        {
            this.identificacion = identificacion;
            this.id_Brigada = id_Brigada;
            this.nombre = nombre;
            this.apellido1 = apellido1;
            this.apellido2 = apellido2;
            this.provincia = provincia;
            this.canton = canton;
            this.residencia = residencia;
            this.nacionalidad = nacionalidad;
            this.fechaNac = fechaNac;
            this.telResidencia = telResidencia;
            this.telCelular = telCelular;
            this.ocupacion = ocupacion;
            this.correo = correo;
            this.aniosEnBriga = aniosEnBriga;
            this.tipoBombe = tipoBombe;
            this.imgPerfil = imgPerfil;
            this.imgCed = imgCed;
        }

        public void setProvincia(string provincia)
        {
            this.provincia = provincia;
        }

        public string getProvincia()
        {
            return provincia;
        }

        public void setCanton(string canton)
        {
            this.canton = canton;
        }

        public string getCanton()
        {
            return canton;
        }

        public void setResidencia(string residencia)
        {
            this.residencia = residencia;
        }

        public string getResidencia()
        {
            return residencia;
        }

        public void setNacionalidad(string nacionalidad)
        {
            this.nacionalidad = nacionalidad;
        }

        public string getNacionalidad()
        {
            return nacionalidad;
        }

        public void setFechaNac(string fechaNac)
        {
            this.fechaNac = fechaNac;
        }

        public string getFechaNac()
        {
            return fechaNac;
        }

        public void setTelResidencia(string telResidencia)
        {
            this.telResidencia = telResidencia;
        }

        public string getTelResidencia()
        {
            return telResidencia;
        }

        public void setTelCelular(string telCelular)
        {
            this.telCelular = telCelular;
        }

        public string getTelCelular()
        {
            return telCelular;
        }

        public void setOcupacion(string ocupacion)
        {
            this.ocupacion = ocupacion;
        }

        public string getOcupacion()
        {
            return ocupacion;
        }

        public void setCorreo(string correo)
        {
            this.correo = correo;
        }

        public string getCorreo()
        {
            return correo;
        }

        public void setAniosEnBriga(int aniosEnBriga)
        {
            this.aniosEnBriga = aniosEnBriga;
        }

        public int getAniosEnBriga()
        {
            return aniosEnBriga;
        }

        public void setTipoBombe(int tipoBombe)
        {
            this.tipoBombe = tipoBombe;
        }

        public int getTipoBombe()
        {
            return tipoBombe;
        }

        public void setImgPerfil(Byte[] imgPerfil)
        {
            this.imgPerfil = imgPerfil;
        }

        public Byte[] getImgPerfil()
        {
            return imgPerfil;
        }

        public void setImgCed(Byte[] imgCed)
        {
            this.imgCed = imgCed;
        }

        public Byte[] getImgCed()
        {
            return imgCed;
        }

        public void setId_Brigada(int id_Brigada)
        {
            this.id_Brigada = id_Brigada;
        }

        public int getId_Brigada()
        {
            return id_Brigada;
        }
    }
}