using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CapaConfiguracion;
using CapaLogica;

namespace Sistema
{
    public class Logear
    {
        public Logear()
        {
        }
        public static bool activo(string usuario)
        {
            try
            {
                UsuarioDB userDB = new UsuarioDB();

                return userDB.getEstado(usuario);
            }
            catch
            {
                return false;
            }
        }

        public static bool login(string usuario, string pass)
        {
            try
            {
                UsuarioDB userDB = new UsuarioDB();
                Usuario temp = userDB.seleccionarActivo(usuario);
                if (temp != null && pass == temp.getPass())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}