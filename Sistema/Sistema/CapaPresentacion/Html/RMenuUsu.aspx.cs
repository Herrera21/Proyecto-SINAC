using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaConfiguracion;
using CapaLogica;


namespace Sistema.CapaPresentacion.Html
{
    public partial class RMenuUsu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (VariablesSeccionControl.Lee<string>("userAreaConserv") == null)
            {
                Response.Redirect("/index.aspx");
            }
            else
            {
                CargarCombobox(AreaCons);
            }
        }
        protected void activaModal(string id)
        {
            string script = string.Format("javascript:$('#" + id + "').modal('show');");
            ScriptManager.RegisterStartupScript(this, Page.ClientScript.GetType(), null, script, true);
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

        protected void CargarCombobox(DropDownList combobox)
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            //guarda la informacion en la base de datos
            UsuarioDB registrar = new UsuarioDB();
            AreaConservacionDB areacons = new AreaConservacionDB();

            if (contrasenia.Value.Equals(confContrasenia.Value))
            {
                if (registrar.insertar(new Usuario(cedula.Value, nombre.Value, apellido1.Value, apellido2.Value, usuario.Value, email.Value, contrasenia.Value, Convert.ToByte(radioButtonFuncion.SelectedItem.Value), areacons.getId(AreaCons.SelectedValue))))
                {
                    mensaje("El usuario ha sido creado", true);
                }
                else
                {
                    mensaje("Ocurrio un error al guardar la información", false);
                }
            }
            else
            {
                mensaje("Las contraseñas no coinciden", false);

            }
        }
    }
}