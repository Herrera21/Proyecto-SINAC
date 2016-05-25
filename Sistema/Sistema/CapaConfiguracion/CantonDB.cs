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
    public class CantonDB : ControlBD
    {
        public List<string> listaCantones(string provincia)
        {
            if (!conectar())
            {
                return null;
            }

            try
            {
                SqlCommand ing = new SqlCommand("select C.nombre from TB_Canton C inner join TB_Provincia P on C.numeroProvincia = P.numeroProvincia where P.nombre = @provincia", coneccion);
                ing.Parameters.AddWithValue("provincia", provincia);

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