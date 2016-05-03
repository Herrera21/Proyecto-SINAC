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
                    Response.Redirect("../CBrigadas.aspx");
                }
                else
                {
                    this.titulo.InnerText = " Bomberos de la brigada " + VariablesSeccionControl.Lee<string>("Brigada");

                    BindData();
                    GridView1.PageIndexChanging += GridView1_PageIndexChanging;
                }
            }
        }

        private void BindData()
        {
            BomberoDB temp = new BomberoDB();
            GridView1.DataSource = temp.seleccionar_Dataset(true, VariablesSeccionControl.Lee<string>("Brigada"), null, null, null);
            GridView1.DataBind();
        }
        private void BindData(bool activo, string cbombero, string columna, string operador, string valor)
        {
            BrigadaDB temp = new BrigadaDB();
            GridView1.DataSource = temp.seleccionar_Dataset(activo, VariablesSeccionControl.Lee<string>("Brigada"), columna, operador, valor);
            GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindData();

            if (GridView1.SelectedRow != null)
            {
                seleccionar(GridView1.SelectedRow.RowIndex);
            }
        }

        private string seleccionar(int index)
        {

            return Convert.ToString(GridView1.DataKeys[index].Values["PK_Id_BomberoForestal"]);
        }

        protected void gvPerson_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Select")
            {

                int index = Convert.ToInt32(e.CommandArgument);

                seleccionar(index);
            }

        }

        protected void buttonAgregar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("RBomInfoPerson.aspx");
        }

        protected void Imprimir_Click(object sender, ImageClickEventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.AddHeader("content-disposition", "attachment;filename=ReporteBomberos.xls");
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