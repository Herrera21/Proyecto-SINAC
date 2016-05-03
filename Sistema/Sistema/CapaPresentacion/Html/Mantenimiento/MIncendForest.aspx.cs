using Sistema.CapaConfiguracion;
using Sistema.CapaLogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sistema.CapaPresentacion.Html.BombForest
{
    public partial class MIncendForest : System.Web.UI.Page
    {
        private const string buttonName = "Inactivar";

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
                    buscarIF(VariablesSeccionControl.Lee<int>("IncendForest"));
                }
            }
        }

        protected void activaModal(string id, bool activar)
        {
            if (activar)
            {
                string script = string.Format("javascript:$('#" + id + "').modal('show');");
                ScriptManager.RegisterStartupScript(this, Page.ClientScript.GetType(), null, script, true);
            }
            else
            {
                string script = string.Format("javascript:$('#" + id + "').modal('hidden');");
                ScriptManager.RegisterStartupScript(this, Page.ClientScript.GetType(), null, script, true);
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
            activaModal("mensajes", true);
        }

        protected void Alert(String mensaje)
        {
            this.labelAlert.InnerText = mensaje;
            activaModal("alert", true);
        }

        protected void ButtonAcepta(object sender, EventArgs e)
        {
            //activa o inactiva area de conservacion
            IncendForestDB DB = new IncendForestDB();

            if (Button2.Text.Equals(buttonName))
            {
                if (DB.inactivar(true, VariablesSeccionControl.Lee<int>("IncendForest")))
                {
                    mensaje("El evento de incendio forestal se ha inactivado", true);
                }
                else
                {
                    mensaje("Ocurrio un error al guardar la información", false);
                }
            }
            else
            {
                if (DB.inactivar(false, VariablesSeccionControl.Lee<int>("IncendForest")))
                {
                    mensaje("El evento de incendio forestal se ha activado", true);
                }
                else
                {
                    mensaje("Ocurrio un error al guardar la información", false);
                }
            }
        }

        protected void ButtonCancela(object sender, EventArgs e)
        {
            activaModal("alert", false);
        }

        protected void cargarInfo(string lugInce, string fechaPart)
        {
            this.lugInce.Value = lugInce;
            this.fechaPart.Value = fechaPart;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Button2.Text.Equals(buttonName))
            {
                Alert("¿Desea realmente desactivar este evento de incendio forestal?");
            }
            else
            {
                Alert("¿Desea realmente reactivar este evento de incendio forestal?");
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //guarda la informacion en la base de datos
            IncendForestDB DB = new IncendForestDB();

            if (DB.actualizar(VariablesSeccionControl.Lee<int>("IncendForest"), new IncendForest(lugInce.Value, fechaPart.Value)))
            {
                mensaje("El evento de incendio forestal ha sido modificado", true);
            }
            else
            {
                mensaje("Ocurrio un error al guardar la información", false);
            }
        }

        private void buscarIF(int id)
        {
            //carga la informacion de la base de datos
            IncendForestDB DB = new IncendForestDB();
            IncendForest temp = DB.seleccionar(id);

            if (temp != null)
            {
                if (!DB.getEstado(VariablesSeccionControl.Lee<int>("IncendForest")))
                {
                    Button2.Text = "Activar";
                }

                cargarInfo(temp.getLugar(), temp.getFechaPartic());
            }
            else
            {
                mensaje("Ocurrio un error al cargar la información", true);
            }
        }
    }
}