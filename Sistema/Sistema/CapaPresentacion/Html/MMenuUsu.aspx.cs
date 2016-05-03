using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogica;
using CapaConfiguracion;

namespace Sistema.CapaPresentacion.Html
{
    public partial class MMenuUsu : System.Web.UI.Page
    {
        private const string buttonName = "Inactivar";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (VariablesSeccionControl.Lee<string>("userAreaConserv") == null)
            {
                Response.Redirect("/index.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    UsuarioDB DB = new UsuarioDB();
                    CargarCombobox(AreaCons);
                    activaModal("buscar", true);
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
            UsuarioDB DB = new UsuarioDB();

            if (Button2.Text.Equals(buttonName))
            {
                if (DB.inactivar(true, usuario.Value))
                {
                    if(usuario.Value.Equals(VariablesSeccionControl.Lee<string>("userName")))
                    {
                        VariablesSeccionControl.Escribe("userRol", null);
                        VariablesSeccionControl.Escribe("userAreaConserv", null);
                        VariablesSeccionControl.Escribe("userName", null);
                        mensaje("El usuario se ha inactivado", true);
                    }
                    else
                    {
                        mensaje("El usuario se ha inactivado", true);
                    }
                }
                else
                {
                    mensaje("Ocurrio un error al guardar la información", false);
                }
            }
            else
            {
                if (DB.inactivar(false, usuario.Value))
                {
                    mensaje("El usuario se ha activado", true);
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

        protected void cargarInfo(string cedula, string nombre, string apellido1, string apellido2, string usuario, string email, string contrasenia, int funcion, int areaConserv)
        {
            AreaConservacionDB temp = new AreaConservacionDB();

            this.usuario.Value = usuario;
            this.email.Value = email;
            this.contrasenia.Value = contrasenia;
            this.confContrasenia.Value = contrasenia;
            this.radioButtonFuncion.SelectedIndex = funcion;
            this.nombre.Value = nombre;
            this.apellido1.Value = apellido1;
            this.apellido2.Value = apellido2;
            this.cedula.Value = cedula;
            this.AreaCons.SelectedValue = temp.getNombre(areaConserv);
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Button2.Text.Equals(buttonName))
            {
                Alert("¿Desea realmente desactivar este usuario?");
            }
            else
            {
                Alert("¿Desea realmente reactivar este usuario?");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //guarda la informacion en la base de datos
            UsuarioDB registrar = new UsuarioDB();
            AreaConservacionDB temp = new AreaConservacionDB();

            if (contrasenia.Value.Equals(confContrasenia.Value))
            {
                if (registrar.actualizar(B_Usuario.Value, new Usuario(cedula.Value, nombre.Value, apellido1.Value, apellido2.Value, usuario.Value, email.Value, contrasenia.Value, Convert.ToByte(radioButtonFuncion.SelectedItem.Value), temp.getId(AreaCons.SelectedValue))))
                {
                    mensaje("El usuario ha sido modificado", true);
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

        protected void ButtonCargar(object sender, EventArgs e)
        {
            //carga de la base de datos
            UsuarioDB DB = new UsuarioDB();
            Usuario temp = DB.seleccionar(B_Usuario.Value);

            if (temp != null)
            {
                cargarInfo(temp.getIdentificacion(), temp.getNombre(), temp.getApellido1(), temp.getApellido2(), temp.getUsuario(), temp.getCorreo(), temp.getPass(), temp.getRol(), temp.getAreaConserv());
                if (!DB.getEstado(B_Usuario.Value))
                {
                    Button2.Text = "Activar";
                }
            }
            else
            {
                mensaje("El Usuario " + B_Usuario.Value + " no se encuentra", true);
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            activaModal("confContraseña", true);
        }
    }
}