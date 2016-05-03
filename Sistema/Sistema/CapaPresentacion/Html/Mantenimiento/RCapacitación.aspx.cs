﻿using Sistema.CapaConfiguracion;
using Sistema.CapaLogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sistema.CapaPresentacion.Html.BombForest
{
    public partial class RCapacitación : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (VariablesSeccionControl.Lee<string>("userAreaConserv") == null)
            {
                Response.Redirect("/index.aspx");
            }
        }

        protected void ejecScript(string dato)
        {
            string script = string.Format(dato);
            ScriptManager.RegisterStartupScript(this, Page.ClientScript.GetType(), null, script, true);
        }

        protected void activaModal(string id)
        {
            ejecScript("javascript:$('#" + id + "').modal('show');");
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
            //registra area de conservacion
            CapacitacionDB registrar = new CapacitacionDB();

            if (registrar.insertar(new Capacitacion(nombreCap.Value, lugarCap.Value, institut.Value, Convert.ToInt32(cantHoras.Value), fechaEmiCap.Value, fechaCad.Value)))
            {
                mensaje("La capacitación ha sido creada", true);
            }
            else
            {
                mensaje("Ocurrio un error al guardar la información", false);
            }
        }
    }
}