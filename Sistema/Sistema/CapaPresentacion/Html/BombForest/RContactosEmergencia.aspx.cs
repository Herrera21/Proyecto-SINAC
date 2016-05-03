using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sistema.CapaPresentacion.Html.BombForest
{
    public partial class RContactosEmergencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void mensaje(String mensaje)
        {
            this.labelMensaje.InnerText = mensaje;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            mensaje("Información personal del contacto de emergencia " + this.nombre.Value + " registrada con éxito");
            string script = string.Format("javascript:$('#mensajes').modal('show');");
            ScriptManager.RegisterStartupScript(this, Page.ClientScript.GetType(), null, script, true);
        }
    }
}