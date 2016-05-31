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
            if (!IsPostBack)
            {
                CargarComboboxProvincias(Provincia);
            }
            CargarComboboxCanton(Canton);
            CargarComboboxDistrito(Distrito);
            if (VariablesSeccionControl.Lee<string>("userAreaConserv") == null)
            {
                Response.Redirect("/index.aspx");
            }
            else
            {
                if (VariablesSeccionControl.Lee<string>("Brigada") == null)
                {
                    Response.Redirect("CBomberos.aspx");
                }else
                {
                    if (!IsPostBack)
                    {
                        activaModal("buscarId", true);
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
                string script = string.Format("javascript:$('#" + id + "').modal('hide');");
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

        protected void ButtonVerificarId(object sender, EventArgs e)
        {
            
            String idV = verificarIdInput.Value;
            BomberoDB DB = new BomberoDB();
            Bombero temp = DB.seleccionar(idV);

            if (temp != null)
            {
                //this.labelMensaje.InnerText = "Esta cédula ya pertenece a un bombero registrado en el sistema";

                activaModal("mensajes2", true);
                activaModal("buscarId", true);
                //Response.Write("<script>alert('Esta cédula ya pertenece a un bombero registrado en el sistema')</script>");
            }
            else
            {
                //activaModal("buscarId", false);
                cedula.Value = idV;
                //mensaje("Identificación correcta", true);
            }

            //Bombero temp = DB.seleccionar();

                //if (temp != null)
                //{
                //}
                //else
                //{
                //VariablesSeccionControl.Lee<string>("Bombero")
                //}
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //guarda la informacion en la base de datos
            BomberoDB DB = new BomberoDB();
            BrigadaDB DB2 = new BrigadaDB();
            Brigada temp = DB2.seleccionar(VariablesSeccionControl.Lee<string>("Brigada"));

            if (DB.insertar(new Bombero(cedula.Value, nombre.Value, p_Ape.Value, s_Ape.Value, tipoBombero.SelectedItem.ToString(), Provincia.SelectedItem.ToString(),
                Canton.SelectedItem.ToString(), Distrito.SelectedItem.ToString(), lugarResid.Value, nacionalidad.SelectedItem.ToString(), fechaNac.Value, telResid.Value, telCel.Value, ocupacion.Value, correo.Value,
                Convert.ToInt32(aniosBrig.Value), ImageControl.fileInpTObyteVec(FileUpload1), ImageControl.fileInpTObyteVec(FileUpload2), DB.idBrigada(VariablesSeccionControl.Lee<string>("Brigada")))))
            {
                mensaje("El Bombero ha sido creado", true);
            }
            else
            {
                mensaje("Ocurrio un error al guardar la información", true);
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
                if (Provincia.SelectedItem.ToString() == "Seleccionar")
                {
                    combobox.Items.Add("Seleccionar");
                }
                else {
                    CantonDB DB = new CantonDB();
                    List<string> cantonesList = DB.listaCantones(Provincia.SelectedValue);

                    for (int i = 0; i < cantonesList.Count; i++)
                    {
                        combobox.Items.Add(cantonesList[i]);
                    }
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
                if (Provincia.SelectedItem.ToString() == "Seleccionar")
                {
                    combobox.Items.Add("Seleccionar");
                }
                else {
                    DistritoDB DB = new DistritoDB();
                    List<string> distritosList = DB.listaDistritos(Canton.SelectedValue);

                    for (int i = 0; i < distritosList.Count; i++)
                    {
                        combobox.Items.Add(distritosList[i]);
                    }
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
    }
}