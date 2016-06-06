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
                //coneccion = new SqlConnection("Data Source=172.31.30.16; Initial Catalog=BD_SINAC; User Id=sa; Password=SistemaSNBFEH_SQL_235711;");
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
