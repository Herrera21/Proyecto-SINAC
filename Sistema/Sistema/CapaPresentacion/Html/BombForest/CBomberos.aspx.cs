using CapaConfiguracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.Text;

namespace Sistema.CapaPresentacion.Html
{
    public partial class CBomberos : System.Web.UI.Page
    {
        private const string buttonName = "Mostrar elementos inactivos";
        private const string buttonName2 = "Filtrar";

        private void filterBindData()
        {
            if (ButtonMuestra.Text.Equals(buttonName))
            {
                if (botonFiltrar.Text.Equals(buttonName2))
                {
                    BindData(true);

                }
                else
                {
                    BindData(true, columna.SelectedValue, operador.SelectedValue, valor.Value);
                }
            }
            else
            {
                if (botonFiltrar.Text.Equals(buttonName2))
                {
                    BindData(false);

                }
                else
                {
                    BindData(false, columna.SelectedValue, operador.SelectedValue, valor.Value);
                }
            }
            GridView1.PageIndexChanging += GridView1_PageIndexChanging;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (VariablesSeccionControl.Lee<string>("userAreaConserv") == null)
            {
                Response.Redirect("/index.aspx");
            }
            else
            {
                if (VariablesSeccionControl.Lee<string>("Brigada") == null || VariablesSeccionControl.Lee<string>("AreaConserv") == null)
                {
                    if (VariablesSeccionControl.Lee<byte>("userRol") == 0 || VariablesSeccionControl.Lee<byte>("userRol") == 1)
                    {
                        if (!IsPostBack)
                        {
                            CargarComboboxArea(Area);
                            CargarComboboxBriga(Brigadas);
                            activaModal("buscar", true);
                        }
                    }
                    else
                    {
                        //modal para solo seleccionar brigada
                        //VariablesSeccionControl.Escribe("AreaConserv", VariablesSeccionControl.Lee<string>("userAreaConserv"));
                        //cargarTabla();
                    }
                }
                else
                {
                    cargarTabla();
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

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            filterBindData();

            if (GridView1.SelectedRow != null)
            {
                seleccionar(GridView1.SelectedRow.RowIndex);
            }
        }


        private void BindData(bool activo)
        {
            BomberoDB temp = new BomberoDB();
            GridView1.DataSource = temp.seleccionar_Dataset(activo, VariablesSeccionControl.Lee<string>("Brigada"), null, null, null);
            GridView1.DataBind();
        }

        private void BindData(bool activo, string columna, string operador, string valor)
        {
            BomberoDB temp = new BomberoDB();
            GridView1.DataSource = temp.seleccionar_Dataset(activo, VariablesSeccionControl.Lee<string>("Brigada"), columna, operador, valor);
            GridView1.DataBind();
        }

        private string seleccionar(int index)
        {
            //
            // Obtengo el id de la entidad que se esta editando
            // en este caso de la entidad Person
            //

            return Convert.ToString(GridView1.DataKeys[index].Values["PK_Id_BomberoForestal"]);
        }

        protected void gvPerson_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                //
                // Se obtiene indice de la row seleccionada
                //
                int index = Convert.ToInt32(e.CommandArgument);

                seleccionar(index);
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void buttonAgregar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("RBomInfoPerson.aspx");
        }

        protected void buttonModificar_Click(object sender, ImageClickEventArgs e)
        {
            if (GridView1.SelectedRow != null)
            {
                VariablesSeccionControl.Escribe("Bombero", seleccionar(GridView1.SelectedRow.RowIndex));
                Response.Redirect("MBomInfoPerson.aspx");
            }
        }

        protected void buttonConsultar_Click(object sender, ImageClickEventArgs e)
        {
            if (GridView1.SelectedRow != null && ButtonMuestra.Text.Equals(buttonName))
            {
                //VariablesSeccionControl.Escribe("Bombero", seleccionar(GridView1.SelectedRow.RowIndex));
                //Response.Redirect("BombForest/CBomberos.aspx");
            }

        }

        protected void buttonFiltrar_Click(object sender, ImageClickEventArgs e)
        {
            activaModal("filtro", true);
        }

        protected void buttonFiltrarModal(object sender, EventArgs e)
        {
            if (ButtonMuestra.Text.Equals(buttonName))
            {
                if (botonFiltrar.Text.Equals(buttonName2))
                {
                    BindData(true, columna.SelectedValue, operador.SelectedValue, valor.Value);
                    activaModal("filtro", false);
                    botonFiltrar.Text = "Borrar filtros";
                }
                else
                {
                    BindData(true);
                    activaModal("filtro", false);
                    botonFiltrar.Text = buttonName2;
                }
            }
            else
            {
                if (botonFiltrar.Text.Equals(buttonName2))
                {
                    BindData(false, columna.SelectedValue, operador.SelectedValue, valor.Value);
                    activaModal("filtro", false);
                    botonFiltrar.Text = "Borrar filtros";
                }
                else
                {

                    BindData(false);
                    activaModal("filtro", false);
                    botonFiltrar.Text = buttonName2;
                }
            }
        }

        protected void buttonMuestraInactivos(object sender, EventArgs e)
        {
            botonFiltrar.Text = buttonName2;
            if (ButtonMuestra.Text.Equals(buttonName))
            {
                ButtonMuestra.Text = "Mostrar elementos activos";
                BindData(false);
                activaModal("filtro", false);
            }
            else
            {
                ButtonMuestra.Text = buttonName;
                BindData(true);
                activaModal("filtro", false);
            }
        }

        protected void buttonImprimir_Click(object sender, ImageClickEventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.AddHeader("content-disposition", "attachment;filename=ReporteBrigadas.xls");
            Response.ContentType = "application/ms-excell";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridView1.Style.Add("color", "red;");
            GridView1.AllowPaging = false;
            GridView1.DataBind();
            GridView1.RenderControl(hw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            // VerifyRenderingInServerForm(control);
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
            catch
            {

            }
        }

        protected void Area_SelectedIndexChanged(object sender, EventArgs e)
        {
            Brigadas.Items.Clear();
            CargarComboboxBriga(Brigadas);
            activaModal("buscar", true);
        }

        protected void ButtonCargar(object sender, EventArgs e)
        {
            VariablesSeccionControl.Escribe("AreaConserv", Area.SelectedValue);
            VariablesSeccionControl.Escribe("Brigada", Brigadas.SelectedValue);
            cargarTabla();
            activaModal("buscar", false);
        }

        protected void cargarTabla()
        {
            this.titulo.InnerText = " Bomberos de la " + VariablesSeccionControl.Lee<string>("Brigada");
            filterBindData();
        }
    }
}