using CapaConfiguracion;
using CapaLogica;
using Sistema.CapaLogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sistema.CapaPresentacion.Html.BombForest
{
    public partial class MContactosEmergencia : System.Web.UI.Page
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
                    if (VariablesSeccionControl.Lee<string>("Bombero") == null)
                    {
                        Response.Redirect("CAreaConserv.aspx");
                    }
                    else
                    {
                        buscarCE(VariablesSeccionControl.Lee<string>("ContEmer"));
                    }
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
            ContactosEmergenciaDB DB = new ContactosEmergenciaDB();

            if (Button2.Text.Equals(buttonName))
            {
                if (DB.inactivar(true, VariablesSeccionControl.Lee<string>("ContEmer")))
                {
                    mensaje("El contacto de emergencia se ha inactivado", true);
                }
                else
                {
                    mensaje("Ocurrio un error al guardar la información", false);
                }
            }
            else
            {
                if (DB.inactivar(false, VariablesSeccionControl.Lee<string>("ContEmer")))
                {
                    mensaje("El contacto de emergencia se ha activado", true);
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

        protected void cargarInfo(string identificacion, string nombre, string apellido1, string apellido2, string parentesco, string telCelular, string telCasa)
        {
            this.cedula.Value = identificacion;
            this.nombre.Value = nombre;
            this.p_Ape.Value = apellido1;
            this.s_Ape.Value = apellido2;
            this.parent.Value = parentesco;
            this.telCel.Value = telCelular;
            this.telCasa.Value = telCasa;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Button2.Text.Equals(buttonName))
            {
                Alert("¿Desea realmente desactivar este contacto de emergencia?");
            }
            else
            {
                Alert("¿Desea realmente reactivar este contacto de emergencia?");
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //guarda la informacion en la base de datos
            ContactosEmergenciaDB DB = new ContactosEmergenciaDB();
            if (DB.actualizar(VariablesSeccionControl.Lee<string>("ContEmer"), new ContEmerg(cedula.Value, nombre.Value, p_Ape.Value, s_Ape.Value, parent.Value, telCel.Value, telCasa.Value, null)))
            {
                mensaje("El contacto de emergencia ha sido modificado", true);
            }
            else
            {
                mensaje("Ocurrio un error al guardar la información", false);
            }
        }

        private void buscarCE(string id)
        {
            //carga la informacion de la base de datos
            ContactosEmergenciaDB DB = new ContactosEmergenciaDB();
            ContEmerg temp = DB.seleccionar(id);

            if (temp != null)
            {
                if (!DB.getEstado(VariablesSeccionControl.Lee<string>("ContEmer")))
                {
                    Button2.Text = "Activar";
                }

                cargarInfo(temp.getIdentificacion(), temp.getNombre(), temp.getApellido1(), temp.getApellido2(), temp.getParentesco(), temp.getTelCelular(), temp.getTelCasa());
            }
            else
            {
                mensaje("Ocurrio un error al cargar la información", true);
            }
        }
    }
}