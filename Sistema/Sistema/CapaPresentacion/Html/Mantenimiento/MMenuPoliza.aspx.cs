using CapaConfiguracion;
using CapaLogica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sistema.CapaPresentacion.Html.BombForest
{
    public partial class MMenuPoliza1 : System.Web.UI.Page
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
                    buscarPL(VariablesSeccionControl.Lee<int>("Poliza"));
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
            PolizaDB DB = new PolizaDB();

            if (Button2.Text.Equals(buttonName))
            {
                if (DB.inactivar(true, VariablesSeccionControl.Lee<int>("Poliza")))
                {
                    mensaje("La póliza se ha inactivado", true);
                }
                else
                {
                    mensaje("Ocurrio un error al guardar la información", false);
                }
            }
            else
            {
                if (DB.inactivar(false, VariablesSeccionControl.Lee<int>("Poliza")))
                {
                    mensaje("La póliza se ha activado", true);
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
        protected void cargarInfo(string nombre, int numero, string periodoInicio, string periodoFin, string observaciones)
        {
            this.nombre.Value = nombre;
            this.numero.Value = Convert.ToString(numero);
            this.periodoInicio.Value = periodoInicio;
            this.periodoFin.Value = periodoFin;
            this.observaciones.Value = observaciones;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //guarda la informacion en la base de datos
            PolizaDB registrar = new PolizaDB();

            if (registrar.actualizar(new Poliza(nombre.Value, Convert.ToInt32(numero.Value), periodoInicio.Value, periodoFin.Value, observaciones.Value)))
            {
                mensaje("La póliza ha sido modificada", true);
            }
            else
            {
                mensaje("Ocurrio un error al guardar la información", true);
            }
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

        protected void buscarPL(int id)
        {
            //carga de la base de datos
            PolizaDB DB = new PolizaDB();
            Poliza temp = DB.seleccionar(id);

            if (temp != null)
            {
                if (!DB.getEstado(VariablesSeccionControl.Lee<int>("Poliza")))
                {
                    Button2.Text = "Activar";
                }

                cargarInfo(temp.getNombre(), temp.getNumero(), temp.getInicioPeriodo(), temp.getFinPeriodo(), temp.getObservaciones());
            }
            else
            {
                mensaje("Ocurrio un error al cargar la información", true);
            }
        }
    }
}