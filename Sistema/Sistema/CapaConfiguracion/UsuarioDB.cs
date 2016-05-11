using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaLogica;
using System.Data.SqlClient;

namespace CapaConfiguracion
{
    public class UsuarioDB : ControlBD
    {
        public UsuarioDB()
        {
        }

        public bool insertar(Usuario objeto)
        {
            try
            {
                if (!conectar())
                {
                    return false;
                }

                SqlCommand ing = new SqlCommand("insert into TB_Usuario(PK_Id_Usuario, nombre, apellido1, apellido2, nickname, contrasenia, correo, rol, FK_Id_AreaConservación,estado) values (@identificacion, @nombre, @apellido1, @apellido2, @usuario, @pass, @correo, @rol, @areaConserv,1)", coneccion);
                ing.Parameters.AddWithValue("identificacion", objeto.getIdentificacion());
                ing.Parameters.AddWithValue("nombre", objeto.getNombre());
                ing.Parameters.AddWithValue("apellido1", objeto.getApellido1());
                ing.Parameters.AddWithValue("apellido2", objeto.getApellido2());
                ing.Parameters.AddWithValue("usuario", objeto.getUsuario());
                ing.Parameters.AddWithValue("correo", objeto.getCorreo());
                ing.Parameters.AddWithValue("pass", objeto.getPass());
                ing.Parameters.AddWithValue("rol", objeto.getRol());
                ing.Parameters.AddWithValue("areaConserv", objeto.getAreaConserv());
                

                coneccion.Open();
                ing.ExecuteNonQuery();
                coneccion.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool actualizar(string usuario, Usuario objeto)
        {
            if (!conectar())
            {
                return false;
            }

            try
            {
                SqlCommand ing = new SqlCommand("update TB_Usuario set PK_Id_Usuario = @Oidentificacion, nombre = @Onombre, apellido1 = @Oapellido1, apellido2 = @Oapellido2, nickname = @Ousuario, correo = @Ocorreo, rol = @Orol, FK_Id_AreaConservación = @OareaConserv where nickname = @usuario", coneccion);
                ing.Parameters.AddWithValue("Oidentificacion", objeto.getIdentificacion());
                ing.Parameters.AddWithValue("Onombre", objeto.getNombre());
                ing.Parameters.AddWithValue("Oapellido1", objeto.getApellido1());
                ing.Parameters.AddWithValue("Oapellido2", objeto.getApellido2());
                ing.Parameters.AddWithValue("Ousuario", objeto.getUsuario());
                ing.Parameters.AddWithValue("Ocorreo", objeto.getCorreo());
                ing.Parameters.AddWithValue("Orol", objeto.getRol());
                ing.Parameters.AddWithValue("OareaConserv", objeto.getAreaConserv());

                ing.Parameters.AddWithValue("usuario", usuario);

                coneccion.Open();
                ing.ExecuteNonQuery();
                coneccion.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool cambiaPass(string usuario, string pass)
        {
            if (!conectar())
            {
                return false;
            }

            try
            {
                SqlCommand ing = new SqlCommand("update TB_Usuario set contrasenia = @Opass where nickname = @usuario", coneccion);
                ing.Parameters.AddWithValue("Opass", pass);

                ing.Parameters.AddWithValue("usuario", usuario);

                coneccion.Open();
                ing.ExecuteNonQuery();
                coneccion.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Usuario seleccionar(string usuario)
        {
            if (!conectar())
            {
                return null;
            }

           try
            {
                SqlCommand ing = new SqlCommand("select PK_Id_Usuario, nombre, apellido1, apellido2, nickname, contrasenia, correo, rol, FK_Id_AreaConservación from TB_Usuario where nickname = @usuario", coneccion);
                ing.Parameters.AddWithValue("usuario", usuario);

                coneccion.Open();
                SqlDataReader objReader = ing.ExecuteReader();
                objReader.Read();
                Usuario temp = new Usuario(objReader.GetString(0), objReader.GetString(1), objReader.GetString(2), objReader.GetString(3), objReader.GetString(4), objReader.GetString(6), objReader.GetString(5), objReader.GetByte(7), objReader.GetInt32(8));
                coneccion.Close();

                return temp;
            }
            catch
            {
                return null;
            }
        }

        public Usuario seleccionarActivo(string usuario)
        {
            if (!conectar())
            {
                return null;
            }

            try
            {
                SqlCommand ing = new SqlCommand("select PK_Id_Usuario, nombre, apellido1, apellido2, nickname, contrasenia, correo, rol, FK_Id_AreaConservación from TB_Usuario where nickname = @usuario and estado = 1", coneccion);
                ing.Parameters.AddWithValue("usuario", usuario);

                coneccion.Open();
                SqlDataReader objReader = ing.ExecuteReader();
                objReader.Read();
                Usuario temp = new Usuario(objReader.GetString(0), objReader.GetString(1), objReader.GetString(2), objReader.GetString(3), objReader.GetString(4), objReader.GetString(6), objReader.GetString(5), objReader.GetByte(7), objReader.GetInt32(8));
                coneccion.Close();

                return temp;
            }
            catch
            {
                return null;
            }
        }

        public bool inactivar(bool estado, string usuario)
        {
            if (!conectar())
            {
                return false;
            }

            try
            {
                if (estado)
                {
                    SqlCommand ing = new SqlCommand("update TB_Usuario set estado = 0 where nickname = @usuario", coneccion);
                    ing.Parameters.AddWithValue("usuario", usuario);

                    coneccion.Open();
                    ing.ExecuteNonQuery();
                    coneccion.Close();

                    return true;
                }
                else
                {
                    SqlCommand ing = new SqlCommand("update TB_Usuario set estado = 1 where nickname = @usuario", coneccion);
                    ing.Parameters.AddWithValue("usuario", usuario);

                    coneccion.Open();
                    ing.ExecuteNonQuery();
                    coneccion.Close();

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public List<string> listaUsuarios()
        {
            if (!conectar())
            {
                return null;
            }

            try
            {
                SqlCommand ing = new SqlCommand("select nickname from TB_Usuario", coneccion);

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

        public bool getEstado(string usuario)
        {
            if (!conectar())
            {
                return false;
            }

            try
            {
                SqlCommand ing = new SqlCommand("select estado from TB_Usuario where nickname = @usuario", coneccion);
                ing.Parameters.AddWithValue("usuario", usuario);

                coneccion.Open();
                SqlDataReader objReader = ing.ExecuteReader();
                objReader.Read();
                bool temp = objReader.GetBoolean(0);
                coneccion.Close();

                return temp;
            }
            catch
            {
                return false;
            }
        }

        public bool existe(string usuario)
        {
            if (!conectar())
            {
                return false;
            }

            try
            {
                SqlCommand ing = new SqlCommand("select nickname from TB_Usuario where nickname = @usuario", coneccion);
                ing.Parameters.AddWithValue("usuario", usuario);

                coneccion.Open();
                SqlDataReader objReader = ing.ExecuteReader();
                objReader.Read();
                string temp = objReader.GetString(0);
                coneccion.Close();

                if (temp.Equals(null))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
