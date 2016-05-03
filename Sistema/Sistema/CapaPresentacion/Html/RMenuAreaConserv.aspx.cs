using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaConfiguracion;
using CapaLogica;

namespace Sistema.CapaPresentacion.Html
{
    public partial class RMenuAreaConserv : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (VariablesSeccionControl.Lee<string>("userAreaConserv") == null)
            {
                Response.Redirect("/index.aspx");
            }
        }

        protected void ejecScript(string dato)
        {
            string script = string.Format(dato);
            ScriptManager.RegisterStartupScript(this, Page.ClientScript.GetType(), null, script, true);
        }

        protected void activaModal(string id)
        {
            ejecScript("javascript:$('#" + id + "').modal('show');");
        }
        protected void mensaje(String mensaje, Boolean redireccionar)
        {
            this.labelMensaje.InnerText = mensaje;
            if (redireccionar)
            {
                botonMensaje1.Visible = true;
                botonMensaje2.Visible = false;
            }
            else
            {
                botonMensaje1.Visible = false;
                botonMensaje2.Visible = true;
            }
            activaModal("mensajes");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //registra area de conservacion
            AreaConservacionDB registrar = new AreaConservacionDB();

            if (registrar.insertar(new AreaConservacion(NAreaCons.Value, abrev.Value, ubicacion.SelectedValue)))
            {
                mensaje("El Área de Conservación ha sido creada", true);
            }
            else
            {
                mensaje("Ocurrio un error al guardar la información", false);
            }
        }
    }
}