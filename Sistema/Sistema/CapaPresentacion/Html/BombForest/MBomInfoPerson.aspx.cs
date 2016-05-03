﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogica;
using CapaConfiguracion;

namespace Sistema.CapaPresentacion.Html.BombForest
{
    public partial class MBomInfoPerson : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //desabilitar(true);
            if (!IsPostBack)
            {
                //carga las areas en el combobox desde la base

                CargarComboboxArea(Area);
                CargarComboboxBriga(Brigadas);
                CargarComboboxBomberos(Bomberos);
                activaModal("buscar");
                VariablesSeccionControl.Escribe("pageBack", "MMenuBrigada");
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
        protected void Alert(String mensaje)
        {
            this.labelAlert.InnerText = mensaje;
            activaModal("alert");
        }

        protected void ButtonAcepta(object sender, EventArgs e)
        {
            cedula.Disabled = true;
            nombre.Disabled = true;
            p_Ape.Disabled = true;
            s_Ape.Disabled = true;
            provincia.Disabled = true;
            canton.Disabled = true;
            lugarResid.Disabled = true;
            nacionalidad.Disabled = true;
            fechaNac.Disabled = true;
            telResid.Disabled = true;
            telCel.Disabled = true;
            ocupacion.Disabled = true;
            correo.Disabled = true;
            aniosBrig.Disabled = true;
            tipoBombero.Disabled = true;
            Button2.Text = "Activar";
        }

        protected void ButtonCancela(object sender, EventArgs e)
        {
            desabilitar(false);
        }
        protected void desabilitar(bool valor)
        {
            this.cedula.Disabled = valor;
            this.nombre.Disabled = valor;
            this.p_Ape.Disabled = valor;
            this.s_Ape.Disabled = valor;
            this.provincia.Disabled = valor;
            this.canton.Disabled = valor;
            this.lugarResid.Disabled = valor;
            this.nacionalidad.Disabled = valor;
            this.fechaNac.Disabled = valor;
            this.telResid.Disabled = valor;
            this.telCel.Disabled = valor;
            this.ocupacion.Disabled = valor;
            this.correo.Disabled = valor;
            this.aniosBrig.Disabled = valor;
            this.tipoBombero.Disabled = valor;
        }

        protected void cargarInfo(String identificacion, String nombre,
            String apellido1, String apellido2, String provincia, String canton, String residencia, String nacionalidad, String fechaNac,
            String telResidencia, String telCelular, String ocupacion, String correo, int aniosEnBriga, int tipoBombe, byte[] Perfil, byte[] Ced)
        {
            this.cedula.Value = identificacion;
            this.nombre.Value = nombre;
            this.p_Ape.Value = apellido1;
            this.s_Ape.Value = apellido2;
            this.provincia.Value = provincia;
            this.canton.Value = canton;
            this.lugarResid.Value = residencia.ToString();
            this.nacionalidad.SelectedIndex = Int32.Parse(nacionalidad);
            this.fechaNac.Value = fechaNac;
            this.telResid.Value = telResidencia;
            this.telCel.Value = telCelular;
            this.ocupacion.Value = ocupacion;
            this.correo.Value = correo;
            this.aniosBrig.Value = aniosEnBriga.ToString();
            this.tipoBombero.SelectedIndex = tipoBombe;
            this.Image1.Src = ImageControl.byteVecToIMG(Perfil);
            this.Image2.Src = ImageControl.byteVecToIMG(Ced);
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Button2.Text.Equals("Inactivar"))
            {
                Alert("¿Desea realmente desactivar este bombero?");
            }
            else
            {
                desabilitar(false);
                Button2.Text = "Inactivar";
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //guarda la informacion en la base de datos
            BomberoDB DB = new BomberoDB();
            BrigadaDB DB2 = new BrigadaDB();
            Brigada temp = DB2.seleccionar(Brigadas.SelectedValue);

            if (DB.actualizar(cedula.Value, new Bombero(cedula.Value, nombre.Value, p_Ape.Value, s_Ape.Value, tipoBombero.SelectedIndex, provincia.Value,
                canton.Value, lugarResid.Value, nacionalidad.SelectedIndex.ToString(), fechaNac.Value, telResid.Value, telCel.Value, ocupacion.Value, correo.Value,
                Convert.ToInt32(aniosBrig.Value), ImageControl.fileInpTObyteVec(FileUpload1), ImageControl.fileInpTObyteVec(FileUpload2), DB.idBrigada(temp.getNombre()))))
            {
                mensaje("El bombero ha sido modificado", true);
            }
            else
            {
                mensaje("Ocurrio un error al guardar la información", true);
            }
        }

        protected void ButtonCargar(object sender, EventArgs e)
        {
            //carga la informacion de la base de datos
            BomberoDB DB = new BomberoDB();
            var cadena = Bomberos.SelectedValue;
            var posicion = cadena.IndexOf(" ");
            Bombero temp = DB.seleccionar(cadena.Substring(0, posicion));

            var temp2 = Brigadas.SelectedIndex;
            var temp3 = Area.SelectedIndex;


            if (temp != null)
            {
                //CargarComboboxArea(areaCons);
                cargarInfo(temp.getIdentificacion(), temp.getNombre(), temp.getApellido1(), temp.getApellido2(), temp.getProvincia(), temp.getCanton(),
                    temp.getResidencia(), temp.getNacionalidad(), temp.getFechaNac(), temp.getTelResidencia(), temp.getTelCelular(), temp.getOcupacion(),
                    temp.getCorreo(), temp.getAniosEnBriga(), temp.getTipoBombe(), temp.getImgPerfil(), temp.getImgCed());
                desabilitar(false);
                mensaje("Informacion cargada", false);
            }
            else
            {
                mensaje("EL Bombero " + Bomberos.SelectedValue + " no se encuentra", true);
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

        protected void CargarComboboxBriga(DropDownList combobox)
        {

            try
            {
                BrigadaDB DB = new BrigadaDB();
                List<string> brigadasList = DB.listaBrigadas(Area.SelectedValue);

                for (int i = 0; i < brigadasList.Count; i++)
                {
                    combobox.Items.Add(brigadasList[i]);
                }
            }
            catch { }
        }

        protected void CargarComboboxBomberos(DropDownList combobox)
        {

            try
            {
                BomberoDB DB = new BomberoDB();
                List<string> bomberosList = DB.listaBomberos(Area.SelectedValue, Brigadas.SelectedValue);

                for (int i = 0; i < bomberosList.Count; i++)
                {
                    combobox.Items.Add(bomberosList[i]);
                }
            }
            catch { }
        }

        protected void Area_SelectedIndexChanged(object sender, EventArgs e)
        {
            Brigadas.Items.Clear();
            CargarComboboxBriga(Brigadas);
            Bomberos.Items.Clear();
            CargarComboboxBomberos(Bomberos);
            activaModal("buscar");
        }

        protected void Brigadas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bomberos.Items.Clear();
            CargarComboboxBomberos(Bomberos);
            activaModal("buscar");
        }
    }
}