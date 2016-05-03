using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sistema.CapaPresentacion.Html
{
    public partial class MenuPrincipal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (VariablesSeccionControl.Lee<string>("userAreaConserv") == null)
            {
                Response.Redirect("/index.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string script = string.Format("javascript:$('#mensajes').modal('show');");
            ScriptManager.RegisterStartupScript(this, Page.ClientScript.GetType(), null, script, true);
        }

        protected void ButtonAcepta(object sender, EventArgs e)
        {
            VariablesSeccionControl.Escribe("userRol", null);
            VariablesSeccionControl.Escribe("userAreaConserv", null);
            VariablesSeccionControl.Escribe("userName", null);
            Response.Redirect("/index.aspx");
        }
    }
}