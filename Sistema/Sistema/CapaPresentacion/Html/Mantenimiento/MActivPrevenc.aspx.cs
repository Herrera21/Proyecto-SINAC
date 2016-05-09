using Sistema.CapaConfiguracion;
using Sistema.CapaLogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sistema.CapaPresentacion.Html.Mantenimiento
{
    public partial class MActivPrevenc : System.Web.UI.Page
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
                    buscarAC(VariablesSeccionControl.Lee<int>("ActivPrevenc"));
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
            ActivPrevencDB DB = new ActivPrevencDB();

            if (Button2.Text.Equals(buttonName))
            {
                if (DB.inactivar(true, VariablesSeccionControl.Lee<int>("ActivPrevenc")))
                {
                    mensaje("La Actividad de Prevención se ha inactivado", true);
                }
                else
                {
                    mensaje("Ocurrio un error al guardar la información", false);
                }
            }
            else
            {
                if (DB.inactivar(false, VariablesSeccionControl.Lee<int>("ActivPrevenc")))
                {
                    mensaje("La Actividad de Prevención se ha activado", true);
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

        protected void cargarInfo(string nombreActiv, string fechaActiv, string lugarActiv, string observaciones)
        {
            this.NombreActiv.Value = nombreActiv;
            this.fechaActiv.Value = fechaActiv;
            this.LugarActiv.Value = lugarActiv;
            this.observaciones.Value = observaciones;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Button2.Text.Equals(buttonName))
            {
                Alert("¿Desea realmente desactivar esta Actividad de Prevención?");
            }
            else
            {
                Alert("¿Desea realmente reactivar esta Actividad de Prevención?");
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //guarda la informacion en la base de datos
            ActivPrevencDB DB = new ActivPrevencDB();

            if (DB.actualizar(VariablesSeccionControl.Lee<int>("ActivPrevenc"), new ActivPrevencion(NombreActiv.Value, fechaActiv.Value, LugarActiv.Value, observaciones.Value)))
            {
                mensaje("La capacitación ha sido modificada", true);
            }
            else
            {
                mensaje("Ocurrio un error al guardar la información", false);
            }
        }

        private void buscarAC(int id)
        {
            //carga la informacion de la base de datos
            ActivPrevencDB DB = new ActivPrevencDB();
            ActivPrevencion temp = DB.seleccionar(id);

            if (temp != null)
            {
                if (!DB.getEstado(VariablesSeccionControl.Lee<int>("ActivPrevenc")))
                {
                    Button2.Text = "Activar";
                }

                cargarInfo(temp.getNombreActiv(), temp.getFechaActiv(), temp.getLugarActiv(), temp.getObservaciones());
            }
            else
            {
                mensaje("Ocurrio un error al cargar la información", true);
            }
        }
    }
}