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
using Sistema.CapaConfiguracion;

namespace Sistema.CapaPresentacion.Html.Mantenimiento
{
    public partial class AsignarActivPrevenc : System.Web.UI.Page
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

        private void filterBindData2()
        {
            if (ButtonMuestra.Text.Equals(buttonName))
            {
                if (botonFiltrar.Text.Equals(buttonName2))
                {
                    BindData2(true);

                }
                else
                {
                    BindData2(true, columna.SelectedValue, operador.SelectedValue, valor.Value);
                }
            }
            else
            {
                if (botonFiltrar.Text.Equals(buttonName2))
                {
                    BindData2(false);

                }
                else
                {
                    BindData2(false, columna.SelectedValue, operador.SelectedValue, valor.Value);
                }
            }
            GridView2.PageIndexChanging += GridView2_PageIndexChanging;
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
                        if (!IsPostBack)
                        {
                            ocultaComboAreaCons();
                            CargarComboboxBriga(Brigadas, VariablesSeccionControl.Lee<string>("userAreaConserv"));
                            activaModal("buscar", true);
                        }
                    }
                }
                else
                {
                    cargarTabla();
                    cargarAsignados();
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

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            filterBindData2();

            if (GridView2.SelectedRow != null)
            {
                seleccionar2(GridView2.SelectedRow.RowIndex);
            }
        }


        private void BindData(bool activo)
        {
            // cargar los bomberos no asignados con actividad prevenc
            BomberoDB temp = new BomberoDB();
            GridView1.DataSource = temp.seleccionar_Dataset_NoActivPrevAsig(activo, VariablesSeccionControl.Lee<string>("Brigada"), null, null, null);
            GridView1.DataBind();
        }

        private void BindData(bool activo, string columna, string operador, string valor)
        {
            // cargar los bomberos no asignados con actividad prevenc
            BomberoDB temp = new BomberoDB();
            GridView1.DataSource = temp.seleccionar_Dataset_NoActivPrevAsig(activo, VariablesSeccionControl.Lee<string>("Brigada"), columna, operador, valor);
            GridView1.DataBind();
        }

        private void BindData2(bool activo)
        {
            // cargar los bomberos asignados con actividad prevenc
            BomberoDB temp = new BomberoDB();
            GridView2.DataSource = temp.seleccionar_Dataset_ActivPrevAsig(activo, VariablesSeccionControl.Lee<string>("Brigada"), null, null, null);
            GridView2.DataBind();
        }

        private void BindData2(bool activo, string columna, string operador, string valor)
        {
            // cargar los bomberos asignados con actividad prevenc
            BomberoDB temp = new BomberoDB();
            GridView2.DataSource = temp.seleccionar_Dataset_ActivPrevAsig(activo, VariablesSeccionControl.Lee<string>("Brigada"), columna, operador, valor);
            GridView2.DataBind();
        }

        private string seleccionar(int index)
        {
            //
            // Obtengo el id de la entidad que se esta editando
            // en este caso de la entidad Person
            //

            return Convert.ToString(GridView1.DataKeys[index].Values["PK_Id_BomberoForestal"]);
        }

        private string seleccionar2(int index)
        {
            //
            // Obtengo el id de la entidad que se esta editando
            // en este caso de la entidad Person
            //

            return Convert.ToString(GridView2.DataKeys[index].Values["PK_Id_BomberoForestal"]);
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

        protected void gvPerson_RowCommand2(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                //
                // Se obtiene indice de la row seleccionada
                //
                int index = Convert.ToInt32(e.CommandArgument);

                seleccionar2(index);
            }

        }

        protected void ButtonGuardar(object sender, EventArgs e)
        {
            if (GridView1.SelectedRow != null)
            {
                activaModal("agregarInfo", false);
                BombActivPrevDB DB = new BombActivPrevDB();
                if (!DB.existe(seleccionar(GridView1.SelectedRow.RowIndex), VariablesSeccionControl.Lee<int>("ActivPrevenc")))
                {
                    DB.insertar(seleccionar(GridView1.SelectedRow.RowIndex), VariablesSeccionControl.Lee<int>("ActivPrevenc"), Convert.ToInt32(cantHoras.Value));
                }
                else
                {
                    DB.activar(seleccionar(GridView1.SelectedRow.RowIndex), VariablesSeccionControl.Lee<int>("ActivPrevenc"), Convert.ToInt32(cantHoras.Value));
                }


                cargarTabla();
                cargarAsignados();
            }
        }

        protected void buttonAgregar_Click(object sender, ImageClickEventArgs e)
        {
            activaModal("agregarInfo", true);
        }

        protected void buttonQuitar_Click(object sender, ImageClickEventArgs e)
        {
            if (GridView2.SelectedRow != null)
            {
                BombActivPrevDB DB = new BombActivPrevDB();
                DB.inactivar(seleccionar2(GridView2.SelectedRow.RowIndex), VariablesSeccionControl.Lee<int>("ActivPrevenc"));

                cargarTabla();
                cargarAsignados();
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
            Response.AddHeader("content-disposition", "attachment;filename=ReportePoliza.xls");
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

        protected void Area_SelectedIndexChanged(object sender, EventArgs e)
        {
            Brigadas.Items.Clear();
            CargarComboboxBriga(Brigadas);
            activaModal("buscar", true);
        }

        // cargar para rol nacional y ti
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

        // cargar para rol regional
        protected void CargarComboboxBriga(DropDownList combobox, string bombero)
        {
            try
            {
                BrigadaDB DB = new BrigadaDB();
                List<string> brigadasList = DB.listaBrigadas(bombero);

                for (int i = 0; i < brigadasList.Count; i++)
                {
                    combobox.Items.Add(brigadasList[i]);
                }
            }
            catch
            {

            }
        }

        protected void ocultaComboAreaCons()
        {
            Area.Visible = false;
            labelArea.Visible = false;
        }

        protected void ButtonCargar(object sender, EventArgs e)
        {
            if (VariablesSeccionControl.Lee<byte>("userRol") == 0 || VariablesSeccionControl.Lee<byte>("userRol") == 1)
            {
                VariablesSeccionControl.Escribe("AreaConserv", Area.SelectedValue);
            }
            else
            {
                VariablesSeccionControl.Escribe("AreaConserv", VariablesSeccionControl.Lee<string>("userAreaConserv"));
            }

            VariablesSeccionControl.Escribe("Brigada", Brigadas.SelectedValue);
            cargarTabla();
            cargarAsignados();

            ActivPrevencDB P_DB = new ActivPrevencDB();

            string activPrevenc = P_DB.getNombre(VariablesSeccionControl.Lee<int>("ActivPrevenc"));
            this.tituloPrincipal.InnerText = " Asignar actividad de prevención " + activPrevenc;

            activaModal("buscar", false);
        }

        protected void cargarTabla()
        {
            this.titulo.InnerText = " Bomberos de la " + VariablesSeccionControl.Lee<string>("Brigada");
            filterBindData();
        }

        protected void cargarAsignados()
        {
            filterBindData2();
        }
    }
}