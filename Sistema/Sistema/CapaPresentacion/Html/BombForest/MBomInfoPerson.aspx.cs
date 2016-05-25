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
    public partial class MBomInfoPerson : System.Web.UI.Page
    {
        private const string buttonName = "Inactivar";

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarComboboxProvincias(Provincia);
            if (!IsPostBack)
            {
                if (VariablesSeccionControl.Lee<string>("userAreaConserv") == null)
                {
                    Response.Redirect("/index.aspx");
                }
                else
                {
                    if (VariablesSeccionControl.Lee<string>("Brigada") == null)
                    {
                        Response.Redirect("CAreaConserv.aspx");
                    }
                    else
                    {
                        if (VariablesSeccionControl.Lee<string>("Bombero") == null)
                        {
                            Response.Redirect("CBomberos.aspx");
                        }
                        else
                        {
                            buscarBOM(VariablesSeccionControl.Lee<string>("Bombero"), VariablesSeccionControl.Lee<string>("Brigada"));
                        }
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
            BomberoDB DB = new BomberoDB();

            if (Button2.Text.Equals(buttonName))
            {
                if (DB.inactivar(true, VariablesSeccionControl.Lee<string>("Bombero")))
                {
                    mensaje("El bombero se ha inactivado", true);
                }
                else
                {
                    mensaje("Ocurrio un error al guardar la información", false);
                }
            }
            else
            {
                if (DB.inactivar(false, VariablesSeccionControl.Lee<string>("Bombero")))
                {
                    mensaje("El bombero se ha activado", true);
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

        protected void cargarInfo(String identificacion, String nombre,
            String apellido1, String apellido2, String provincia, String canton, String distrito, String residencia, String nacionalidad, String fechaNac,
            String telResidencia, String telCelular, String ocupacion, String correo, int aniosEnBriga, String tipoBombe, byte[] Perfil, byte[] Ced)
        {
            this.cedula.Value = identificacion;
            this.nombre.Value = nombre;
            this.p_Ape.Value = apellido1;
            this.s_Ape.Value = apellido2;
            this.Provincia.SelectedValue = provincia;
            CargarComboboxCanton(Canton);
            this.Canton.SelectedValue = canton;
            CargarComboboxDistrito(Distrito);
            this.Distrito.SelectedValue = distrito;
            this.lugarResid.Value = residencia;
            this.nacionalidad.SelectedValue = nacionalidad;
            this.fechaNac.Value = fechaNac;
            this.telResid.Value = telResidencia;
            this.telCel.Value = telCelular;
            this.ocupacion.Value = ocupacion;
            this.correo.Value = correo;
            this.aniosBrig.Value = aniosEnBriga.ToString();
            this.tipoBombero.SelectedValue = tipoBombe;
            this.Image1.Src = ImageControl.byteVecToIMG(Perfil);
            this.Image2.Src = ImageControl.byteVecToIMG(Ced);
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Button2.Text.Equals(buttonName))
            {
                Alert("¿Desea realmente desactivar este bombero?");
            }
            else
            {
                Alert("¿Desea realmente reactivar este bombero?");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //guarda la informacion en la base de datos
            BomberoDB DB = new BomberoDB();
            BrigadaDB DB2 = new BrigadaDB();
            Brigada temp = DB2.seleccionar(VariablesSeccionControl.Lee<string>("Brigada"));

            if (DB.actualizar(cedula.Value, new Bombero(cedula.Value, nombre.Value, p_Ape.Value, s_Ape.Value, tipoBombero.SelectedItem.ToString(), Provincia.SelectedItem.ToString(),
                Canton.SelectedItem.ToString(), Distrito.SelectedItem.ToString(), lugarResid.Value, nacionalidad.SelectedItem.ToString(), fechaNac.Value, telResid.Value, telCel.Value, ocupacion.Value, correo.Value,
                Convert.ToInt32(aniosBrig.Value), ImageControl.fileInpTObyteVec(FileUpload1), ImageControl.fileInpTObyteVec(FileUpload2), DB.idBrigada(VariablesSeccionControl.Lee<string>("Brigada")))))
            {
                mensaje("El bombero ha sido modificado", true);
            }
            else
            {
                mensaje("Ocurrio un error al guardar la información", true);
            }
        }

        private void buscarBOM(string bombero, string brigada)
        {
            //carga la informacion de la base de datos
            BomberoDB DB = new BomberoDB();
            Bombero temp = DB.seleccionar(bombero);


            if (temp != null)
            {
                if (!DB.getEstado(bombero))
                {
                    Button2.Text = "Activar";
                }

                cargarInfo(temp.getIdentificacion(), temp.getNombre(), temp.getApellido1(), temp.getApellido2(), temp.getProvincia(), temp.getCanton(), temp.getDistrito(),
                    temp.getResidencia(), temp.getNacionalidad(), temp.getFechaNac(), temp.getTelResidencia(), temp.getTelCelular(), temp.getOcupacion(),
                    temp.getCorreo(), temp.getAniosEnBriga(), temp.getTipoBombe(), temp.getImgPerfil(), temp.getImgCed());
            }
            else
            {
                mensaje("El bombero " + bombero + " no se encuentra", true);
            }
        }

        protected void CargarComboboxProvincias(DropDownList combobox)
        {
            try
            {
                ProvinciaDB DB = new ProvinciaDB();
                List<string> provinciasList = DB.listaProvincias();

                for (int i = 0; i < provinciasList.Count; i++)
                {
                    combobox.Items.Add(provinciasList[i]);
                }


            }
            catch { }
        }

        protected void CargarComboboxCanton(DropDownList combobox)
        {
            try
            {
                CantonDB DB = new CantonDB();
                List<string> cantonesList = DB.listaCantones(Provincia.SelectedValue);

                for (int i = 0; i < cantonesList.Count; i++)
                {
                    combobox.Items.Add(cantonesList[i]);
                }
            }
            catch
            {

            }
        }

        protected void CargarComboboxDistrito(DropDownList combobox)
        {
            try
            {
                DistritoDB DB = new DistritoDB();
                List<string> distritosList = DB.listaDistritos(Canton.SelectedValue);

                for (int i = 0; i < distritosList.Count; i++)
                {
                    combobox.Items.Add(distritosList[i]);
                }
            }
            catch
            {

            }
        }

        protected void Provincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            Canton.Items.Clear();
            CargarComboboxCanton(Canton);
            Distrito.Items.Clear();
            CargarComboboxDistrito(Distrito);
        }

        protected void Canton_SelectedIndexChanged(object sender, EventArgs e)
        {
            Distrito.Items.Clear();
            CargarComboboxDistrito(Distrito);
        }

        //protected void ButtonCargar(object sender, EventArgs e)
        //{
        //    //carga la informacion de la base de datos
        //    BomberoDB DB = new BomberoDB();
        //    var cadena = Bomberos.SelectedValue;
        //    var posicion = cadena.IndexOf(" ");
        //    Bombero temp = DB.seleccionar(cadena.Substring(0, posicion));

        //    var temp2 = Brigadas.SelectedIndex;
        //    var temp3 = Area.SelectedIndex;


        //    if (temp != null)
        //    {
        //        //CargarComboboxArea(areaCons);
        //        cargarInfo(temp.getIdentificacion(), temp.getNombre(), temp.getApellido1(), temp.getApellido2(), temp.getProvincia(), temp.getCanton(),
        //            temp.getResidencia(), temp.getNacionalidad(), temp.getFechaNac(), temp.getTelResidencia(), temp.getTelCelular(), temp.getOcupacion(),
        //            temp.getCorreo(), temp.getAniosEnBriga(), temp.getTipoBombe(), temp.getImgPerfil(), temp.getImgCed());
        //        desabilitar(false);
        //        mensaje("Informacion cargada", false);
        //    }
        //    else
        //    {
        //        mensaje("EL Bombero " + Bomberos.SelectedValue + " no se encuentra", true);
        //    }
        //}

        //protected void CargarComboboxArea(DropDownList combobox)
        //{
        //    try
        //    {
        //        AreaConservacionDB DB = new AreaConservacionDB();
        //        List<string> areasList = DB.listaAreasConserv();

        //        for (int i = 0; i < areasList.Count; i++)
        //        {
        //            combobox.Items.Add(areasList[i]);
        //        }


        //    }
        //    catch { }
        //}

        //protected void CargarComboboxBriga(DropDownList combobox)
        //{

        //    try
        //    {
        //        BrigadaDB DB = new BrigadaDB();
        //        List<string> brigadasList = DB.listaBrigadas(Area.SelectedValue);

        //        for (int i = 0; i < brigadasList.Count; i++)
        //        {
        //            combobox.Items.Add(brigadasList[i]);
        //        }
        //    }
        //    catch { }
        //}

        //protected void CargarComboboxBomberos(DropDownList combobox)
        //{

        //    try
        //    {
        //        BomberoDB DB = new BomberoDB();
        //        List<string> bomberosList = DB.listaBomberos(Area.SelectedValue, Brigadas.SelectedValue);

        //        for (int i = 0; i < bomberosList.Count; i++)
        //        {
        //            combobox.Items.Add(bomberosList[i]);
        //        }
        //    }
        //    catch { }
        //}

        //protected void Area_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Brigadas.Items.Clear();
        //    CargarComboboxBriga(Brigadas);
        //    Bomberos.Items.Clear();
        //    CargarComboboxBomberos(Bomberos);
        //    activaModal("buscar");
        //}

        //protected void Brigadas_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Bomberos.Items.Clear();
        //    CargarComboboxBomberos(Bomberos);
        //    activaModal("buscar");
        //}
    }
}