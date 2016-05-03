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
    public partial class MMenuBrigada1 : System.Web.UI.Page
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
                        if (VariablesSeccionControl.Lee<string>("Brigada") == null)
                        {
                            Response.Redirect("CBrigadas.aspx");
                        }
                        else
                        {
                            buscarBR(VariablesSeccionControl.Lee<string>("Brigada"), VariablesSeccionControl.Lee<string>("AreaConserv"));
                        }
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
            BrigadaDB DB = new BrigadaDB();

            if (Button2.Text.Equals(buttonName))
            {
                if (DB.inactivar(true, VariablesSeccionControl.Lee<string>("Brigada")))
                {
                    mensaje("La brigada se ha inactivado", true);
                }
                else
                {
                    mensaje("Ocurrio un error al guardar la información", false);
                }
            }
            else
            {
                if (DB.inactivar(false, VariablesSeccionControl.Lee<string>("Brigada")))
                {
                    mensaje("La brigada se ha activado", true);
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

        protected void cargarInfo(string brigada, string areaCons)
        {
            this.brigada.Value = brigada;
            this.areaCons.SelectedValue = areaCons;
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Button2.Text.Equals(buttonName))
            {
                Alert("¿Desea realmente desactivar esta brigada?");
            }
            else
            {
                Alert("¿Desea realmente reactivar esta brigada?");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //guarda la informacion en la base de datos
            BrigadaDB DB = new BrigadaDB();
            AreaConservacionDB DB2 = new AreaConservacionDB();
            AreaConservacion temp = DB2.seleccionar(areaCons.SelectedValue);

            if (DB.actualizar(VariablesSeccionControl.Lee<string>("Brigada"), new Brigada(brigada.Value, 0, DB2.getId(temp.getNombre()))))
            {
                mensaje("La brigada ha sido modificada", true);
            }
            else
            {
                mensaje("Ocurrio un error al guardar la información", true);
            }
        }

        private void buscarBR(string brigada, string areaConserv)
        {
            //carga la informacion de la base de datos
            BrigadaDB DB = new BrigadaDB();
            Brigada temp = DB.seleccionar(brigada);


            if (temp != null)
            {
                if (!DB.getEstado(VariablesSeccionControl.Lee<string>("Brigada")))
                {
                    Button2.Text = "Activar";
                }

                CargarComboboxArea(areaCons);
                cargarInfo(temp.getNombre(), areaConserv);
            }
            else
            {
                mensaje("La Brigada " + brigada + " no se encuentra", true);
            }
        }

        protected void CargarComboboxArea(DropDownList combobox)
        {
            try
            {
                AreaConservacionDB DB = new AreaConservacionDB();
                List<string> areasList = DB.listaAreasConserv();

                for (int i = 0; i < areasList.Count; i++)
                {
                    combobox.Items.Add(areasList[i]);
                }


            }
            catch { }
        }
    }
}