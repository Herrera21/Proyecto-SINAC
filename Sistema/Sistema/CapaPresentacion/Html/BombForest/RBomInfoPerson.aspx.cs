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
            desabilitar(true);
            if (!IsPostBack)
            {
                //carga las areas en el combobox desde la base

                CargarComboboxArea(Area);
                CargarComboboxBriga(Brigadas);
                activaModal("buscar");
                VariablesSeccionControl.Escribe("pageBack", "RBomInfoPerson");
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

        protected void desabilitar(bool valor)
        {
            this.nombre.Disabled = valor;
            this.p_Ape.Disabled = valor;
            this.s_Ape.Disabled = valor;
            this.cedula.Disabled = valor;
            this.lugarResid.Disabled = valor;
            this.telResid.Disabled = valor;
            this.telCel.Disabled = valor;
            this.ocupacion.Disabled = valor;
            this.correo.Disabled = valor;
            this.aniosBrig.Disabled = valor;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //guarda la informacion en la base de datos
            BomberoDB DB = new BomberoDB();
            BrigadaDB DB2 = new BrigadaDB();
            Brigada temp = DB2.seleccionar(Brigadas.SelectedValue);

            if (DB.insertar(new Bombero(cedula.Value, nombre.Value, p_Ape.Value, s_Ape.Value, tipoBombero.SelectedIndex, provincia.Value,
                canton.Value, lugarResid.Value, nacionalidad.SelectedIndex.ToString(), fechaNac.Value, telResid.Value, telCel.Value, ocupacion.Value, correo.Value,
                Convert.ToInt32(aniosBrig.Value), ImageControl.fileInpTObyteVec(FileUpload1), ImageControl.fileInpTObyteVec(FileUpload2), DB.idBrigada(temp.getNombre()))))
            {
                mensaje("El Bombero ha sido creado", true);
            }
            else
            {
                mensaje("Ocurrio un error al guardar la información", true);
            }
        }
        protected void ButtonRegistrar(object sender, EventArgs e)
        {
            //hace el enlace con area, brigada y tipoBombero
            desabilitar(false);
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

        protected void Area_SelectedIndexChanged(object sender, EventArgs e)
        {
            Brigadas.Items.Clear();
            CargarComboboxBriga(Brigadas);
            activaModal("buscar");
        }
    }
}