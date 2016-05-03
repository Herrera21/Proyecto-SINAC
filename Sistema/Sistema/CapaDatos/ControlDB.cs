using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class ControlBD
    {
        protected SqlConnection coneccion;

        public  ControlBD()
        {
        }

        public bool conectar()
        {
            try
            {
                coneccion = new SqlConnection("Data Source=.; Initial Catalog=BD_SINAC;Integrated Security=true");
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
