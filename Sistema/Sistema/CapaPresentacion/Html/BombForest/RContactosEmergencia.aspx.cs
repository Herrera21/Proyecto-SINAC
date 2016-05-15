using CapaConfiguracion;
using Sistema.CapaLogicaNegocio;
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
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ContactosEmergenciaDB registrar = new ContactosEmergenciaDB();


            if (registrar.insertar(new ContEmerg(nombre.Value, p_Ape.Value, s_Ape.Value, cedula.Value, parent.Value, telCel.Value, telCasa.Value, VariablesSeccionControl.Lee<string>("Bombero"))))
            {
                mensaje("El contacto de emergencia ha sido creado", true);
            }

            else
            {
                mensaje("Ocurrio un error al guardar la información", false);
            }

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

        protected void activaModal(string id)
        {
            string script = string.Format("javascript:$('#" + id + "').modal('show');");
            ScriptManager.RegisterStartupScript(this, Page.ClientScript.GetType(), null, script, true);
        }
    }
}