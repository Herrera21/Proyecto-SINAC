using Sistema.CapaConfiguracion;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sistema.CapaPresentacion.Html.BombForest
{
    public partial class CIncendForest : System.Web.UI.Page
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

                filterBindData();
            }
        }

        protected void activaInactivaModal(string id, bool activar)
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

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            filterBindData();
        }


        private void BindData(bool activo)
        {
            IncendForestDB temp = new IncendForestDB();
            GridView1.DataSource = temp.seleccionar_Dataset(activo, null, null, null);
            GridView1.DataBind();
        }

        private void BindData(bool activo, string columna, string operador, string valor)
        {
            IncendForestDB temp = new IncendForestDB();
            GridView1.DataSource = temp.seleccionar_Dataset(activo, columna, operador, valor);
            GridView1.DataBind();
        }

        private int seleccionar(int index)
        {
            //
            // Obtengo el id de la entidad que se esta editando
            // en este caso de la entidad Person
            //
            return Convert.ToInt32(GridView1.DataKeys[index].Values["PK_Id_IncendioForestal"]);
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
            Response.Redirect("RIncendForest.aspx");
        }

        protected void buttonModificar_Click(object sender, ImageClickEventArgs e)
        {
            if (GridView1.SelectedRow != null)
            {
                VariablesSeccionControl.Escribe("IncendForest", seleccionar(GridView1.SelectedRow.RowIndex));
                Response.Redirect("MIncendForest.aspx");
            }
        }

        protected void buttonConsultar_Click(object sender, ImageClickEventArgs e)
        {
            //if (GridView1.SelectedRow != null && ButtonMuestra.Text.Equals(buttonName))
            //{
            //    VariablesSeccionControl.Escribe("AreaConserv", seleccionar(GridView1.SelectedRow.RowIndex));
            //    Response.Redirect("CBrigadas.aspx");
            //}
        }

        protected void buttonFiltrar_Click(object sender, ImageClickEventArgs e)
        {
            activaInactivaModal("filtro", true);
        }

        protected void buttonFiltrarModal(object sender, EventArgs e)
        {
            if (ButtonMuestra.Text.Equals(buttonName))
            {
                if (botonFiltrar.Text.Equals(buttonName2))
                {
                    BindData(true, columna.SelectedValue, operador.SelectedValue, valor.Value);
                    activaInactivaModal("filtro", false);
                    botonFiltrar.Text = "Borrar filtros";
                }
                else
                {
                    BindData(true);
                    activaInactivaModal("filtro", false);
                    botonFiltrar.Text = buttonName2;
                }
            }
            else
            {
                if (botonFiltrar.Text.Equals(buttonName2))
                {
                    BindData(false, columna.SelectedValue, operador.SelectedValue, valor.Value);
                    activaInactivaModal("filtro", false);
                    botonFiltrar.Text = "Borrar filtros";
                }
                else
                {

                    BindData(false);
                    activaInactivaModal("filtro", false);
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
                activaInactivaModal("filtro", false);
            }
            else
            {
                ButtonMuestra.Text = buttonName;
                BindData(true);
                activaInactivaModal("filtro", false);
            }
        }

        protected void buttonImprimir_Click(object sender, ImageClickEventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.AddHeader("content-disposition", "attachment;filename=ReporteIncendioForestal.xls");
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
    }
}