using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data.SqlClient;
using System.Data;

namespace CapaConfiguracion
{
    public class DistritoDB : ControlBD
    {
        public List<string> listaDistritos(string canton)
        {
            if (!conectar())
            {
                return null;
            }

            try
            {
                SqlCommand ing = new SqlCommand("select D.nombre from TB_Distrito D inner join TB_Canton C on D.numeroCanton = C.numeroCanton inner join TB_Provincia P on C.numeroProvincia = P.numeroProvincia where C.nombre = @canton and D.numeroCanton = C.numeroCanton and D.numeroProvincia = P.numeroProvincia", coneccion);
                ing.Parameters.AddWithValue("canton", canton);

                coneccion.Open();
                SqlDataReader objReader = ing.ExecuteReader();
                List<string> temp = new List<string>();

                while (objReader.Read())
                {
                    temp.Add(objReader.GetString(0));
                }

                coneccion.Close();

                return temp;
            }
            catch
            {
                return null;
            }
        }
    }
}