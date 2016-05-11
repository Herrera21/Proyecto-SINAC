using Sistema.CapaConfiguracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sistema.CapaPresentacion.Html.BombForest
{
    public partial class RReseniaMedica : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void mensaje(String mensaje)
        {
            this.labelMensaje.InnerText = mensaje;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            ReseniaMedicaDB registrar = new ReseniaMedicaDB();

            

            if (
            registrar.insertar(new ReseniaMedicaDB(Convert.ToByte(internado.Checked), inter.Text, Convert.ToByte(tratMedic.Checked), tratamiento.Text, Convert.ToByte(lentesContacto.Checked), TextBox1.Text,Convert.ToByte(operado.Checked), TextBox2.Text, Convert.ToByte(limitfisic.Checked),limitacionFisica.Text, Convert.ToByte(CheckBox1.Checked), limitacion.Text, "sgd", VariablesSeccionControl.Lee<string>("Bombero"))))
            {
                mensaje("La reseña medica ha sido creada", true);
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