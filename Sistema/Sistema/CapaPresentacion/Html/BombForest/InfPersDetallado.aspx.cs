using CapaConfiguracion;
using CapaLogica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sistema.CapaPresentacion.Html.BombForest
{
    public partial class InfPersDetallado1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (VariablesSeccionControl.Lee<string>("userAreaConserv") == null)
                {
                    Response.Redirect("/index.aspx");
                }
                else
                {
                    if (VariablesSeccionControl.Lee<string>("Bombero") == null)
                    {
                        Response.Redirect("CBomberos.aspx");
                    }
                    else
                    {
                        BomberoDB DB = new BomberoDB();
                        Bombero temp = DB.seleccionar(VariablesSeccionControl.Lee<string>("Bombero"));
                        if (temp != null)
                        {
                            cargarInfo(temp.getIdentificacion(), temp.getNombre(), temp.getApellido1(), temp.getApellido2(), temp.getProvincia(), temp.getCanton(),
                                temp.getResidencia(), temp.getNacionalidad(), temp.getFechaNac(), temp.getTelResidencia(), temp.getTelCelular(), temp.getOcupacion(),
                                temp.getCorreo(), temp.getAniosEnBriga(), temp.getTipoBombe(), temp.getImgPerfil(), temp.getImgCed());
                        }

                    }
                }
            }
        }

        protected void cargarInfo(String identificacion, String nombre,
            String apellido1, String apellido2, String provincia, String canton, String residencia, String nacionalidad, String fechaNac,
            String telResidencia, String telCelular, String ocupacion, String correo, int aniosEnBriga, String tipoBombe, byte[] Perfil, byte[] Ced)
        {
            this.cedula.Value = identificacion;
            this.nombre.Value = nombre;
            this.p_Ape.Value = apellido1;
            this.s_Ape.Value = apellido2;
            this.provincia.Value = provincia;
            this.canton.Value = canton;
            this.lugarResid.Value = residencia.ToString();
            this.nacionalidad.Value = nacionalidad;
            this.fechaNac.Value = fechaNac;
            this.telResid.Value = telResidencia;
            this.telCel.Value = telCelular;
            this.ocupacion.Value = ocupacion;
            this.correo.Value = correo;
            this.aniosBrig.Value = aniosEnBriga.ToString();
            this.tipoBombero.Value = tipoBombe;
            this.Image1.Src = ImageControl.byteVecToIMG(Perfil);
            this.Image2.Src = ImageControl.byteVecToIMG(Ced);
        }
    }
}