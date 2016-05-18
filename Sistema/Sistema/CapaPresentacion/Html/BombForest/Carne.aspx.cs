using CapaConfiguracion;
using CapaLogica;
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
    public partial class Carne : System.Web.UI.Page
    {
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
                        CarneDB DB = new CarneDB();
                        Carnet temp = DB.seleccionar(VariablesSeccionControl.Lee<string>("Bombero"));
                        if (temp != null)
                        {
                            cargarInfo(temp.getAnioCarnet(), temp.getEmisionCarnet(), temp.getFechaVencimiento());
                        }
                        else
                        {
                            cargarInfo();
                        }

                    }
                }
            }
        }
        protected void mensaje(String mensaje)
        {
            this.labelMensaje.InnerText = mensaje;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            CarneDB registrar = new CarneDB();

            if (registrar.insertar(new Carnet(Convert.ToInt32(anioCarne.Value), emiCarne.Value, FechaVencim.Value, VariablesSeccionControl.Lee<string>("Bombero")))
             || registrar.actualizar(VariablesSeccionControl.Lee<string>("Bombero"), new Carnet(Convert.ToInt32(anioCarne.Value), emiCarne.Value, FechaVencim.Value, VariablesSeccionControl.Lee<string>("Bombero"))))
            {
                mensaje("Carné guardado", false);
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

        protected void cargarInfo(int anioCarnet, string emisionCarnet, string fechaVencimiento)
        {
            // parte de carne
            this.anioCarne.Value = Convert.ToString(anioCarnet);
            this.emiCarne.Value = emisionCarnet;
            this.FechaVencim.Value = fechaVencimiento;

            cargarInfo();
        }

        protected void cargarInfo()
        {
            //parte de info person
            BomberoDB B_DB = new BomberoDB();
            Bombero B_temp = B_DB.seleccionar(VariablesSeccionControl.Lee<string>("Bombero"));

            if (B_temp != null)
            {
                this.nombre.Value = B_temp.getNombre();
                this.p_Ape.Value = B_temp.getApellido1();
                this.s_Ape.Value = B_temp.getApellido2();
                this.fechaNacim.Value = B_temp.getFechaNac();
                this.Image1.Src = ImageControl.byteVecToIMG(B_temp.getImgPerfil());
            }

            // parte de reseña medica
            ReseniaMedicaDB R_DB = new ReseniaMedicaDB();
            ReseniaMedic R_temp = R_DB.seleccionar(VariablesSeccionControl.Lee<string>("Bombero"));

            if (R_temp != null)
            {
                this.tipoSangre.Value = R_temp.getTipoSangre();
            }
        }
    }
}