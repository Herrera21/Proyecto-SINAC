using CapaConfiguracion;
using CapaLogica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sistema.CapaPresentacion.Html
{
    public partial class MMenuAreaConserv1 : System.Web.UI.Page
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
                    if (VariablesSeccionControl.Lee<string>("AreaConserv") == null)
                    {
                        Response.Redirect("CAreaConserv.aspx");
                    }
                    else
                    {
                        buscarAC(VariablesSeccionControl.Lee<string>("AreaConserv"));
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
            AreaConservacionDB DB = new AreaConservacionDB();

            if (Button2.Text.Equals(buttonName))
            {
                if (!DB.poseeUsers(VariablesSeccionControl.Lee<string>("AreaConserv")))
                {
                    if (DB.inactivar(true, VariablesSeccionControl.Lee<string>("AreaConserv")))
                    {
                        mensaje("El Área de Conservación se ha inactivado", true);
                    }
                    else
                    {
                        mensaje("Ocurrio un error al guardar la información", false);
                    }
                    
                }
                else
                {
                    mensaje("No se puede inactivar, El Área de Conservación tiene usuarios", true);
                }
            }
            else
            {
                if (DB.inactivar(false, VariablesSeccionControl.Lee<string>("AreaConserv")))
                {
                    mensaje("El Área de Conservación se ha activado", true);
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

        protected void cargarInfo(string areaCons, string abrev, string ubicacion)
        {
            this.NAreaCons.Value = areaCons;
            this.abrev.Value = abrev;
            this.ubicacion.SelectedValue = ubicacion;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Button2.Text.Equals(buttonName))
            {
                Alert("¿Desea realmente desactivar esta Área de Conservación?");
            }
            else
            {
                Alert("¿Desea realmente reactivar esta Área de Conservación?");
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //guarda la informacion en la base de datos
            AreaConservacionDB DB = new AreaConservacionDB();

            if (DB.actualizar(VariablesSeccionControl.Lee<string>("AreaConserv"), new AreaConservacion(NAreaCons.Value, abrev.Value, ubicacion.SelectedValue)))
            {
                mensaje("El Área de Conservación ha sido modificada", true);
            }
            else
            {
                mensaje("Ocurrio un error al guardar la información", false);
            }
        }

        private void buscarAC(string nombre)
        {
            //carga la informacion de la base de datos
            AreaConservacionDB DB = new AreaConservacionDB();
            AreaConservacion temp = DB.seleccionar(nombre);

            if (temp != null)
            {
                if (!DB.getEstado(VariablesSeccionControl.Lee<string>("AreaConserv")))
                {
                    Button2.Text = "Activar";
                }

                cargarInfo(temp.getNombre(), temp.getAbreviatura(), temp.getUbicacion());
            }
            else
            {
                mensaje("Ocurrio un error al cargar la información", true);
            }
        }
    }
}