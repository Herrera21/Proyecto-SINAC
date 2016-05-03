using Sistema.CapaLogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class Usuario : PersonaAbstract
    {
        private string usuario;
        private string correo;
        private string pass;
        private byte rol;
        private int areaConserv;

        public Usuario()
        {
        }

        public Usuario(string identificacion, string nombre, string apellido1, string apellido2, string usuario, string correo, string pass, byte rol, int areaConserv)
        {
            this.identificacion = identificacion;
            this.nombre = nombre;
            this.apellido1 = apellido1;
            this.apellido2 = apellido2;
            this.usuario = usuario;
            this.correo = correo;
            this.pass = pass;
            this.rol = rol;
            this.areaConserv = areaConserv;
        }

        public void setUsuario(string usuario)
        {
            this.usuario = usuario;
        }

        public string getUsuario()
        {
            return usuario;
        }

        public void setCorreo(string correo)
        {
            this.correo = correo;
        }

        public string getCorreo()
        {
            return correo;
        }

        public void setPass(string pass)
        {
            this.pass = pass;
        }

        public string getPass()
        {
            return pass;
        }

        public void setRol(byte rol)
        {
            this.rol = rol;
        }

        public byte getRol()
        {
            return rol;
        }
        public void setAreaConserv(int areaConserv)
        {
            this.areaConserv = areaConserv;
        }

        public int getAreaConserv()
        {
            return areaConserv;
        }
    }
}
