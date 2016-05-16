using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaLogica;
using System.Data.SqlClient;
using System.Data;

namespace CapaConfiguracion
{
    public class BomberoDB : ControlBD
    {
        public BomberoDB()
        {
        }

        public bool insertar(Bombero objeto)
        {
            try
            {
                if (!conectar())
                {
                    return false;
                }

                if (objeto.getImgPerfil() == null && objeto.getImgCed() == null)
                {
                    SqlCommand ing = new SqlCommand("insert into TB_BomberoForestal(PK_Id_BomberoForestal, nombre, apellido1, apellido2, tipoBombero, provincia, canton, lugarResidencia, nacionalidad, fechaNacimiento, telefonoResidencia, telefonoCelular, ocupacion, correoElectronico, aniosBrigada, imagenPerfil, imagenCedula, FK_Id_Brigada, estado) values (@identificacion, @nombre, @apellido1, @apellido2, @tipoBombero, @provincia, @canton, @lugarResidencia, @nacionalidad, @fechaNacimiento, @telefonoResidencia, @telefonoCelular, @ocupacion, @correoElectronico, @aniosBrigada, @imagenPerfil, @imagenCedula, @IdBrigada, 1)", coneccion);
                    ing.Parameters.AddWithValue("identificacion", objeto.getIdentificacion());
                    ing.Parameters.AddWithValue("nombre", objeto.getNombre());
                    ing.Parameters.AddWithValue("apellido1", objeto.getApellido1());
                    ing.Parameters.AddWithValue("apellido2", objeto.getApellido2());
                    ing.Parameters.AddWithValue("tipoBombero", objeto.getTipoBombe());
                    ing.Parameters.AddWithValue("provincia", objeto.getProvincia());
                    ing.Parameters.AddWithValue("canton", objeto.getCanton());
                    ing.Parameters.AddWithValue("lugarResidencia", objeto.getResidencia());
                    ing.Parameters.AddWithValue("nacionalidad", objeto.getNacionalidad());
                    ing.Parameters.AddWithValue("fechaNacimiento", objeto.getFechaNac());
                    ing.Parameters.AddWithValue("telefonoResidencia", objeto.getTelResidencia());
                    ing.Parameters.AddWithValue("telefonoCelular", objeto.getTelCelular());
                    ing.Parameters.AddWithValue("ocupacion", objeto.getOcupacion());
                    ing.Parameters.AddWithValue("correoElectronico", objeto.getCorreo());
                    ing.Parameters.AddWithValue("aniosBrigada", objeto.getAniosEnBriga());
                    ing.Parameters.AddWithValue("imagenPerfil", 0);
                    ing.Parameters.AddWithValue("imagenCedula", 0);
                    ing.Parameters.AddWithValue("IdBrigada", objeto.getId_Brigada());

                    coneccion.Open();
                    ing.ExecuteNonQuery();
                    coneccion.Close();
                }
                else
                {
                    if (objeto.getImgPerfil() == null && objeto.getImgCed() != null)
                    {
                        SqlCommand ing = new SqlCommand("insert into TB_BomberoForestal(PK_Id_BomberoForestal, nombre, apellido1, apellido2, tipoBombero, provincia, canton, lugarResidencia, nacionalidad, fechaNacimiento, telefonoResidencia, telefonoCelular, ocupacion, correoElectronico, aniosBrigada, imagenPerfil, imagenCedula, FK_Id_Brigada, estado) values (@identificacion, @nombre, @apellido1, @apellido2, @tipoBombero, @provincia, @canton, @lugarResidencia, @nacionalidad, @fechaNacimiento, @telefonoResidencia, @telefonoCelular, @ocupacion, @correoElectronico, @aniosBrigada, @imagenPerfil, @imagenCedula, @IdBrigada, 1)", coneccion);
                        ing.Parameters.AddWithValue("identificacion", objeto.getIdentificacion());
                        ing.Parameters.AddWithValue("nombre", objeto.getNombre());
                        ing.Parameters.AddWithValue("apellido1", objeto.getApellido1());
                        ing.Parameters.AddWithValue("apellido2", objeto.getApellido2());
                        ing.Parameters.AddWithValue("tipoBombero", objeto.getTipoBombe());
                        ing.Parameters.AddWithValue("provincia", objeto.getProvincia());
                        ing.Parameters.AddWithValue("canton", objeto.getCanton());
                        ing.Parameters.AddWithValue("lugarResidencia", objeto.getResidencia());
                        ing.Parameters.AddWithValue("nacionalidad", objeto.getNacionalidad());
                        ing.Parameters.AddWithValue("fechaNacimiento", objeto.getFechaNac());
                        ing.Parameters.AddWithValue("telefonoResidencia", objeto.getTelResidencia());
                        ing.Parameters.AddWithValue("telefonoCelular", objeto.getTelCelular());
                        ing.Parameters.AddWithValue("ocupacion", objeto.getOcupacion());
                        ing.Parameters.AddWithValue("correoElectronico", objeto.getCorreo());
                        ing.Parameters.AddWithValue("aniosBrigada", objeto.getAniosEnBriga());
                        ing.Parameters.AddWithValue("imagenPerfil", 0);
                        ing.Parameters.AddWithValue("imagenCedula", objeto.getImgCed());
                        ing.Parameters.AddWithValue("IdBrigada", objeto.getId_Brigada());

                        coneccion.Open();
                        ing.ExecuteNonQuery();
                        coneccion.Close();
                    }
                    else
                    {
                        if (objeto.getImgPerfil() != null && objeto.getImgCed() == null)
                        {
                            SqlCommand ing = new SqlCommand("insert into TB_BomberoForestal(PK_Id_BomberoForestal, nombre, apellido1, apellido2, tipoBombero, provincia, canton, lugarResidencia, nacionalidad, fechaNacimiento, telefonoResidencia, telefonoCelular, ocupacion, correoElectronico, aniosBrigada, imagenPerfil, imagenCedula, FK_Id_Brigada, estado) values (@identificacion, @nombre, @apellido1, @apellido2, @tipoBombero, @provincia, @canton, @lugarResidencia, @nacionalidad, @fechaNacimiento, @telefonoResidencia, @telefonoCelular, @ocupacion, @correoElectronico, @aniosBrigada, @imagenPerfil, @imagenCedula, @IdBrigada, 1)", coneccion);
                            ing.Parameters.AddWithValue("identificacion", objeto.getIdentificacion());
                            ing.Parameters.AddWithValue("nombre", objeto.getNombre());
                            ing.Parameters.AddWithValue("apellido1", objeto.getApellido1());
                            ing.Parameters.AddWithValue("apellido2", objeto.getApellido2());
                            ing.Parameters.AddWithValue("tipoBombero", objeto.getTipoBombe());
                            ing.Parameters.AddWithValue("provincia", objeto.getProvincia());
                            ing.Parameters.AddWithValue("canton", objeto.getCanton());
                            ing.Parameters.AddWithValue("lugarResidencia", objeto.getResidencia());
                            ing.Parameters.AddWithValue("nacionalidad", objeto.getNacionalidad());
                            ing.Parameters.AddWithValue("fechaNacimiento", objeto.getFechaNac());
                            ing.Parameters.AddWithValue("telefonoResidencia", objeto.getTelResidencia());
                            ing.Parameters.AddWithValue("telefonoCelular", objeto.getTelCelular());
                            ing.Parameters.AddWithValue("ocupacion", objeto.getOcupacion());
                            ing.Parameters.AddWithValue("correoElectronico", objeto.getCorreo());
                            ing.Parameters.AddWithValue("aniosBrigada", objeto.getAniosEnBriga());
                            ing.Parameters.AddWithValue("imagenPerfil", objeto.getImgPerfil());
                            ing.Parameters.AddWithValue("imagenCedula", 0);
                            ing.Parameters.AddWithValue("IdBrigada", objeto.getId_Brigada());

                            coneccion.Open();
                            ing.ExecuteNonQuery();
                            coneccion.Close();
                        }
                        else
                        {
                            SqlCommand ing = new SqlCommand("insert into TB_BomberoForestal(PK_Id_BomberoForestal, nombre, apellido1, apellido2, tipoBombero, provincia, canton, lugarResidencia, nacionalidad, fechaNacimiento, telefonoResidencia, telefonoCelular, ocupacion, correoElectronico, aniosBrigada, imagenPerfil, imagenCedula, FK_Id_Brigada, estado) values (@identificacion, @nombre, @apellido1, @apellido2, @tipoBombero, @provincia, @canton, @lugarResidencia, @nacionalidad, @fechaNacimiento, @telefonoResidencia, @telefonoCelular, @ocupacion, @correoElectronico, @aniosBrigada, @imagenPerfil, @imagenCedula, @IdBrigada, 1)", coneccion);
                            ing.Parameters.AddWithValue("identificacion", objeto.getIdentificacion());
                            ing.Parameters.AddWithValue("nombre", objeto.getNombre());
                            ing.Parameters.AddWithValue("apellido1", objeto.getApellido1());
                            ing.Parameters.AddWithValue("apellido2", objeto.getApellido2());
                            ing.Parameters.AddWithValue("tipoBombero", objeto.getTipoBombe());
                            ing.Parameters.AddWithValue("provincia", objeto.getProvincia());
                            ing.Parameters.AddWithValue("canton", objeto.getCanton());
                            ing.Parameters.AddWithValue("lugarResidencia", objeto.getResidencia());
                            ing.Parameters.AddWithValue("nacionalidad", objeto.getNacionalidad());
                            ing.Parameters.AddWithValue("fechaNacimiento", objeto.getFechaNac());
                            ing.Parameters.AddWithValue("telefonoResidencia", objeto.getTelResidencia());
                            ing.Parameters.AddWithValue("telefonoCelular", objeto.getTelCelular());
                            ing.Parameters.AddWithValue("ocupacion", objeto.getOcupacion());
                            ing.Parameters.AddWithValue("correoElectronico", objeto.getCorreo());
                            ing.Parameters.AddWithValue("aniosBrigada", objeto.getAniosEnBriga());
                            ing.Parameters.AddWithValue("imagenPerfil", objeto.getImgPerfil());
                            ing.Parameters.AddWithValue("imagenCedula", objeto.getImgCed());
                            ing.Parameters.AddWithValue("IdBrigada", objeto.getId_Brigada());

                            coneccion.Open();
                            ing.ExecuteNonQuery();
                            coneccion.Close();
                        }
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool actualizar(string identificacion, Bombero objeto)
        {
            if (!conectar())
            {
                return false;
            }

            try
            {
                if (objeto.getImgPerfil() == null && objeto.getImgCed() == null)
                {
                    SqlCommand ing = new SqlCommand("update TB_BomberoForestal set PK_Id_BomberoForestal = @Oidentificacion, nombre = @Onombre, apellido1 = @Oapellido1, apellido2 = @Oapellido2, tipoBombero = @OtipoBombero, provincia = @Oprovincia, canton = @Ocanton, lugarResidencia = @OlugarResidencia, nacionalidad = @Onacionalidad, fechaNacimiento = @OfechaNacimiento, telefonoResidencia = @OtelefonoResidencia, telefonoCelular = @OtelefonoCelular, ocupacion = @Oocupacion, correoElectronico = @OcorreoElectronico, aniosBrigada = @OaniosBrigada, FK_Id_Brigada = @OIdBrigada where PK_Id_BomberoForestal = @identificacion", coneccion);
                    ing.Parameters.AddWithValue("Oidentificacion", objeto.getIdentificacion());
                    ing.Parameters.AddWithValue("Onombre", objeto.getNombre());
                    ing.Parameters.AddWithValue("Oapellido1", objeto.getApellido1());
                    ing.Parameters.AddWithValue("Oapellido2", objeto.getApellido2());
                    ing.Parameters.AddWithValue("OtipoBombero", objeto.getTipoBombe());
                    ing.Parameters.AddWithValue("Oprovincia", objeto.getProvincia());
                    ing.Parameters.AddWithValue("Ocanton", objeto.getCanton());
                    ing.Parameters.AddWithValue("OlugarResidencia", objeto.getResidencia());
                    ing.Parameters.AddWithValue("Onacionalidad", objeto.getNacionalidad());
                    ing.Parameters.AddWithValue("OfechaNacimiento", objeto.getFechaNac());
                    ing.Parameters.AddWithValue("OtelefonoResidencia", objeto.getTelResidencia());
                    ing.Parameters.AddWithValue("OtelefonoCelular", objeto.getTelCelular());
                    ing.Parameters.AddWithValue("Oocupacion", objeto.getOcupacion());
                    ing.Parameters.AddWithValue("OcorreoElectronico", objeto.getCorreo());
                    ing.Parameters.AddWithValue("OaniosBrigada", objeto.getAniosEnBriga());
                    ing.Parameters.AddWithValue("OIdBrigada", objeto.getId_Brigada());

                    ing.Parameters.AddWithValue("identificacion", identificacion);

                    coneccion.Open();
                    ing.ExecuteNonQuery();
                    coneccion.Close();
                }
                else
                {
                    if (objeto.getImgPerfil() == null && objeto.getImgCed() != null)
                    {
                        SqlCommand ing = new SqlCommand("update TB_BomberoForestal set PK_Id_BomberoForestal = @Oidentificacion, nombre = @Onombre, apellido1 = @Oapellido1, apellido2 = @Oapellido2, tipoBombero = @OtipoBombero, provincia = @Oprovincia, canton = @Ocanton, lugarResidencia = @OlugarResidencia, nacionalidad = @Onacionalidad, fechaNacimiento = @OfechaNacimiento, telefonoResidencia = @OtelefonoResidencia, telefonoCelular = @OtelefonoCelular, ocupacion = @Oocupacion, correoElectronico = @OcorreoElectronico, aniosBrigada = @OaniosBrigada, imagenCedula = @OimagenCedula, FK_Id_Brigada = @OIdBrigada where PK_Id_BomberoForestal = @identificacion", coneccion);
                        ing.Parameters.AddWithValue("Oidentificacion", objeto.getIdentificacion());
                        ing.Parameters.AddWithValue("Onombre", objeto.getNombre());
                        ing.Parameters.AddWithValue("Oapellido1", objeto.getApellido1());
                        ing.Parameters.AddWithValue("Oapellido2", objeto.getApellido2());
                        ing.Parameters.AddWithValue("OtipoBombero", objeto.getTipoBombe());
                        ing.Parameters.AddWithValue("Oprovincia", objeto.getProvincia());
                        ing.Parameters.AddWithValue("Ocanton", objeto.getCanton());
                        ing.Parameters.AddWithValue("OlugarResidencia", objeto.getResidencia());
                        ing.Parameters.AddWithValue("Onacionalidad", objeto.getNacionalidad());
                        ing.Parameters.AddWithValue("OfechaNacimiento", objeto.getFechaNac());
                        ing.Parameters.AddWithValue("OtelefonoResidencia", objeto.getTelResidencia());
                        ing.Parameters.AddWithValue("OtelefonoCelular", objeto.getTelCelular());
                        ing.Parameters.AddWithValue("Oocupacion", objeto.getOcupacion());
                        ing.Parameters.AddWithValue("OcorreoElectronico", objeto.getCorreo());
                        ing.Parameters.AddWithValue("OaniosBrigada", objeto.getAniosEnBriga());
                        ing.Parameters.AddWithValue("OimagenCedula", objeto.getImgCed());
                        ing.Parameters.AddWithValue("OIdBrigada", objeto.getId_Brigada());

                        ing.Parameters.AddWithValue("identificacion", identificacion);

                        coneccion.Open();
                        ing.ExecuteNonQuery();
                        coneccion.Close();
                    }
                    else
                    {
                        if (objeto.getImgPerfil() != null && objeto.getImgCed() == null)
                        {
                            SqlCommand ing = new SqlCommand("update TB_BomberoForestal set PK_Id_BomberoForestal = @Oidentificacion, nombre = @Onombre, apellido1 = @Oapellido1, apellido2 = @Oapellido2, tipoBombero = @OtipoBombero, provincia = @Oprovincia, canton = @Ocanton, lugarResidencia = @OlugarResidencia, nacionalidad = @Onacionalidad, fechaNacimiento = @OfechaNacimiento, telefonoResidencia = @OtelefonoResidencia, telefonoCelular = @OtelefonoCelular, ocupacion = @Oocupacion, correoElectronico = @OcorreoElectronico, aniosBrigada = @OaniosBrigada, imagenPerfil = @OimagenPerfil, FK_Id_Brigada = @OIdBrigada where PK_Id_BomberoForestal = @identificacion", coneccion);
                            ing.Parameters.AddWithValue("Oidentificacion", objeto.getIdentificacion());
                            ing.Parameters.AddWithValue("Onombre", objeto.getNombre());
                            ing.Parameters.AddWithValue("Oapellido1", objeto.getApellido1());
                            ing.Parameters.AddWithValue("Oapellido2", objeto.getApellido2());
                            ing.Parameters.AddWithValue("OtipoBombero", objeto.getTipoBombe());
                            ing.Parameters.AddWithValue("Oprovincia", objeto.getProvincia());
                            ing.Parameters.AddWithValue("Ocanton", objeto.getCanton());
                            ing.Parameters.AddWithValue("OlugarResidencia", objeto.getResidencia());
                            ing.Parameters.AddWithValue("Onacionalidad", objeto.getNacionalidad());
                            ing.Parameters.AddWithValue("OfechaNacimiento", objeto.getFechaNac());
                            ing.Parameters.AddWithValue("OtelefonoResidencia", objeto.getTelResidencia());
                            ing.Parameters.AddWithValue("OtelefonoCelular", objeto.getTelCelular());
                            ing.Parameters.AddWithValue("Oocupacion", objeto.getOcupacion());
                            ing.Parameters.AddWithValue("OcorreoElectronico", objeto.getCorreo());
                            ing.Parameters.AddWithValue("OaniosBrigada", objeto.getAniosEnBriga());
                            ing.Parameters.AddWithValue("OimagenPerfil", objeto.getImgPerfil());
                            ing.Parameters.AddWithValue("OIdBrigada", objeto.getId_Brigada());

                            ing.Parameters.AddWithValue("identificacion", identificacion);

                            coneccion.Open();
                            ing.ExecuteNonQuery();
                            coneccion.Close();
                        }
                        else
                        {
                            SqlCommand ing = new SqlCommand("update TB_BomberoForestal set PK_Id_BomberoForestal = @Oidentificacion, nombre = @Onombre, apellido1 = @Oapellido1, apellido2 = @Oapellido2, tipoBombero = @OtipoBombero, provincia = @Oprovincia, canton = @Ocanton, lugarResidencia = @OlugarResidencia, nacionalidad = @Onacionalidad, fechaNacimiento = @OfechaNacimiento, telefonoResidencia = @OtelefonoResidencia, telefonoCelular = @OtelefonoCelular, ocupacion = @Oocupacion, correoElectronico = @OcorreoElectronico, aniosBrigada = @OaniosBrigada, imagenPerfil = @OimagenPerfil, imagenCedula = @OimagenCedula, FK_Id_Brigada = @OIdBrigada where PK_Id_BomberoForestal = @identificacion", coneccion);
                            ing.Parameters.AddWithValue("Oidentificacion", objeto.getIdentificacion());
                            ing.Parameters.AddWithValue("Onombre", objeto.getNombre());
                            ing.Parameters.AddWithValue("Oapellido1", objeto.getApellido1());
                            ing.Parameters.AddWithValue("Oapellido2", objeto.getApellido2());
                            ing.Parameters.AddWithValue("OtipoBombero", objeto.getTipoBombe());
                            ing.Parameters.AddWithValue("Oprovincia", objeto.getProvincia());
                            ing.Parameters.AddWithValue("Ocanton", objeto.getCanton());
                            ing.Parameters.AddWithValue("OlugarResidencia", objeto.getResidencia());
                            ing.Parameters.AddWithValue("Onacionalidad", objeto.getNacionalidad());
                            ing.Parameters.AddWithValue("OfechaNacimiento", objeto.getFechaNac());
                            ing.Parameters.AddWithValue("OtelefonoResidencia", objeto.getTelResidencia());
                            ing.Parameters.AddWithValue("OtelefonoCelular", objeto.getTelCelular());
                            ing.Parameters.AddWithValue("Oocupacion", objeto.getOcupacion());
                            ing.Parameters.AddWithValue("OcorreoElectronico", objeto.getCorreo());
                            ing.Parameters.AddWithValue("OaniosBrigada", objeto.getAniosEnBriga());
                            ing.Parameters.AddWithValue("OimagenPerfil", objeto.getImgPerfil());
                            ing.Parameters.AddWithValue("OimagenCedula", objeto.getImgCed());
                            ing.Parameters.AddWithValue("OIdBrigada", objeto.getId_Brigada());

                            ing.Parameters.AddWithValue("identificacion", identificacion);

                            coneccion.Open();
                            ing.ExecuteNonQuery();
                            coneccion.Close();
                        }
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool inactivar(bool inactiva, string identificacion)
        {
            if (!conectar())
            {
                return false;
            }

            try
            {
                if (inactiva)
                {
                    SqlCommand ing = new SqlCommand("update TB_BomberoForestal set estado = 0 where PK_Id_BomberoForestal = @identificacion", coneccion);
                    ing.Parameters.AddWithValue("identificacion", identificacion);

                    coneccion.Open();
                    ing.ExecuteNonQuery();
                    coneccion.Close();
                    return true;
                }
                else
                {
                    SqlCommand ing = new SqlCommand("update TB_BomberoForestal set estado = 1 where PK_Id_BomberoForestal = @identificacion", coneccion);
                    ing.Parameters.AddWithValue("identificacion", identificacion);

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

        public Bombero seleccionar(string identificacion)
        {
            if (!conectar())
            {
                return null;
            }

            try
            {
                SqlCommand ing = new SqlCommand("select PK_Id_BomberoForestal, nombre, apellido1, apellido2, tipoBombero, provincia, canton, lugarResidencia, nacionalidad, fechaNacimiento, telefonoResidencia, telefonoCelular, ocupacion, correoElectronico, aniosBrigada, imagenPerfil, imagenCedula, FK_Id_Brigada from TB_BomberoForestal where PK_Id_BomberoForestal = @identificacion", coneccion);
                ing.Parameters.AddWithValue("identificacion", identificacion);

                coneccion.Open();
                SqlDataReader objReader = ing.ExecuteReader();
                objReader.Read();
                Bombero temp = new Bombero(objReader.GetString(0), objReader.GetString(1),
                objReader.GetString(2), objReader.GetString(3), objReader.GetInt32(4), objReader.GetString(5), objReader.GetString(6), objReader.GetString(7), objReader.GetString(8),
                 objReader.GetString(9), objReader.GetString(10), objReader.GetString(11), objReader.GetString(12), objReader.GetString(13), objReader.GetInt32(14), (byte[])objReader[15], (byte[])objReader[16], objReader.GetInt32(17));
                coneccion.Close();

                return temp;
            }
            catch
            {
                return null;
            }
        }

        // consulta bomberos dataset
        public DataSet seleccionar_Dataset(bool activo, string brigada, string columna, string operacion, string valor)
        {
            if (!conectar())
            {
                return null;
            }

            try
            {
                if (activo)
                {
                    if (columna == null || valor == null)
                    {
                        SqlDataAdapter temp1 = new SqlDataAdapter("SELECT PK_Id_BomberoForestal, nombre, apellido1, apellido2 from TB_BomberoForestal BF join TB_Brigada B on B.PK_Id_Brigada= BF.FK_Id_Brigada where BF.estado = 1 and (B.FK_Id_BomberoForestal IS NULL or BF.PK_Id_BomberoForestal!=B.FK_Id_BomberoForestal) and B.nombre_Brigada = '" + brigada + "'", coneccion);
                        DataSet temp2 = new DataSet();
                        temp1.Fill(temp2);
                        return temp2;
                    }
                    else
                    {
                        SqlDataAdapter temp1 = new SqlDataAdapter("SELECT PK_Id_BomberoForestal, nombre, apellido1, apellido2 from TB_BomberoForestal BF join TB_Brigada B on B.PK_Id_Brigada= BF.FK_Id_Brigada where BF.estado = 1 and (B.FK_Id_BomberoForestal IS NULL or BF.PK_Id_BomberoForestal!=B.FK_Id_BomberoForestal) and B.nombre_Brigada = '" + brigada + "' and " + columna + " " + operacion + " '" + valor + "'", coneccion);
                        DataSet temp2 = new DataSet();
                        temp1.Fill(temp2);
                        return temp2;
                    }
                }
                else
                {
                    if (columna == null || valor == null)
                    {
                        SqlDataAdapter temp1 = new SqlDataAdapter("SELECT PK_Id_BomberoForestal, nombre, apellido1, apellido2 from TB_BomberoForestal BF join TB_Brigada on PK_Id_Brigada=FK_Id_Brigada where BF.estado = 0 and nombre_Brigada = '" + brigada + "'", coneccion);
                        DataSet temp2 = new DataSet();
                        temp1.Fill(temp2);
                        return temp2;
                    }
                    else
                    {
                        SqlDataAdapter temp1 = new SqlDataAdapter("SELECT PK_Id_BomberoForestal, nombre, apellido1, apellido2 from TB_BomberoForestal BF join TB_Brigada on PK_Id_Brigada=FK_Id_Brigada where BF.estado = 0 and nombre_Brigada = '" + brigada + "' and " + columna + " " + operacion + " '" + valor + "'", coneccion);
                        DataSet temp2 = new DataSet();
                        temp1.Fill(temp2);
                        return temp2;
                    }
                }

            }
            catch
            {
                return null;
            }
        }

        public DataSet seleccionar_Dataset2(bool activo, string brigada, string columna, string operacion, string valor)
        {
            if (!conectar())
            {
                return null;
            }

            try
            {
                if (activo)
                {
                    if (columna == null || valor == null)
                    {
                        SqlDataAdapter temp1 = new SqlDataAdapter("SELECT PK_Id_BomberoForestal, nombre, apellido1, apellido2 from TB_BomberoForestal BF join TB_Brigada on PK_Id_Brigada=FK_Id_Brigada where BF.estado = 1 and BF.PK_Id_BomberoForestal=FK_Id_BomberoForestal and nombre_Brigada = '" + brigada + "'", coneccion);
                        DataSet temp2 = new DataSet();
                        temp1.Fill(temp2);
                        return temp2;
                    }
                    else
                    {
                        SqlDataAdapter temp1 = new SqlDataAdapter("SELECT PK_Id_BomberoForestal, nombre, apellido1, apellido2 from TB_BomberoForestal BF join TB_Brigada on PK_Id_Brigada=FK_Id_Brigada where BF.estado = 1 and BF.PK_Id_BomberoForestal=FK_Id_BomberoForestal and nombre_Brigada = '" + brigada + "' and " + columna + " " + operacion + " '" + valor + "'", coneccion);
                        DataSet temp2 = new DataSet();
                        temp1.Fill(temp2);
                        return temp2;
                    }
                }
                else
                {
                    if (columna == null || valor == null)
                    {
                        SqlDataAdapter temp1 = new SqlDataAdapter("SELECT PK_Id_BomberoForestal, nombre, apellido1, apellido2 from TB_BomberoForestal BF join TB_Brigada on PK_Id_Brigada=FK_Id_Brigada where BF.estado = 0 and BF.PK_Id_BomberoForestal=FK_Id_BomberoForestal and nombre_Brigada = '" + brigada + "'", coneccion);
                        DataSet temp2 = new DataSet();
                        temp1.Fill(temp2);
                        return temp2;
                    }
                    else
                    {
                        SqlDataAdapter temp1 = new SqlDataAdapter("SELECT PK_Id_BomberoForestal, nombre, apellido1, apellido2 from TB_BomberoForestal BF join TB_Brigada on PK_Id_Brigada=FK_Id_Brigada where BF.estado = 0 and BF.PK_Id_BomberoForestal=FK_Id_BomberoForestal and nombre_Brigada = '" + brigada + "' and " + columna + " " + operacion + " '" + valor + "'", coneccion);
                        DataSet temp2 = new DataSet();
                        temp1.Fill(temp2);
                        return temp2;
                    }
                }

            }
            catch
            {
                return null;
            }
        }

        // bomberos filtrados para polizas dataset
        public DataSet seleccionar_Dataset_NoPolizaAsig(bool activo, string brigada, string columna, string operacion, string valor)
        {
            if (!conectar())
            {
                return null;
            }

            try
            {
                if (activo)
                {
                    if (columna == null || valor == null)
                    {
                        SqlDataAdapter temp1 = new SqlDataAdapter("SELECT PK_Id_BomberoForestal, nombre, apellido1, apellido2 from TB_BomberoForestal BF join TB_Brigada B on B.PK_Id_Brigada = BF.FK_Id_Brigada left join TB_BomberoPoliza BP on BF.PK_Id_BomberoForestal = BP.FK_TB_BomberoForestal where (BP.FK_TB_Poliza IS NULL or BP.estado = 0) and BF.estado = 1 and B.nombre_Brigada = '" + brigada + "'", coneccion);
                        DataSet temp2 = new DataSet();
                        temp1.Fill(temp2);
                        return temp2;
                    }
                    else
                    {
                        SqlDataAdapter temp1 = new SqlDataAdapter("SELECT PK_Id_BomberoForestal, nombre, apellido1, apellido2 from TB_BomberoForestal BF join TB_Brigada B on B.PK_Id_Brigada = BF.FK_Id_Brigada left join TB_BomberoPoliza BP on BF.PK_Id_BomberoForestal = BP.FK_TB_BomberoForestal where (BP.FK_TB_Poliza IS NULL or BP.estado = 0) and and BF.estado = 1 and B.nombre_Brigada = '" + brigada + "' and " + columna + " " + operacion + " '" + valor + "'", coneccion);
                        DataSet temp2 = new DataSet();
                        temp1.Fill(temp2);
                        return temp2;
                    }
                }
                else
                {
                    if (columna == null || valor == null)
                    {
                        SqlDataAdapter temp1 = new SqlDataAdapter("SELECT PK_Id_BomberoForestal, nombre, apellido1, apellido2 from TB_BomberoForestal BF join TB_Brigada B on B.PK_Id_Brigada = BF.FK_Id_Brigada left join TB_BomberoPoliza BP on BF.PK_Id_BomberoForestal = BP.FK_TB_BomberoForestal where (BP.FK_TB_Poliza IS NULL or BP.estado = 0) and and BF.estado = 0 and B.nombre_Brigada = '" + brigada + "'", coneccion);
                        DataSet temp2 = new DataSet();
                        temp1.Fill(temp2);
                        return temp2;
                    }
                    else
                    {
                        SqlDataAdapter temp1 = new SqlDataAdapter("SELECT PK_Id_BomberoForestal, nombre, apellido1, apellido2 from TB_BomberoForestal BF join TB_Brigada B on B.PK_Id_Brigada = BF.FK_Id_Brigada left join TB_BomberoPoliza BP on BF.PK_Id_BomberoForestal = BP.FK_TB_BomberoForestal where (BP.FK_TB_Poliza IS NULL or BP.estado = 0) and and BF.estado = 0 and B.nombre_Brigada = '" + brigada + "' and " + columna + " " + operacion + " '" + valor + "'", coneccion);
                        DataSet temp2 = new DataSet();
                        temp1.Fill(temp2);
                        return temp2;
                    }
                }

            }
            catch
            {
                return null;
            }
        }

        public DataSet seleccionar_Dataset_PolizaAsig(bool activo, string brigada, string columna, string operacion, string valor)
        {
            if (!conectar())
            {
                return null;
            }

            try
            {
                if (activo)
                {
                    if (columna == null || valor == null)
                    {
                        SqlDataAdapter temp1 = new SqlDataAdapter("SELECT PK_Id_BomberoForestal, nombre, apellido1, apellido2 from TB_BomberoForestal BF join TB_Brigada B on B.PK_Id_Brigada = BF.FK_Id_Brigada join TB_BomberoPoliza BP on BF.PK_Id_BomberoForestal = BP.FK_TB_BomberoForestal where BP.estado = 1 and BF.estado = 1 and B.nombre_Brigada = '" + brigada + "'", coneccion);
                        DataSet temp2 = new DataSet();
                        temp1.Fill(temp2);
                        return temp2;
                    }
                    else
                    {
                        SqlDataAdapter temp1 = new SqlDataAdapter("SELECT PK_Id_BomberoForestal, nombre, apellido1, apellido2 from TB_BomberoForestal BF join TB_Brigada B on B.PK_Id_Brigada = BF.FK_Id_Brigada join TB_BomberoPoliza BP on BF.PK_Id_BomberoForestal = BP.FK_TB_BomberoForestal where BP.estado = 1 and BF.estado = 1 and B.nombre_Brigada = '" + brigada + "' and " + columna + " " + operacion + " '" + valor + "'", coneccion);
                        DataSet temp2 = new DataSet();
                        temp1.Fill(temp2);
                        return temp2;
                    }
                }
                else
                {
                    if (columna == null || valor == null)
                    {
                        SqlDataAdapter temp1 = new SqlDataAdapter("SELECT PK_Id_BomberoForestal, nombre, apellido1, apellido2 from TB_BomberoForestal BF join TB_Brigada B on B.PK_Id_Brigada = BF.FK_Id_Brigada join TB_BomberoPoliza BP on BF.PK_Id_BomberoForestal = BP.FK_TB_BomberoForestal where BP.estado = 1 and BF.estado = 0 and B.nombre_Brigada = '" + brigada + "'", coneccion);
                        DataSet temp2 = new DataSet();
                        temp1.Fill(temp2);
                        return temp2;
                    }
                    else
                    {
                        SqlDataAdapter temp1 = new SqlDataAdapter("SELECT PK_Id_BomberoForestal, nombre, apellido1, apellido2 from TB_BomberoForestal BF join TB_Brigada B on B.PK_Id_Brigada = BF.FK_Id_Brigada join TB_BomberoPoliza BP on BF.PK_Id_BomberoForestal = BP.FK_TB_BomberoForestal where BP.estado = 1 and BF.estado = 0 and B.nombre_Brigada = '" + brigada + "' and " + columna + " " + operacion + " '" + valor + "'", coneccion);
                        DataSet temp2 = new DataSet();
                        temp1.Fill(temp2);
                        return temp2;
                    }
                }

            }
            catch
            {
                return null;
            }
        }

        // bomberos filtrados para polizas dataset
        public DataSet seleccionar_Dataset_NoCapacitAsig(bool activo, string brigada, string columna, string operacion, string valor)
        {
            if (!conectar())
            {
                return null;
            }

            try
            {
                if (activo)
                {
                    if (columna == null || valor == null)
                    {
                        SqlDataAdapter temp1 = new SqlDataAdapter("SELECT PK_Id_BomberoForestal, nombre, apellido1, apellido2 from TB_BomberoForestal BF join TB_Brigada B on B.PK_Id_Brigada = BF.FK_Id_Brigada left join TB_BomberoCapacitacion BC on BF.PK_Id_BomberoForestal = BC.FK_BomberoForestal where (BC.FK_TB_Capacitacion IS NULL or BC.estado = 0) and BF.estado = 1 and B.nombre_Brigada = '" + brigada + "'", coneccion);
                        DataSet temp2 = new DataSet();
                        temp1.Fill(temp2);
                        return temp2;
                    }
                    else
                    {
                        SqlDataAdapter temp1 = new SqlDataAdapter("SELECT PK_Id_BomberoForestal, nombre, apellido1, apellido2 from TB_BomberoForestal BF join TB_Brigada B on B.PK_Id_Brigada = BF.FK_Id_Brigada left join TB_BomberoCapacitacion BC on BF.PK_Id_BomberoForestal = BC.FK_BomberoForestal where (BC.FK_TB_Capacitacion IS NULL or BC.estado = 0) and BF.estado = 1 and B.nombre_Brigada = '" + brigada + "' and " + columna + " " + operacion + " '" + valor + "'", coneccion);
                        DataSet temp2 = new DataSet();
                        temp1.Fill(temp2);
                        return temp2;
                    }
                }
                else
                {
                    if (columna == null || valor == null)
                    {
                        SqlDataAdapter temp1 = new SqlDataAdapter("SELECT PK_Id_BomberoForestal, nombre, apellido1, apellido2 from TB_BomberoForestal BF join TB_Brigada B on B.PK_Id_Brigada = BF.FK_Id_Brigada left join TB_BomberoCapacitacion BC on BF.PK_Id_BomberoForestal = BC.FK_BomberoForestal where (BC.FK_TB_Capacitacion IS NULL or BC.estado = 0) and BF.estado = 0 and B.nombre_Brigada = '" + brigada + "'", coneccion);
                        DataSet temp2 = new DataSet();
                        temp1.Fill(temp2);
                        return temp2;
                    }
                    else
                    {
                        SqlDataAdapter temp1 = new SqlDataAdapter("SELECT PK_Id_BomberoForestal, nombre, apellido1, apellido2 from TB_BomberoForestal BF join TB_Brigada B on B.PK_Id_Brigada = BF.FK_Id_Brigada left join TB_BomberoCapacitacion BC on BF.PK_Id_BomberoForestal = BC.FK_BomberoForestal where (BC.FK_TB_Capacitacion IS NULL or BC.estado = 0) and BF.estado = 0 and B.nombre_Brigada = '" + brigada + "' and " + columna + " " + operacion + " '" + valor + "'", coneccion);
                        DataSet temp2 = new DataSet();
                        temp1.Fill(temp2);
                        return temp2;
                    }
                }

            }
            catch
            {
                return null;
            }
        }

        public DataSet seleccionar_Dataset_CapacitAsig(bool activo, string brigada, string columna, string operacion, string valor)
        {
            if (!conectar())
            {
                return null;
            }

            try
            {
                if (activo)
                {
                    if (columna == null || valor == null)
                    {
                        SqlDataAdapter temp1 = new SqlDataAdapter("SELECT PK_Id_BomberoForestal, nombre, apellido1, apellido2 from TB_BomberoForestal BF join TB_Brigada B on B.PK_Id_Brigada = BF.FK_Id_Brigada join TB_BomberoCapacitacion BC on BF.PK_Id_BomberoForestal = BC.FK_BomberoForestal where BC.estado = 1 and BF.estado = 1 and B.nombre_Brigada = '" + brigada + "'", coneccion);
                        DataSet temp2 = new DataSet();
                        temp1.Fill(temp2);
                        return temp2;
                    }
                    else
                    {
                        SqlDataAdapter temp1 = new SqlDataAdapter("SELECT PK_Id_BomberoForestal, nombre, apellido1, apellido2 from TB_BomberoForestal BF join TB_Brigada B on B.PK_Id_Brigada = BF.FK_Id_Brigada join TB_BomberoCapacitacion BC on BF.PK_Id_BomberoForestal = BC.FK_BomberoForestal where BC.estado = 1 and BF.estado = 1 and B.nombre_Brigada = '" + brigada + "' and " + columna + " " + operacion + " '" + valor + "'", coneccion);
                        DataSet temp2 = new DataSet();
                        temp1.Fill(temp2);
                        return temp2;
                    }
                }
                else
                {
                    if (columna == null || valor == null)
                    {
                        SqlDataAdapter temp1 = new SqlDataAdapter("SELECT PK_Id_BomberoForestal, nombre, apellido1, apellido2 from TB_BomberoForestal BF join TB_Brigada B on B.PK_Id_Brigada = BF.FK_Id_Brigada join TB_BomberoCapacitacion BC on BF.PK_Id_BomberoForestal = BC.FK_BomberoForestal where BC.estado = 1 and BF.estado = 0 and B.nombre_Brigada = '" + brigada + "'", coneccion);
                        DataSet temp2 = new DataSet();
                        temp1.Fill(temp2);
                        return temp2;
                    }
                    else
                    {
                        SqlDataAdapter temp1 = new SqlDataAdapter("SELECT PK_Id_BomberoForestal, nombre, apellido1, apellido2 from TB_BomberoForestal BF join TB_Brigada B on B.PK_Id_Brigada = BF.FK_Id_Brigada join TB_BomberoCapacitacion BC on BF.PK_Id_BomberoForestal = BC.FK_BomberoForestal where BC.estado = 1 and BF.estado = 0 and B.nombre_Brigada = '" + brigada + "' and " + columna + " " + operacion + " '" + valor + "'", coneccion);
                        DataSet temp2 = new DataSet();
                        temp1.Fill(temp2);
                        return temp2;
                    }
                }

            }
            catch
            {
                return null;
            }
        }

        public List<string> listaBomberos(string areaconserv, string brigada)
        {
            if (!conectar())
            {
                return null;
            }

            try
            {
                SqlCommand ing = new SqlCommand("select PK_Id_BomberoForestal, TB_BomberoForestal.nombre from TB_BomberoForestal inner join TB_AreasConservacion on TB_AreasConservacion.nombre = @areaconserv inner join TB_Brigada on TB_Brigada.nombre_Brigada = @brigada", coneccion);
                ing.Parameters.AddWithValue("areaconserv", areaconserv);
                ing.Parameters.AddWithValue("brigada", brigada);

                coneccion.Open();
                SqlDataReader objReader = ing.ExecuteReader();
                List<string> temp = new List<string>();

                while (objReader.Read())
                {

                    temp.Add(objReader.GetString(0) + " " + objReader.GetString(1));
                }

                coneccion.Close();

                return temp;
            }
            catch
            {
                return null;
            }
        }

        public int idBrigada(string nombre)
        {
            if (!conectar())
            {
                return -1;
            }

            try
            {
                SqlCommand ing = new SqlCommand("select PK_Id_Brigada from TB_Brigada where nombre_Brigada = @nombre", coneccion);
                ing.Parameters.AddWithValue("nombre", nombre);

                coneccion.Open();
                SqlDataReader objReader = ing.ExecuteReader();
                objReader.Read();
                int temp = objReader.GetInt32(0);
                coneccion.Close();

                return temp;
            }
            catch
            {
                return -1;
            }
        }

        public bool getEstado(string identificacion)
        {
            if (!conectar())
            {
                return false;
            }

            try
            {
                SqlCommand ing = new SqlCommand("select estado from TB_BomberoForestal where PK_Id_BomberoForestal = @identificacion", coneccion);
                ing.Parameters.AddWithValue("identificacion", identificacion);

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

        // bomberos filtrados para actividad prevancion dataset
        public DataSet seleccionar_Dataset_NoActivPrevAsig(bool activo, string brigada, string columna, string operacion, string valor)
        {
            if (!conectar())
            {
                return null;
            }

            try
            {
                if (activo)
                {
                    if (columna == null || valor == null)
                    {
                        SqlDataAdapter temp1 = new SqlDataAdapter("SELECT PK_Id_BomberoForestal, nombre, apellido1, apellido2 from TB_BomberoForestal BF join TB_Brigada B on B.PK_Id_Brigada = BF.FK_Id_Brigada left join TB_BomberoActividadPrevencion BA on BF.PK_Id_BomberoForestal = BA.FK_TB_BomberoForestal where (BA.FK_TB_ActividadPrevencion IS NULL or BA.estado = 0) and BF.estado = 1 and B.nombre_Brigada = '" + brigada + "'", coneccion);
                        DataSet temp2 = new DataSet();
                        temp1.Fill(temp2);
                        return temp2;
                    }
                    else
                    {
                        SqlDataAdapter temp1 = new SqlDataAdapter("SELECT PK_Id_BomberoForestal, nombre, apellido1, apellido2 from TB_BomberoForestal BF join TB_Brigada B on B.PK_Id_Brigada = BF.FK_Id_Brigada left join TB_BomberoActividadPrevencion BA on BF.PK_Id_BomberoForestal = BA.FK_TB_BomberoForestal where (BA.FK_TB_ActividadPrevencion IS NULL or BA.estado = 0) and BF.estado = 1 and B.nombre_Brigada = '" + brigada + "' and " + columna + " " + operacion + " '" + valor + "'", coneccion);
                        DataSet temp2 = new DataSet();
                        temp1.Fill(temp2);
                        return temp2;
                    }
                }
                else
                {
                    if (columna == null || valor == null)
                    {
                        SqlDataAdapter temp1 = new SqlDataAdapter("SELECT PK_Id_BomberoForestal, nombre, apellido1, apellido2 from TB_BomberoForestal BF join TB_Brigada B on B.PK_Id_Brigada = BF.FK_Id_Brigada left join TB_BomberoActividadPrevencion BA on BF.PK_Id_BomberoForestal = BA.FK_TB_BomberoForestal where (BA.FK_TB_ActividadPrevencion IS NULL or BA.estado = 0) and BF.estado = 0 and B.nombre_Brigada = '" + brigada + "'", coneccion);
                        DataSet temp2 = new DataSet();
                        temp1.Fill(temp2);
                        return temp2;
                    }
                    else
                    {
                        SqlDataAdapter temp1 = new SqlDataAdapter("SELECT PK_Id_BomberoForestal, nombre, apellido1, apellido2 from TB_BomberoForestal BF join TB_Brigada B on B.PK_Id_Brigada = BF.FK_Id_Brigada left join TB_BomberoActividadPrevencion BA on BF.PK_Id_BomberoForestal = BA.FK_TB_BomberoForestal where (BA.FK_TB_ActividadPrevencion IS NULL or BA.estado = 0) and BF.estado = 0 and B.nombre_Brigada = '" + brigada + "' and " + columna + " " + operacion + " '" + valor + "'", coneccion);
                        DataSet temp2 = new DataSet();
                        temp1.Fill(temp2);
                        return temp2;
                    }
                }

            }
            catch
            {
                return null;
            }
        }

        public DataSet seleccionar_Dataset_ActivPrevAsig(bool activo, string brigada, string columna, string operacion, string valor)
        {
            if (!conectar())
            {
                return null;
            }

            try
            {
                if (activo)
                {
                    if (columna == null || valor == null)
                    {
                        SqlDataAdapter temp1 = new SqlDataAdapter("SELECT PK_Id_BomberoForestal, nombre, apellido1, apellido2 from TB_BomberoForestal BF join TB_Brigada B on B.PK_Id_Brigada = BF.FK_Id_Brigada join TB_BomberoActividadPrevencion BA on BF.PK_Id_BomberoForestal = BA.FK_TB_BomberoForestal where BA.estado = 1 and BF.estado = 1 and B.nombre_Brigada = '" + brigada + "'", coneccion);
                        DataSet temp2 = new DataSet();
                        temp1.Fill(temp2);
                        return temp2;
                    }
                    else
                    {
                        SqlDataAdapter temp1 = new SqlDataAdapter("SELECT PK_Id_BomberoForestal, nombre, apellido1, apellido2 from TB_BomberoForestal BF join TB_Brigada B on B.PK_Id_Brigada = BF.FK_Id_Brigada join TB_BomberoActividadPrevencion BA on BF.PK_Id_BomberoForestal = BA.FK_TB_BomberoForestal where BA.estado = 1 and BF.estado = 1 and B.nombre_Brigada = '" + brigada + "' and " + columna + " " + operacion + " '" + valor + "'", coneccion);
                        DataSet temp2 = new DataSet();
                        temp1.Fill(temp2);
                        return temp2;
                    }
                }
                else
                {
                    if (columna == null || valor == null)
                    {
                        SqlDataAdapter temp1 = new SqlDataAdapter("SELECT PK_Id_BomberoForestal, nombre, apellido1, apellido2 from TB_BomberoForestal BF join TB_Brigada B on B.PK_Id_Brigada = BF.FK_Id_Brigada join TB_BomberoActividadPrevencion BA on BF.PK_Id_BomberoForestal = BA.FK_TB_BomberoForestal where BA.estado = 1 and BF.estado = 0 and B.nombre_Brigada = '" + brigada + "'", coneccion);
                        DataSet temp2 = new DataSet();
                        temp1.Fill(temp2);
                        return temp2;
                    }
                    else
                    {
                        SqlDataAdapter temp1 = new SqlDataAdapter("SELECT PK_Id_BomberoForestal, nombre, apellido1, apellido2 from TB_BomberoForestal BF join TB_Brigada B on B.PK_Id_Brigada = BF.FK_Id_Brigada join TB_BomberoActividadPrevencion BA on BF.PK_Id_BomberoForestal = BA.FK_TB_BomberoForestal where BA.estado = 1 and BF.estado = 0 and B.nombre_Brigada = '" + brigada + "' and " + columna + " " + operacion + " '" + valor + "'", coneccion);
                        DataSet temp2 = new DataSet();
                        temp1.Fill(temp2);
                        return temp2;
                    }
                }

            }
            catch
            {
                return null;
            }
        }
    }
}