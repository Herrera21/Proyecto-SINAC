using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogica;
using CapaConfiguracion;

namespace Sistema.CapaPresentacion.Html
{
    public partial class RMenuBrigada : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (VariablesSeccionControl.Lee<string>("userAreaConserv") == null)
            {
                Response.Redirect("/index.aspx");
            }
            else
            {
                if (VariablesSeccionControl.Lee<string>("AreaConserv") == null)
                {
                    Response.Redirect("CAreaConserv.aspx");
                }
            }

        }

        protected void activaModal(string id)
        {
            string script = string.Format("javascript:$('#" + id + "').modal('show');");
            ScriptManager.RegisterStartupScript(this, Page.ClientScript.GetType(), null, script, true);
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
            BrigadaDB registrar = new BrigadaDB();
            AreaConservacionDB DB = new AreaConservacionDB();

            int x = DB.getId(VariablesSeccionControl.Lee<string>("AreaConserv"));

            if (registrar.insertar(new Brigada(brigada.Value, 0, x)))
            {
                mensaje("La brigada ha sido creada", true);
            }
            else
            {
                mensaje("Ocurrio un error al guardar la información", true);
            }
        }
    }
}