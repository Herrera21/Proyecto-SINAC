using CapaConfiguracion;
using CapaLogica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sistema
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void activaModal(string id)
        {
            string script = string.Format("javascript:$('#" + id + "').modal('show');");
            ScriptManager.RegisterStartupScript(this, Page.ClientScript.GetType(), null, script, true);
        }

        protected void mensaje(String mensaje)
        {
            this.labelMensaje.InnerText = mensaje;
            activaModal("mensajes");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if(Logear.activo(usuario.Value))
            {
                if (Logear.login(usuario.Value, pass.Value))
                {
                    UsuarioDB userDB = new UsuarioDB();
                    AreaConservacionDB ACtemp = new AreaConservacionDB();
                    Usuario user = userDB.seleccionar(usuario.Value);

                    VariablesSeccionControl.Escribe("userRol", user.getRol());
                    VariablesSeccionControl.Escribe("userAreaConserv", ACtemp.getNombre(user.getAreaConserv()));
                    VariablesSeccionControl.Escribe("userName", user.getUsuario());
                    Response.Redirect("CapaPresentacion/Html/MenuPrincipal.aspx");
                }
                else
                {
                    mensaje("usuario o contraseña incorrectos");
                }
            }
            else
            {
                mensaje("Este usuario está inactivo");
            }
        }
    }
}