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
            //if (!IsPostBack)
            //{
            //    if (VariablesSeccionControl.Lee<string>("userAreaConserv") == null)
            //    {
            //        Response.Redirect("/index.aspx");
            //    }
            //    else
            //    {
            //        if (VariablesSeccionControl.Lee<string>("Bombero") == null)
            //        {
            //            Response.Redirect("CBomberos.aspx");
            //        }
            //        else
            //        {
            //            ReseniaMedicaDB DB = new ReseniaMedicaDB();
            //            ReseniaMedic temp = DB.seleccionar(VariablesSeccionControl.Lee<string>("Bombero"));
            //            if (temp != null)
            //            {
            //                cargarInfo(temp.getInternado(), temp.getMotivoIN(), temp.getTratMedic(), temp.getMotivoTM(), temp.getLentCont(), temp.getMotivoLC(), temp.getOperado(), temp.getMotivoOP(), temp.getLimitFisic(), temp.getTipoLimitFisic(), temp.getCheckMedic(), temp.getDiagnostico(), temp.getTipoSangre());
            //            }

            //        }
            //    }
            //}
        }
        protected void mensaje(String mensaje)
        {
            this.labelMensaje.InnerText = mensaje;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //ReseniaMedicaDB registrar = new ReseniaMedicaDB();

            //if (registrar.insertar(new ReseniaMedic(internado.Checked, inter.Text, tratMedic.Checked, tratamiento.Text, lentesContacto.Checked, lentContText.Text, operado.Checked, operadoText.Text, limitFisic.Checked, limitacionFisica.Text, checkMedic.Checked, Chequeado.Text, TipoSangre.SelectedValue, VariablesSeccionControl.Lee<string>("Bombero")))
            // || registrar.actualizar(VariablesSeccionControl.Lee<string>("Bombero"), new ReseniaMedic(internado.Checked, inter.Text, tratMedic.Checked, tratamiento.Text, lentesContacto.Checked, lentContText.Text, operado.Checked, operadoText.Text, limitFisic.Checked, limitacionFisica.Text, checkMedic.Checked, Chequeado.Text, TipoSangre.SelectedValue, VariablesSeccionControl.Lee<string>("Bombero"))))
            //{
            //    mensaje("Reseña médica guardada", false);
            //}

            //else
            //{
            //    mensaje("Ocurrio un error al guardar la información", false);
            //}
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

        protected void cargarInfo(bool internado, String motivoIN,
            bool tratMedic, String motivoTM, bool lentCont, String motivoLC, bool operado, String motivoOP, bool limitFisic,
            String tipoLimitFisic, bool checkMedic, String diagnostico, String tipoSangre)
        {
            //this.internado.Checked = internado;
            //this.inter.Text = motivoIN;
            //this.tratMedic.Checked = tratMedic;
            //this.tratamiento.Text = motivoTM;
            //this.lentesContacto.Checked = lentCont;
            //this.lentContText.Text = motivoLC;
            //this.operado.Checked = operado;
            //this.operadoText.Text = motivoOP;
            //this.limitFisic.Checked = limitFisic;
            //this.limitacionFisica.Text = tipoLimitFisic;
            //this.checkMedic.Checked = checkMedic;
            //this.Chequeado.Text = diagnostico;
            //this.TipoSangre.SelectedValue = tipoSangre;
        }
    }
}