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
    public partial class MEquipoProtPerso : System.Web.UI.Page
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
                        Response.Redirect("CBomberos.aspx");
                    }
                    else
                    {
                        buscarEQ(VariablesSeccionControl.Lee<int>("EquipoProtPerso"));
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
            EquipoProtPersoDB DB = new EquipoProtPersoDB();

            if (Button2.Text.Equals(buttonName))
            {
                if (DB.inactivar(true, VariablesSeccionControl.Lee<int>("EquipoProtPerso")))
                {
                    mensaje("El equipo de protección se ha inactivado", true);
                }
                else
                {
                    mensaje("Ocurrio un error al guardar la información", false);
                }
            }
            else
            {
                if (DB.inactivar(false, VariablesSeccionControl.Lee<int>("EquipoProtPerso")))
                {
                    mensaje("El equipo de protección se ha activado", true);
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

        protected void cargarInfo(string nombre, int cantEntre, string fechaEntre, string estadoHerram, string observaciones)
        {
            this.nombreList.SelectedValue = nombre;
            this.cantEntre.Value = Convert.ToString(cantEntre);
            this.fechEntreg.Value = fechaEntre;
            this.estado.SelectedValue = estadoHerram;
            this.observaciones.Value = observaciones;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Button2.Text.Equals(buttonName))
            {
                Alert("¿Desea realmente desactivar este equipo?");
            }
            else
            {
                Alert("¿Desea realmente reactivar este equipo?");
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //guarda la informacion en la base de datos
            EquipoProtPersoDB DB = new EquipoProtPersoDB(); 
            if (DB.actualizar(VariablesSeccionControl.Lee<int>("EquipoProtPerso"), new EquipoProtecPerson(nombreList.SelectedValue, Convert.ToInt32(cantEntre.Value), fechEntreg.Value, estado.SelectedValue, observaciones.Value, null)))
            {
                mensaje("El equipo de protección ha sido modificado", true);
            }
            else
            {
                mensaje("Ocurrio un error al guardar la información", false);
            }
        }

        private void buscarEQ(int id)
        {
            //carga la informacion de la base de datos
            EquipoProtPersoDB DB = new EquipoProtPersoDB();
            EquipoProtecPerson temp = DB.seleccionar(id);

            if (temp != null)
            {
                if (!DB.getEstado(VariablesSeccionControl.Lee<int>("EquipoProtPerso")))
                {
                    Button2.Text = "Activar";
                }

                cargarInfo(temp.getNombre(), temp.getCantEntre(), temp.getFechaEntre(), temp.getEstadoHerram(), temp.getObservaciones());
            }
            else
            {
                mensaje("Ocurrio un error al cargar la información", true);
            }
        }
    }
}