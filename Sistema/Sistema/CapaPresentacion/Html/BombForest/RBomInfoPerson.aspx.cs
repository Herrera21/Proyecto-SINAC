using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogica;
using CapaConfiguracion;

namespace Sistema.CapaPresentacion.Html.BombForest
{
    public partial class RBomInfoPerson : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (VariablesSeccionControl.Lee<string>("userAreaConserv") == null)
            {
                Response.Redirect("/index.aspx");
            }
            else
            {
                if (VariablesSeccionControl.Lee<string>("Brigada") == null)
                {
                    Response.Redirect("CBomberos.aspx");
                }
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            //guarda la informacion en la base de datos
            BomberoDB DB = new BomberoDB();
            BrigadaDB DB2 = new BrigadaDB();
            Brigada temp = DB2.seleccionar(VariablesSeccionControl.Lee<string>("Brigada"));

            if (DB.insertar(new Bombero(cedula.Value, nombre.Value, p_Ape.Value, s_Ape.Value, tipoBombero.SelectedIndex, provincia.Value,
                canton.Value, lugarResid.Value, nacionalidad.SelectedIndex.ToString(), fechaNac.Value, telResid.Value, telCel.Value, ocupacion.Value, correo.Value,
                Convert.ToInt32(aniosBrig.Value), ImageControl.fileInpTObyteVec(FileUpload1), ImageControl.fileInpTObyteVec(FileUpload2), DB.idBrigada(VariablesSeccionControl.Lee<string>("Brigada")))))
            {
                mensaje("El Bombero ha sido creado", true);
            }
            else
            {
                mensaje("Ocurrio un error al guardar la información", true);
            }
        }
    }
}